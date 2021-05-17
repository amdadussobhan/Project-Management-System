using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS
{
    public partial class Rename : Form
    {
        SkillContext _db = new SkillContext();
        public Sub_Folder _sub_folder;

        public Rename()
        {
            InitializeComponent();
        }

        private static Rename instance;
        public static Rename getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Rename();
            else
                instance.BringToFront();
            return instance;
        }

        private void Rename_Load(object sender, EventArgs e)
        {
            var jobIds = _db.New_Jobs.OrderByDescending(x => x.Id).Take(999).Select(x => x.JobId);
            foreach (var jobId in jobIds)
                Cmb_Job_ID.Items.Add(jobId);
        }

        private void Btn_Backup_Click(object sender, EventArgs e)
        {
            string Loc = Txt_Location.Text;
            string job_Id = Cmb_Job_ID.Text; 
            if (!string.IsNullOrEmpty(Loc) & Directory.Exists(Loc))
            {
                string[] files = Directory.GetFiles(Loc, "*", SearchOption.AllDirectories);
                Prb_Rename.Value = 0;
                Prb_Rename.Maximum = files.Count();
                int sl = _db.Sub_Folders.Where(x => x.Job_ID == job_Id).Count();

                foreach (string sourceFile in files)
                {
                    sl++;
                    string ext = Path.GetExtension(sourceFile);
                    string path = Path.GetDirectoryName(sourceFile);
                    string Old_Name = Path.GetFileNameWithoutExtension(sourceFile);
                    string newName = "SG_";
                    
                    if (sl < 10)
                        newName += "00" + sl;
                    else if(sl < 100)
                        newName += "0" + sl;
                    else
                        newName += sl;

                    string desFile = Path.Combine(path, newName + ext);
                    File.Move(sourceFile, desFile);

                    _sub_folder = _db.Sub_Folders
                        .Where(x => x.Job_ID == job_Id & x.Path == sourceFile & x.Old_Name == Old_Name)
                        .FirstOrDefault<Sub_Folder>();

                    if (_sub_folder == null)
                    {
                        _sub_folder = new Sub_Folder();
                        _sub_folder.Job_ID = job_Id;
                        _sub_folder.Path = sourceFile;
                        _sub_folder.Old_Name = Old_Name;
                        _sub_folder.New_Name = newName;
                        _db.Sub_Folders.Add(_sub_folder);
                    }
                    Prb_Rename.Increment(1);
                }

                _db.SaveChanges();
                MessageBox.Show(@"Successfully renamed. Please check this Folder ", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Directory.Exists(Loc))
                    Process.Start(Loc);
                else
                    MessageBox.Show(@"Folder doesn't Exist. Please Enter Correct Location...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(@"Folder Location maybe Empty. Please Enter correct folder Location", @"Invalid Folder Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Restore_Click(object sender, EventArgs e)
        {
            string Loc = Txt_Location.Text;
            string jobId = Cmb_Job_ID.Text;
            if (!string.IsNullOrEmpty(Loc) & Directory.Exists(Loc))
            {
                string[] files = Directory.GetFiles(Loc, "*", SearchOption.AllDirectories);
                Prb_Rename.Value = 0;
                Prb_Rename.Maximum = files.Count();
                foreach (string sourceFile in files)
                {
                    string path = Path.GetDirectoryName(sourceFile);
                    string ext = Path.GetExtension(sourceFile);
                    string newName = Path.GetFileNameWithoutExtension(sourceFile);

                    var subfolder = _db.Sub_Folders
                        .FirstOrDefault(x => x.Job_ID == jobId & x.New_Name == newName);

                    if (subfolder != null)
                    {
                        string desFile = Path.Combine(path, subfolder.Old_Name + ext);
                        if (!File.Exists(desFile))
                            File.Move(sourceFile, desFile);
                    }
                    Prb_Rename.Increment(1);
                }
                MessageBox.Show(@"Successfully Renamed. Please check this Folder", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(Loc);
            }
            else
                MessageBox.Show(@"Folder Location maybe empty. Please check folder location......", @"Folder Doesn't work", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

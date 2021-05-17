using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Common_Panel
{
    public partial class Productivity : Form
    {
        private readonly Common _common = new Common();
        SkillContext DB = new SkillContext();
        Common common = new Common();

        public User user;
        public string _jobID, _image, _name, _shift;
        public DateTime _dateFrom, _dateTo;
        public NewJob _job = new NewJob();

        public Productivity()
        {
            InitializeComponent();
        }

        private static Productivity instance;
        public static Productivity getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Productivity();
            else
                instance.BringToFront();
            return instance;
        }

        private void Productivity_Load(object sender, EventArgs e)
        {
            if (_jobID != null)
                Cmb_Job_ID.Text = _jobID;

            if (_shift != null)
                Cmb_Shift.Text = _shift;

            if (_name != null)
                Cmb_Name.Text = _name;

            if (_image!= null)
                Txt_Image.Text = _image;

            foreach (var designer in _common.Current_Designers())
                Cmb_Name.Items.Add(designer.Name);

            var jobs = DB.New_Jobs.OrderByDescending(x => x.Id).Take(99);
            foreach (var job in jobs)
                Cmb_Job_ID.Items.Add(job.JobId);

            _job = DB.New_Jobs
                .FirstOrDefault(x => x.JobId == _jobID);

            Load_Data();
            //int Done = (from lo in DB.Logs
            //            join usr in DB.Users on lo.Name equals usr.Short_Name
            //            orderby lo.Id
            //            where lo.JobId == _job.JobId & lo.Status == "Done"
            //            select new
            //            {
            //                lo.Image
            //            }).Count();

            //Btn_Done.Text = "Done: " + Done;

            //int Running = (from lo in DB.Logs
            //            join usr in DB.Users on lo.Name equals usr.Short_Name
            //            orderby lo.Id
            //            where lo.JobId == _job.JobId & lo.Status == "Running"
            //            select new
            //            {
            //                lo.Image
            //            }).Count();

            //Btn_Running.Text = "Running: " + Running;

            if (user.Role == "SI" | user.Role == "QC" | user.Role == "CS")
            {
                Btn_Stop.Visible = true;
                Btn_Back.Visible = true;
                Txt_Location.Visible = true;
                Btn_Subfolder.Visible = true;
                Btn_Pass.Visible = true;
            }

            if(user.Role == "QC")
                Btn_Pass.Text = "Pass to CS";

            if (user.Role == "CS")
                Btn_Pass.Text = "Job Done";
        }

        void Load_Data()
        {
            var findLogs = DB.Logs.Where(x => x.Image != "");

            if (_jobID != null)
                findLogs = findLogs.Where(x => x.JobId == _jobID);

            if (_shift != null)
                findLogs = findLogs.Where(x => x.Shift == _shift);

            if (_name != null)
                findLogs = findLogs.Where(x => x.Name == _name);

            if (_image != null)
                findLogs = findLogs.Where(x => x.Image == _image);

            var logs = findLogs.OrderBy(x => x.Efficiency).Take(9999).ToList();

            DGV_Productivity.DataSource = null;
            DGV_Productivity.Rows.Clear();
            common.Dgv_Size(DGV_Productivity, 11);

            int SL = 1;
            foreach (var log in logs)
            {
                DGV_Productivity.Rows.Add(SL++, log.Name, log.Image, log.Service, log.Status, log.TargetTime, Math.Round(log.ProTime, 2), log.Efficiency + "%", log.Quality + "%", log.StartTime, log.EndTime);
            }

            common.Row_Color_By_Efficiency(DGV_Productivity, "Column9");
        }

        private void Btn_Find_Click(object sender, EventArgs e)
        {
            var jobId = Cmb_Job_ID.Text;
            if (!string.IsNullOrEmpty(jobId) | jobId.ToUpper() != "ALL")
                _jobID = jobId;

            var shift = Cmb_Shift.Text;
            if (!string.IsNullOrEmpty(shift) | shift.ToUpper() != "ALL")
                _shift = shift;

            var name = Cmb_Name.Text;
            if (!string.IsNullOrEmpty(name) | name.ToUpper() != "ALL")
                _name = name;

            var image = Txt_Image.Text;
            if (!string.IsNullOrEmpty(image) | image.ToUpper() != "ALL")
                _image = image;

            Load_Data();
        }

        private void Btn_Pass_Click(object sender, EventArgs e)
        {
            if (Btn_Pass.Text == "Pass to QC")
                _job.Status = "QC";
            else
                _job.Status = "Ready";

            DB.SaveChanges();
            this.Close();
        }

        private void Btn_Subfolder_Click(object sender, EventArgs e)
        {
            string Loc = Txt_Location.Text;
            if (Directory.Exists(Loc))
            {
                string[] files = Directory.GetFiles(Loc);
                Prb_Subfolder.Value = 0;
                Prb_Subfolder.Maximum = files.Count();
                foreach (string file_path in files)
                {
                    string ext = Path.GetExtension(file_path);
                    string new_name = Path.GetFileNameWithoutExtension(file_path);
                    var subfolder = DB.Sub_Folders
                        .FirstOrDefault(x => x.Job_ID == _job.JobId & x.New_Name == new_name);

                    if (subfolder != null)
                    {
                        string path = subfolder.Path;
                        string file_name = subfolder.Old_Name + ext;
                        Loc = Path.GetDirectoryName(path);

                        if (!Directory.Exists(Loc))
                            Directory.CreateDirectory(Loc);

                        path = Path.Combine(Loc, file_name);
                        if (!File.Exists(path))
                            File.Move(file_path, path);
                    }
                    Loc = Path.GetDirectoryName(file_path);
                    Prb_Subfolder.Increment(1);
                }
                Txt_Location.Text = Loc;
                MessageBox.Show(@"Sub Folder Successfully Created. Please check this Folder", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(Loc);
            }
            else
                MessageBox.Show(@"Folder Location maybe empty. Please check folder location......", @"Folder Doesn't work", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            _job.Status = "New";
            DB.SaveChanges();
            this.Close();
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            if (user.Role == "QC")
                _job.Status = "Pro";
            else
                _job.Status = "New";

            DB.SaveChanges();
            this.Close();
        }
    }
}

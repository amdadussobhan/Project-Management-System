using Google.Protobuf.WellKnownTypes;
using Skill_PMS.Controller;
using Skill_PMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    public partial class MissingFiles : Form
    {
        private static MissingFiles instance;
        SkillContext _db = new SkillContext();
        private readonly Common _common = new Common();

        public MissingFiles()
        {
            InitializeComponent();
        }

        public static MissingFiles getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new MissingFiles();
            else
                instance.BringToFront();
            return instance;
        }

        private void MissingFiles_Load(object sender, EventArgs e)
        {
            var jobIds = _db.New_Jobs.OrderByDescending(x => x.Id).Take(999).Select(x => x.JobId);
            foreach (var job in jobIds)
                Cmb_JobID.Items.Add(job);
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Cmb_JobID.Text))
            {
                int row = 0;
                if (Dgv_Missing_Files.CurrentCell != null)
                    row = Dgv_Missing_Files.CurrentCell.RowIndex;

                Dgv_Missing_Files.DataSource = null;
                Dgv_Missing_Files.Rows.Clear();
                _common.Dgv_Size(Dgv_Missing_Files, 11);

                var jobId = Cmb_JobID.Text;
                var loc = Txt_Location.Text;

                if (string.IsNullOrEmpty(loc))
                {
                    var imagesInImageTime = _db.ImageTime
                    .Where(imageTime => imageTime.Job_ID == jobId)
                    .Select(imageTime => imageTime.Image);

                    var files = imagesInImageTime
                        .Except(
                            _db.Logs
                                .Where(log => log.JobId == jobId)
                                .Select(log => log.Image)
                        )
                        .ToList();


                    var sl = 1;
                    foreach (var file in files)
                        Dgv_Missing_Files.Rows.Add(sl++, file, "Pending", "Pending");
                }
                else
                {
                    var logs = _db.Logs
                    .Where(log => log.JobId == jobId)
                    .ToList();

                    string[] files = Directory.GetFiles(loc, "*", SearchOption.AllDirectories);

                    var imagesNotInDirectory = logs
                        .Where(log => !files
                            .Select(filePath => Path.GetFileNameWithoutExtension(filePath))
                            .Contains(log.Image))
                        .Select(log => new { log.Image, log.Name, log.StartTime, log.Service })
                        .ToList();

                    var sl = 1;
                    foreach (var log in imagesNotInDirectory)
                    {
                        Dgv_Missing_Files.Rows.Add(sl++, log.Image, log.Name, log.StartTime, log.Service);
                    }
                }
            }
            else
                MessageBox.Show(@"Invalid Job ID Selected.!!! Please Check Job ID", @"Invalid Job ID Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

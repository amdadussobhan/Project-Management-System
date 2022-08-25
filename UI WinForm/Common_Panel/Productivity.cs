using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.Production.QC_Panel;
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
        SkillContext _db = new SkillContext();
        Common common = new Common();

        public User _user;
        public int _runningJobsId = 0;
        public string _jobID, _image, _name, _shift, _service, _team;
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

        private void Chk_CP_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
        }

        private void Check_Service()
        {
            _service = ""; 

            if (Chk_CP.Checked)
                _service += "CP+";

            if (Chk_RET.Checked)
                _service += "RET+";

            if (Chk_NJ.Checked)
                _service += "NJ+";

            if (Chk_MSK.Checked)
                _service += "MSK+";

            if (Chk_SHA.Checked)
                _service += "SHA+";

            if (Chk_LIQ.Checked)
                _service += "LIQ+";

            if (Chk_CC.Checked)
                _service += "CC+";

            if (Chk_AI.Checked)
                _service += "AI";

            if (Chk_MQ.Checked)
                _service += "MQ+";

            if (Chk_RS.Checked)
                _service += "RS";

            _service = _service.TrimEnd('+');
            Lbl_Service.Text = "Service: "+ _service;
        }

        private void Chk_RET_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
        }

        private void Chk_NJ_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
        }

        private void Chk_MSK_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
        }

        private void Chk_SHA_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
        }

        private void Chk_LIQ_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
        }

        private void Chk_CC_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
        }

        private void DGV_Productivity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_Productivity.Columns[DGV_Productivity.CurrentCell.ColumnIndex].HeaderText.Contains("Name"))
            {
                if (DGV_Productivity.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                {
                    if (DGV_Productivity.Rows[e.RowIndex].Cells[10].Value.ToString() != "")
                    {
                        var feedback = Pro_Feedback.GetInstance();
                        feedback._name = DGV_Productivity.Rows[e.RowIndex].Cells[1].Value.ToString();
                        feedback._image = DGV_Productivity.Rows[e.RowIndex].Cells[2].Value.ToString();
                        feedback.User = _user;
                        feedback._job = _job;
                        feedback.Show();
                    }
                }
            }
        }

        private void Chk_MQ_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
        }

        private void Btn_Done_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_service))
            {
                MessageBox.Show(@"Job Service is empty. Please Select Actual Job Service and try again......", @"Job Service is empty.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int file = 0;
            if (!string.IsNullOrEmpty(Txt_File.Text))
                file = Convert.ToInt32(Txt_File.Text);
            else
            {
                MessageBox.Show(@"File is empty. Please enter actual output file count......", @"File is empty.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string loc = Txt_Location.Text;
            var logCount = _db.Logs.Where(x => x.JobId == _job.JobId & x.Status == "Running").Count();
            if (logCount > 0)
            {
                MessageBox.Show(@"Job is Still Running. Please inform production team to finish this job.", @"Job is Still Running.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _job.OutputAmount = file;
            _job.OutputLocation = loc;
            _job.Service = _service;
            _job.ProEnd = DateTime.Now;
            _job.Status = "Ready";

            _job.ProDone = _db.Logs.Where(x => x.JobId == _job.JobId & x.Status == "Done").Select(x => x.Image).Distinct().Count();

            if (_job.ProDone > 0)
                _job.ProTime = _db.Logs.Where(x => x.JobId == _job.JobId & x.Status == "Done").Distinct().Sum(x => x.ProTime) / _job.ProDone;

            _db.SaveChanges();
            this.Close();
        }

        private void Chk_RS_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
        }

        private void Chk_AI_CheckedChanged(object sender, EventArgs e)
        {
            Check_Service();
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

            var jobs = _db.New_Jobs.OrderByDescending(x => x.Id).Take(99);
            foreach (var job in jobs)
                Cmb_Job_ID.Items.Add(job.JobId);

            _job = _db.New_Jobs.FirstOrDefault(x => x.JobId == _jobID);
            Txt_File.Text = _job.ProDone+"";

            Load_Data();

            if (_user.Role == "SI" | _user.Role == "QC")
                Pnl_Control.Visible = true;
        }

        void Load_Data()
        {
            var findLogs = _db.Logs.Where(x => x.Image != "");

            //2022
            //if (_team != null)
            //    findLogs = findLogs.Where(x => x.Team == _team);

            if (_jobID != null)
                findLogs = findLogs.Where(x => x.JobId == _jobID);

            if (_shift != null)
                findLogs = findLogs.Where(x => x.Shift == _shift);

            if (_name != null)
                findLogs = findLogs.Where(x => x.Name == _name);

            if (_image != null)
                findLogs = findLogs.Where(x => x.Image == _image);

            var logs = findLogs.OrderBy(x => x.Efficiency).Take(999).ToList();

            DGV_Productivity.DataSource = null;
            DGV_Productivity.Rows.Clear();
            common.Dgv_Size(DGV_Productivity, 11);

            int SL = 1;
            foreach (var log in logs)
            {
                DGV_Productivity.Rows.Add(SL++, log.Name, log.Image, log.Service, log.Status, Math.Round(log.TargetTime, 1), Math.Round(log.ProTime, 2), log.Efficiency + "%", log.Quality + "%", log.StartTime, log.EndTime);
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
                    var subfolder = _db.Sub_Folders.FirstOrDefault(x => x.Job_ID == _job.JobId & x.New_Name == new_name);

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
    }
}

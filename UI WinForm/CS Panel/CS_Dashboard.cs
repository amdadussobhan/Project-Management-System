using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.Common_Panel;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.CS_Panel
{
    public partial class CsDashboard : Form
    {
        private SkillContext _db = new SkillContext();
        private readonly DateTime _today = DateTime.Now.Date;
        private readonly Common _common = new Common();
        private int _counter = 0;
        private ShiftReport _shiftReport;
        private string _shift;

        public static User User { get; set; }
        public Performance Performance;

        public CsDashboard()
        {
            InitializeComponent();
        }

        private static CsDashboard _instance;
        public static CsDashboard GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new CsDashboard();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = @"CS Panel - " + User.Full_Name;
            Tmr_Count.Start();
            Check_Shift_Report();
            Check_New_Job();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Performance = _db.Performances
                .FirstOrDefault(x => x.Name == User.Short_Name & x.Date == _today);
            _common.Logout(Performance);
        }

        private void Btn_Add_New_Job_Click(object sender, EventArgs e)
        {
            var addJob = new JobEntry {User = User};
            addJob.Show();
        }

        private void Check_New_Job()
        {
            Dgv_New_Job.DataSource = null;
            Dgv_New_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_New_Job, 11);

            var jobs = _db.New_Jobs.Where(x => x.Status== "New").Take(99).ToList();

            var sl = 1;
            foreach (var job in jobs)
                Dgv_New_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.ActualTime, job.ActualTime * job.InputAmount, job.Incoming, job.Delivery, "Delete");

            _common.Row_Color_By_Delivery(Dgv_New_Job, "Column28");
        }

        private void Check_Running_Job()
        {
            int row = 0;
            if (Dgv_Running_Job.CurrentCell != null)
                row = Dgv_Running_Job.CurrentCell.RowIndex;

            Dgv_Running_Job.DataSource = null;
            Dgv_Running_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_Running_Job, 11);

            var jobs = _db.New_Jobs.Where(x => x.Status == "Pro").Take(99).ToList();

            var sl = 1;
            foreach (var job in jobs)
                Dgv_Running_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.ProDone, job.Service, job.ActualTime, Math.Round(job.ProTime, 2), job.Delivery);

            int max_row = Dgv_Running_Job.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_Running_Job.CurrentCell = Dgv_Running_Job.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_Running_Job.CurrentCell = Dgv_Running_Job.Rows[row].Cells[3];
            }

            _common.Row_Color_By_Delivery(Dgv_Running_Job, "Column33");
        }

        private void Check_QC_Job()
        {
            int row = 0;
            if (Dgv_QC_Job.CurrentCell != null)
                row = Dgv_QC_Job.CurrentCell.RowIndex;

            Dgv_QC_Job.DataSource = null;
            Dgv_QC_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_QC_Job, 11);

            var jobs = _db.New_Jobs.Where(x => x.Status == "QC").OrderByDescending(x => x.Delivery).Take(99).ToList();

            var sl = 1;
            foreach (var job in jobs)
                Dgv_QC_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.ProDone, job.OutputAmount, job.Service, job.ActualTime, Math.Round(job.ProTime,2), job.Delivery, "Re-assign");

            int max_row = Dgv_QC_Job.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_QC_Job.CurrentCell = Dgv_QC_Job.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_QC_Job.CurrentCell = Dgv_QC_Job.Rows[row].Cells[3];
            }

            _common.Row_Color_By_Delivery(Dgv_QC_Job, "Column9");
        }

        private void Check_Ready_Job()
        {
            int row = 0;
            if (Dgv_Ready_Job.CurrentCell != null)
                row = Dgv_Ready_Job.CurrentCell.RowIndex;

            Dgv_Ready_Job.DataSource = null;
            Dgv_Ready_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_Ready_Job, 11);

            var jobs = _db.New_Jobs.Where(x => x.Status == "Ready").OrderByDescending(x => x.Id).Take(99).ToList();

            var sl = 1;
            foreach (var job in jobs)
                Dgv_Ready_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.OutputAmount, job.Service, job.ActualTime, Math.Round(job.ProTime, 2), job.Delivery, "Re-assign");

            int max_row = Dgv_Ready_Job.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_Ready_Job.CurrentCell = Dgv_Ready_Job.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_Ready_Job.CurrentCell = Dgv_Ready_Job.Rows[row].Cells[3];
            }

            //_common.Row_Color_By_Efficiency(Dgv_Ready_Job, "Column9");
        }

        private void Check_Done_Job()
        {
            int row = 0;
            if (Dgv_Done_Job.CurrentCell != null)
                row = Dgv_Done_Job.CurrentCell.RowIndex;

            Dgv_Done_Job.DataSource = null;
            Dgv_Done_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_Done_Job, 11);

            var jobs = _db.New_Jobs.Where(x => x.Status == "Done").Take(99).ToList();

            var sl = 1;
            foreach (var job in jobs)
                Dgv_Done_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.Service, job.ActualTime, Math.Round(job.ProTime, 2), job.Delivery, "Edit");

            int max_row = Dgv_Done_Job.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_Done_Job.CurrentCell = Dgv_Done_Job.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_Done_Job.CurrentCell = Dgv_Done_Job.Rows[row].Cells[3];
            }

            //_common.Row_Color_By_Delivery(Dgv_QC_Job, "Column9");
        }

        private void Tbc_CS_Panel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Check_Data();
        }

        private void Dgv_New_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_New_Job.Columns[Dgv_New_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                var jobEntry = JobEntry.GetInstance();
                if (Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    jobEntry._newJob.JobId = jobEntry._oldJobId = Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    jobEntry._isModify = true;
                    jobEntry.User = User;
                    jobEntry.Show();
                }
            }

            if (Dgv_New_Job.Columns[Dgv_New_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Action"))
            {
                //var jobEntry = JobEntry.GetInstance();
                //if (Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                //{
                //    jobEntry.Job.JobId = Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //}

                //if (!string.IsNullOrWhiteSpace(Dgv_New_Job.CurrentCell.EditedFormattedValue.ToString()))
                //{
                //    jobEntry.User = User;
                //    jobEntry.Show();
                //}
            }
        }

        private void Dgv_Running_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Running_Job.Columns[Dgv_Running_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                var jobEntry = JobEntry.GetInstance();
                if (Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    jobEntry._newJob.JobId = jobEntry._oldJobId = Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    jobEntry._isModify = true;
                    jobEntry.User = User;
                    jobEntry.Show();
                }
            }

            if (Dgv_Running_Job.Columns[Dgv_Running_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
            {
                var productivity = Productivity.getInstance();
                if (Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    productivity._jobID= Dgv_Running_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                    productivity.user = User;
                    productivity.Show();
                }
            }
        }

        private void Dgv_QC_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_QC_Job.Columns[Dgv_QC_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                var jobEntry = JobEntry.GetInstance();
                if (Dgv_QC_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    jobEntry._newJob.JobId = jobEntry._oldJobId = Dgv_QC_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    jobEntry._isModify = true;
                    jobEntry.User = User;
                    jobEntry.Show();
                }
            }

            if (Dgv_QC_Job.Columns[Dgv_QC_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
            {
                var productivity = Productivity.getInstance();
                if (Dgv_QC_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    productivity._jobID = Dgv_QC_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                    productivity.user = User;
                    productivity.Show();
                }
            }

            if (Dgv_QC_Job.Columns[Dgv_QC_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Action"))
            {
                var jobEntry = JobEntry.GetInstance();
                if (Dgv_QC_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to Re-Assign this Job...?", "Sure to Re-Assign...?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        jobEntry._newJob.JobId = jobEntry._redoJob.JobId = Dgv_QC_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                        jobEntry._isRedo = true;
                        jobEntry.User = User;
                        jobEntry.Show();
                    }
                }
            }
        }

        private void Dgv_Ready_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Ready_Job.Columns[Dgv_Ready_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
            {
                var productivity = Productivity.getInstance();
                if (Dgv_Ready_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    productivity._jobID = Dgv_Ready_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                    productivity.user = User;
                    productivity.Show();
                }
            }

            if (Dgv_Ready_Job.Columns[Dgv_Ready_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Action"))
            {
                var jobEntry = JobEntry.GetInstance();
                if (Dgv_Ready_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to Re-Assign this Job...?", "Sure to Re-Assign...?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        jobEntry._newJob.JobId = jobEntry._redoJob.JobId = Dgv_Ready_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                        jobEntry._isRedo = true;
                        jobEntry.User = User;
                        jobEntry.Show();
                    }
                }
            }
        }

        private void Check_Shift_Report()
        {
            var date = _common.Shift_Date(DateTime.Now, _shift);
            _shiftReport = _db.Shift_Reports
                   .FirstOrDefault(x => x.Date == date & x.Shift == _shift);

            if (_shiftReport != null)
            {
                Btn_Workload.Text = @"Workload: " + _shiftReport.TotalLoad;
                Btn_Capacity.Text = @"Capacity: " + _shiftReport.Capacity;
            }
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            _db = new SkillContext();
            _shift = _common.Current_Shift();
            Check_Shift_Report();
            Check_Data();

            if (_counter++ >= 9)
            {
                _common.Change_Shift();
                if (_shiftReport.TotalLoad == 0)
                {
                    waiting waiting = new waiting();
                    waiting.Show();
                    _common.Starting_Shift_Report(DateTime.Now, _shift);
                    waiting.Close();
                    _counter = 0;
                }
            }
        }

        private void Check_Data()
        {
            _db = new SkillContext();
            switch (Tbc_CS_Panel.SelectedIndex)
            {
                case 0:
                    Check_New_Job();
                    break;

                case 1:
                    Check_Running_Job();
                    break;
                case 2:
                    Check_QC_Job();
                    break;

                case 3:
                    Check_Ready_Job();
                    break;

                case 4:
                    Check_Done_Job();
                    break;
            }
        }

        private void Btn_Capacity_Click(object sender, EventArgs e)
        {
            var performanceUi = Performance_UI.getInstance();
            performanceUi.Show();
        }

        private void Btn_Workload_Click(object sender, EventArgs e)
        {
            var workload = Workload_Report.getInstance();
            workload.Show();
        }

        private void Btn_Find_QC_Job_Click(object sender, EventArgs e)
        {
            Tmr_Count.Stop();
            var jobId = Cmb_QC_Job_ID.Text;
            if (string.IsNullOrEmpty(jobId) | jobId.ToUpper() == "ALL")
                jobId = null;

            var folder = Txt_QC_Folder.Text;
            if (string.IsNullOrEmpty(folder) | folder.ToUpper() == "ALL")
                folder = null;

            int row = 0;
            if (Dgv_QC_Job.CurrentCell != null)
                row = Dgv_QC_Job.CurrentCell.RowIndex;

            Dgv_QC_Job.DataSource = null;
            Dgv_QC_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_QC_Job, 11);

            var findsData = _db.New_Jobs.Where(x => x.Status == "QC");

            if (jobId != null)
                findsData = findsData.Where(x => x.JobId == jobId);

            if (folder != null)
                findsData = findsData.Where(x => x.Folder == folder);

            var jobs = findsData.OrderByDescending(x => x.Delivery).Take(99).ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_QC_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.ProDone, job.OutputAmount, job.Service, job.ActualTime, job.ProTime, job.Delivery, "Re-assign");
            }

            int max_row = Dgv_QC_Job.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_QC_Job.CurrentCell = Dgv_QC_Job.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_QC_Job.CurrentCell = Dgv_QC_Job.Rows[row].Cells[3];
            }

            _common.Row_Color_By_Delivery(Dgv_QC_Job, "Column9");
        }

        private void Btn_Find_Ready_Jobs_Click(object sender, EventArgs e)
        {
            Tmr_Count.Stop();
            var jobId = Cmb_Ready_JobID.Text;
            if (string.IsNullOrEmpty(jobId) | jobId.ToUpper() == "ALL")
                jobId = null;

            var folder = Txt_Ready_Folder.Text;
            if (string.IsNullOrEmpty(folder) | folder.ToUpper() == "ALL")
                folder = null;

            int row = 0;
            if (Dgv_Ready_Job.CurrentCell != null)
                row = Dgv_Ready_Job.CurrentCell.RowIndex;

            Dgv_Ready_Job.DataSource = null;
            Dgv_Ready_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_Ready_Job, 11);

            var findsData = _db.New_Jobs.Where(x => x.Status == "Ready");

            if (jobId != null)
                findsData = findsData.Where(x => x.JobId == jobId);

            if (folder != null)
                findsData = findsData.Where(x => x.Folder == folder);

            var jobs = findsData.OrderByDescending(x => x.Id).Take(99).ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_Ready_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.OutputAmount, job.Service, job.ActualTime, job.ProTime, job.Delivery, "Re-assign");
            }

            int max_row = Dgv_Ready_Job.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_Ready_Job.CurrentCell = Dgv_Ready_Job.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_Ready_Job.CurrentCell = Dgv_Ready_Job.Rows[row].Cells[3];
            }

            //_common.Row_Color_By_Efficiency(Dgv_QC_Job, "Column9");
        }

        private void Btn_Rename_Click(object sender, EventArgs e)
        {
            var rename = new Rename();
            rename.Show();
        }
    }
}

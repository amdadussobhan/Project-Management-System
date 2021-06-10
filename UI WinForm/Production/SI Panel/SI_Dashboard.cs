using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.Common_Panel;
using Skill_PMS.UI_WinForm.Production.QC_Panel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    public partial class SiDashboard : Form
    {
        private SkillContext _db = new SkillContext();
        private readonly Common _common = new Common();
        private DateTime _date;
        private string _shift;
        private int _counter = 0;
        ShiftReport _shiftReport;

        public static User _user { get; set; }
        public Performance _performance;

        public SiDashboard()
        {
            InitializeComponent();
        }

        private static SiDashboard _instance;
        public static SiDashboard GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new SiDashboard();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void SI_Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = @"SI Panel - " + _user.Full_Name;
            Check_New_Job();
            _shift = _common.Current_Shift();
            Check_Shift_Report();
        }

        private void Check_New_Job()
        {
            int row = 0;
            if (Dgv_New_Job.CurrentCell != null)
                row = Dgv_New_Job.CurrentCell.RowIndex;

            Dgv_New_Job.DataSource = null;
            Dgv_New_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_New_Job, 11);

            var jobs = _db.New_Jobs
                .Where(x => x.Status == "New")
                .Take(99)
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_New_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.ActualTime, job.ActualTime * job.InputAmount, job.Incoming, job.Delivery);
            }

            int max_row = Dgv_New_Job.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_New_Job.CurrentCell = Dgv_New_Job.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_New_Job.CurrentCell = Dgv_New_Job.Rows[row].Cells[3];
            }

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

            var jobs = _db.New_Jobs
                .Where(x => x.Status == "Pro")
                .Take(99)
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_Running_Job.Rows.Add(sl++, job.JobId, job.Folder, job.Service, job.InputAmount, job.ProDone, job.TargetTime, Math.Round(job.ProTime, 2), job.Delivery);
            }

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

            var jobs = _db.New_Jobs
                .Where(x => x.Status == "QC")
                .Take(99)
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_QC_Job.Rows.Add(sl++, job.JobId, job.Folder, job.Service, job.InputAmount, job.ProDone, job.OutputAmount, job.TargetTime, Math.Round(job.ProTime, 2), job.Delivery, "Edit");
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

        private void Check_Performance()
        {
            var date = _common.Shift_Date(DateTime.Now, _shift);
            Dgv_Performance.DataSource = null;
            Dgv_Performance.Rows.Clear();
            _common.Dgv_Size(Dgv_Performance, 11);

            var performances = (from per in _db.Performances
                                join user in _db.Users
                                on per.Name equals user.Short_Name
                                where per.Date == date & user.Role == "" & per.Shift == _shift
                                select new
                                {
                                    per.Name,
                                    per.Shift,
                                    per.Login,
                                    per.Logout,
                                    per.WorkingTime,
                                    per.File,
                                    per.JobTime,
                                    per.ProTime,
                                    per.Efficiency,
                                    per.Quality,
                                }).OrderByDescending(x => x.Efficiency).ToList();

            var sl = 1;
            foreach (var per in performances)
            {
                var start_time = _common.Shift_Time(per.Shift);
                if (start_time > per.Logout)
                    start_time = per.Logout;

                var Capacity = (per.Logout - start_time).TotalMinutes;
                Dgv_Performance.Rows.Add(sl++, per.Name, per.Shift, per.Login, per.Logout, per.WorkingTime, per.File, per.JobTime, Math.Round(per.ProTime), Math.Round(Capacity - per.ProTime), per.Efficiency + "%", per.Quality + "%");
            }

            _common.Row_Color_By_Efficiency(Dgv_Performance, "Column13");
        }

        private void Check_History()
        {
            DgvHistory.DataSource = null;
            DgvHistory.Rows.Clear();
            _common.Dgv_Size(DgvHistory, 11);

            var logs = _db.Logs
                .Where(x => x.Status == "Done")
                .OrderByDescending(x => x.Id)
                .Take(999)
                .ToList();

            var sl = 1;
            foreach (var log in logs)
                DgvHistory.Rows.Add(sl++, log.Name, log.JobId, log.Category, log.Image, log.Service, log.StartTime, log.EndTime, log.TargetTime, Math.Round(log.ProTime, 2), log.Efficiency + "%");

            _common.Row_Color_By_Efficiency(DgvHistory, "Column24");
        }

        private void Check_Ready_Job()
        {
            int row = 0;
            if (Dgv_Ready_Job.CurrentCell != null)
                row = Dgv_Ready_Job.CurrentCell.RowIndex;

            Dgv_Ready_Job.DataSource = null;
            Dgv_Ready_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_Ready_Job, 11);

            var jobs = _db.New_Jobs
                .Where(x => x.Status == "Ready")
                .OrderByDescending(x => x.Id)
                .Take(99)
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_Ready_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.OutputAmount, job.Service, job.TargetTime, Math.Round(job.ProTime, 2), job.Delivery, "Edit");
            }

            int max_row = Dgv_Ready_Job.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_Ready_Job.CurrentCell = Dgv_Ready_Job.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_Ready_Job.CurrentCell = Dgv_Ready_Job.Rows[row].Cells[3];
            }
            _common.Row_Color_By_Delivery(Dgv_Ready_Job, "Column17");
        }

        private void Check_Done_Job()
        {
            int row = 0;
            if (Dgv_QC_Job.CurrentCell != null)
                row = Dgv_QC_Job.CurrentCell.RowIndex;

            Dgv_QC_Job.DataSource = null;
            Dgv_QC_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_QC_Job, 11);

            var jobs = _db.New_Jobs
                .Where(x => x.Status == "Done")
                .OrderByDescending(x => x.Id)
                .Take(99)
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_QC_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.Service, job.TargetTime, Math.Round(job.ProTime, 2), job.Delivery);
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

        private void SI_Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            _common.Logout(_performance);
        }

        private void Tbc_CS_Panel_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    Check_Performance();
                    break;
                case 4:
                    Check_History();
                    break; 
                case 5:
                    Check_Ready_Job();
                    break;

                case 6:
                    Check_Done_Job();
                    break;
            }
        }

        private void Dgv_New_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_New_Job.Columns[Dgv_New_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                Job_assign jobAssign = new Job_assign();
                if (Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    jobAssign._job.JobId = Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    jobAssign._user = _user;
                    jobAssign.Show();
                }
            }
        }

        private void Dgv_Running_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Running_Job.Columns[Dgv_Running_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                var jobAssign = new Job_assign();
                if (Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    jobAssign._job.JobId = Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    jobAssign._user = _user;
                    jobAssign.Show();
                }
            }

            if (Dgv_Running_Job.Columns[Dgv_Running_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
            {
                var qcProcess = QC_Process.getInstance();
                if (Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    qcProcess._job.JobId = Dgv_Running_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                    QC_Process._user = _user;
                    qcProcess._performance = _performance;
                    qcProcess.Show();
                }
            }

            if (Dgv_Running_Job.Columns[Dgv_Running_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Service"))
            {
                var productivity = Productivity.getInstance();
                if (Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    productivity._jobID = Dgv_Running_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                    productivity.user = _user;
                    productivity.Show();
                }
            }
        }

        private void Dgv_QC_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_QC_Job.Columns[Dgv_QC_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
            {
                var qcProcess = QC_Process.getInstance();
                if (Dgv_QC_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    qcProcess._job.JobId = Dgv_QC_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                    QC_Process._user = _user;
                    qcProcess._performance = _performance;
                    qcProcess.Show();
                }
            }

            if (Dgv_QC_Job.Columns[Dgv_QC_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Service"))
            {
                var productivity = Productivity.getInstance();
                if (Dgv_QC_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    productivity._jobID = Dgv_QC_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                    productivity.user = _user;
                    productivity.Show();
                }
            }
        }

        private void Dgv_Performance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Performance.Columns[Dgv_Performance.CurrentCell.ColumnIndex].HeaderText.Contains("Name"))
            {
                Double_Login double_Login = new Double_Login();
                if (Dgv_Performance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    double_Login._name = Dgv_Performance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    double_Login.Show();
                }
            }
        }

        private void Btn_Workload_Click(object sender, EventArgs e)
        {
            var workload = Workload_Report.getInstance();
            workload.Show();
        }

        private void Btn_Capacity_Click(object sender, EventArgs e)
        {
            var performanceUi = Performance_UI.getInstance();
            performanceUi.Show();
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            _db = new SkillContext();
            _shift = _common.Current_Shift();
            _db.SaveChanges();
            Check_Shift_Report();
            
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

    }
}

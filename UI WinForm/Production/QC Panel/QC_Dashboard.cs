using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.Common_Panel;
using Skill_PMS.UI_WinForm.Production.Designer;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    public partial class QcDashboard : Form
    {
        private SkillContext _db = new SkillContext();
        private readonly Common _common = new Common();
        private readonly DateTime _today = DateTime.Now.Date;

        public static User _user { get; set; }
        public Performance _performance;

        public QcDashboard()
        {
            InitializeComponent();
        }

        private static QcDashboard _instance;
        private int _counter = 0;
        private string _shift;
        ShiftReport _shiftReport;

        public static QcDashboard GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new QcDashboard();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Btn_Workload_Click(object sender, EventArgs e)
        {
            //var workload = Workload_Report.getInstance();
            //workload.Show();
        }

        private void Btn_Capacity_Click(object sender, EventArgs e)
        {

        }

        private void QC_Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = @"QC Panel - " + _user.Full_Name;

            //_shift = _common.Current_Shift();
            //var date = _common.Shift_Date(DateTime.Now, _shift);
            //_shiftReport = _db.Shift_Reports.FirstOrDefault(x => x.Date == date & x.Shift == _shift & x.Team == "");

            //if (_shiftReport != null)
            //{
            //    Btn_Capacity.Text = @"Capacity: " + _shiftReport.Capacity;
            //    Btn_Workload.Text = @"Workload: " + (int)_shiftReport.TotalLoad;
            //    Btn_Achieve.Text = @"Achieve: " + (int)_shiftReport.LoadAchieve;
            //    Btn_Handload.Text = @"Handload: " + (int)_shiftReport.HandLoad;
            //    Btn_Efficiency.Text = @"Efficiency: " + _shiftReport.Efficiency + "%";
            //}
            Tbc_QC_Panel.SelectedIndex = 1;
        }

        private void Check_New_Job()
        {
            double totalWorkload = 0;
            int row = 0, sl = 1, pendingWorkload = 0, totalInput = 0;

            if (Dgv_New_Job.CurrentCell != null)
                row = Dgv_New_Job.CurrentCell.RowIndex;

            Dgv_New_Job.DataSource = null;
            Dgv_New_Job.Rows.Clear();
            _common.Dgv_Size(Dgv_New_Job, 11);

            var jobs = _db.New_Jobs.Where(x => x.Status == "New" & (x.Type == "Regular" | x.Type == "Test")).OrderBy(x => x.Delivery).ToList();
                       
            if (jobs.Find(x => x.Team == "Basic") != null)
            {
                Dgv_New_Job.Rows.Add("", "", "", "Basic Team Job Workload", "", "", "", "", "", "");

                foreach (var job in jobs)
                {
                    if (job.Team == "Basic")
                    {
                        totalInput += job.InputAmount;
                        pendingWorkload = (int)(job.InputAmount * job.ActualTime);
                        totalWorkload += pendingWorkload;
                        Dgv_New_Job.Rows.Add(sl++, job.JobId, job.Folder, job.Incoming, job.Delivery, job.InputAmount, job.ActualTime, pendingWorkload, job.Id, job.Team);
                    }
                }

                Dgv_New_Job.Rows.Add("", "", "", "", "", totalInput, "Total Workload-->", totalWorkload, "", "");
            }

            if (jobs.Find(x => x.Team == "Advance") != null)
            {
                sl = 1; totalInput = 0; totalWorkload = 0;
                Dgv_New_Job.Rows.Add("", "", "", "Advance Team Workload", "", "", "", "", "", "");

                foreach (var job in jobs)
                {
                    if (job.Team == "Advance")
                    {
                        totalInput += job.InputAmount;
                        pendingWorkload = (int)(job.InputAmount * job.ActualTime);
                        totalWorkload += pendingWorkload;
                        Dgv_New_Job.Rows.Add(sl++, job.JobId, job.Folder, job.Incoming, job.Delivery, job.InputAmount, job.ActualTime, pendingWorkload, job.Id, job.Team);
                    }
                }

                Dgv_New_Job.Rows.Add("", "", "", "", "", totalInput, "Total Workload-->", totalWorkload, "", "");
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

        private void Check_Todays_Job()
        {
            double totalWorkload = 0;
            int row = 0, sl = 1, pendingWorkload = 0, totalInput = 0, totalOutput = 0;
            DateTime Todays = DateTime.Now.Date.AddDays(1);

            if (Dgv_Todays.CurrentCell != null)
                row = Dgv_Todays.CurrentCell.RowIndex;

            Dgv_Todays.DataSource = null;
            Dgv_Todays.Rows.Clear();
            _common.Dgv_Size(Dgv_Todays, 11);

            var jobs = _db.New_Jobs.Where(x => x.Status == "Pro" & x.Delivery <= Todays).OrderBy(x => x.Delivery).ToList();

            if (jobs.Find(x => x.Team == "Basic") != null)
            {
                Dgv_Todays.Rows.Add("", "", "", "Basic Team Job Workload", "", "", "", "", "", "", "", "");

                foreach (var job in jobs)
                {
                    if (job.Team == "Basic")
                    {
                        pendingWorkload = 0;
                        if (job.InputAmount > job.ProDone)
                            pendingWorkload = (int)((job.InputAmount - job.ProDone) * job.TargetTime);

                        totalInput += job.InputAmount;
                        totalOutput += job.ProDone;
                        totalWorkload += pendingWorkload;
                        Dgv_Todays.Rows.Add(sl++, job.JobId, job.Folder, job.Incoming, job.Delivery, job.InputAmount, job.ProDone, 
                            Math.Round(job.TargetTime, 2), Math.Round(job.ProTime, 2), pendingWorkload, job.Id, job.Team);
                    }
                }

                Dgv_Todays.Rows.Add("", "", "", "", "", totalInput, totalOutput, "", "Total Workload-->", totalWorkload, "", "", "");
            }

            if (jobs.Find(x => x.Team == "Advance") != null)
            {
                sl = 1; totalInput = 0; totalOutput = 0; totalWorkload = 0;
                Dgv_Todays.Rows.Add("", "", "", "Advance Team Workload", "", "", "", "", "", "", "", "");

                foreach (var job in jobs)
                {
                    if (job.Team == "Advance")
                    {
                        pendingWorkload = 0;
                        if (job.InputAmount > job.ProDone)
                            pendingWorkload = (int)((job.InputAmount - job.ProDone) * job.TargetTime);

                        totalInput += job.InputAmount;
                        totalOutput += job.ProDone;
                        totalWorkload += pendingWorkload;
                        Dgv_Todays.Rows.Add(sl++, job.JobId, job.Folder, job.Incoming, job.Delivery, job.InputAmount, job.ProDone, 
                            Math.Round(job.TargetTime, 2), Math.Round(job.ProTime, 2), pendingWorkload, job.Id, job.Team);
                    }
                }

                Dgv_Todays.Rows.Add("", "", "", "", "", totalInput, totalOutput, "", "Total Workload-->", totalWorkload, "", "", "");
            }

            int max_row = Dgv_Todays.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_Todays.CurrentCell = Dgv_Todays.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_Todays.CurrentCell = Dgv_Todays.Rows[row].Cells[3];
            }

            _common.Row_Color_By_Delivery(Dgv_Todays, "Column13");
        }

        private void Check_Future_Job()
        {
            double totalWorkload = 0;
            int row = 0, sl = 1, pendingWorkload = 0, totalInput = 0, totalOutput = 0;
            DateTime Todays = DateTime.Now.Date.AddDays(1);

            if (Dgv_Future.CurrentCell != null)
                row = Dgv_Future.CurrentCell.RowIndex;

            Dgv_Future.DataSource = null;
            Dgv_Future.Rows.Clear();
            _common.Dgv_Size(Dgv_Future, 11);

            var jobs = _db.New_Jobs.Where(x => x.Status == "Pro" & x.Delivery > Todays).OrderBy(x => x.Delivery).ToList();

            if (jobs.Find(x => x.Team == "Basic") != null)
            {
                Dgv_Future.Rows.Add("", "", "", "Basic Team Job Workload", "", "", "", "", "", "", "", "");

                foreach (var job in jobs)
                {
                    pendingWorkload = 0;
                    if (job.InputAmount > job.ProDone)
                        pendingWorkload = (int)((job.InputAmount - job.ProDone) * job.TargetTime);

                    totalInput += job.InputAmount;
                    totalOutput += job.ProDone;
                    totalWorkload += pendingWorkload;
                    Dgv_Future.Rows.Add(sl++, job.JobId, job.Folder, job.Incoming, job.Delivery, job.InputAmount, job.ProDone, 
                        Math.Round(job.TargetTime, 2), Math.Round(job.ProTime, 2), pendingWorkload, job.Id, job.Team);
                }
                Dgv_Future.Rows.Add("", "", "", "", "", totalInput, totalOutput, "", "Total Workload-->", totalWorkload, "", "", "");
            }

            if (jobs.Find(x => x.Team == "Advance") != null)
            {
                sl = 1; totalInput = 0; totalOutput = 0; totalWorkload = 0;
                Dgv_Future.Rows.Add("", "", "", "Advance Team Job Workload", "", "", "", "", "", "", "", "");

                foreach (var job in jobs)
                {
                    pendingWorkload = 0;
                    if (job.InputAmount > job.ProDone)
                        pendingWorkload = (int)((job.InputAmount - job.ProDone) * job.TargetTime);

                    totalInput += job.InputAmount;
                    totalOutput += job.ProDone;
                    totalWorkload += pendingWorkload;
                    Dgv_Future.Rows.Add(sl++, job.JobId, job.Folder, job.Incoming, job.Delivery, job.InputAmount, job.ProDone, 
                        Math.Round(job.TargetTime, 2), Math.Round(job.ProTime, 2), pendingWorkload, job.Id, job.Team);
                }

                Dgv_Future.Rows.Add("", "", "", "", "", totalInput, totalOutput, "", "Total Workload-->", totalWorkload, "", "", "");
            }

            int max_row = Dgv_Future.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_Future.CurrentCell = Dgv_Future.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_Future.CurrentCell = Dgv_Future.Rows[row].Cells[3];
            }

            _common.Row_Color_By_Delivery(Dgv_Future, "Column9");
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
                                where per.Date == date & user.Role == ""
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

            _common.Row_Color_By_Efficiency(Dgv_Performance, "Column55");
        }

        private void Check_Production_Error()
        {
            Dgv_Production_Error.DataSource = null;
            Dgv_Production_Error.Rows.Clear();
            _common.Dgv_Size(Dgv_Production_Error, 11);

            var errors = _db.Feedback
                .OrderByDescending(x => x.Id)
                .Take(999)
                .ToList();

            var sl = 1;
            foreach (var error in errors)
                Dgv_Production_Error.Rows.Add(sl++, error.Name, error.JobId, error.Folder, error.Image, error.Remarks, error.ReportTime, error.Reporter);
            
            //_common.Row_Color_By_Efficiency(Dgv_Production_Error, "Column55");
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
                DgvHistory.Rows.Add(sl++, log.Name, log.JobId, log.Type, log.Image, log.Service, log.StartTime, log.EndTime, log.TargetTime, Math.Round(log.ProTime, 2), log.Efficiency + "%");

            _common.Row_Color_By_Efficiency(DgvHistory, "Column59");
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
                Dgv_Ready_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.OutputAmount, job.Service, job.TargetTime, job.ProTime, job.Delivery, "Edit");
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

        private void QC_Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //    _performance = _db.Performances
            //        .FirstOrDefault(x => x.Name == _user.Short_Name & x.Date == _today);
            _common.Logout(_performance);
        }

        private void Tbc_QC_Panel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Tbc_QC_Panel.SelectedIndex)
            {
                case 0:
                    Check_New_Job();
                    break;

                case 1:
                    Check_Todays_Job();
                    break;

                case 2:
                    Check_Future_Job();
                    break;

                case 3:
                    Check_Performance();
                    break;

                case 4:
                    Check_Production_Error();
                    break;

                case 5:
                    Check_History();
                    break;

                case 6:
                    Check_Ready_Job();
                    break;

                case 7:
                    break;
            }
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            _db = new SkillContext();
            _shift = _common.Current_Shift();
            _db.SaveChanges();

            var date = _common.Shift_Date(DateTime.Now, _shift);
            _shiftReport = _db.Shift_Reports.FirstOrDefault(x => x.Date == date & x.Shift == _shift & x.Team == "");

            if (_shiftReport != null)
            {
                Btn_Capacity.Text = @"Capacity: " + _shiftReport.Capacity;
                Btn_Workload.Text = @"Workload: " + (int)_shiftReport.TotalLoad;
                Btn_Achieve.Text = @"Achieve: " + (int)_shiftReport.LoadAchieve;
                Btn_Handload.Text = @"Handload: " + (int)_shiftReport.HandLoad;
                Btn_Efficiency.Text = @"Efficiency: " + _shiftReport.Efficiency + "%";
            }

            switch (Tbc_QC_Panel.SelectedIndex)
            {
                case 0:
                    Check_New_Job();
                    break;

                case 1:
                    Check_Todays_Job();
                    break;

                case 2:
                    Check_Future_Job();
                    break;

                case 3:
                    break;
            }
        }

        private void Dgv_Todays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Todays.Columns[Dgv_Todays.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                if (Dgv_Todays.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string jobId = Dgv_Todays.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    var qcProcess = QC_Process.getInstance();
                    qcProcess._job.JobId = jobId;
                    QC_Process._user = _user;
                    qcProcess._performance = _performance;
                    qcProcess.Show();

                    Tmr_Count.Stop();
                }
            }

            if (Dgv_Todays.Columns[Dgv_Todays.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
            {
                var productivity = Productivity.getInstance();
                if (Dgv_Todays.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string team = Dgv_Todays.Rows[e.RowIndex].Cells[11].Value.ToString();
                    productivity._jobID = Dgv_Todays.Rows[e.RowIndex].Cells[1].Value.ToString();
                    productivity._user = _user;
                    productivity._team = team;
                    productivity.Show();
                }
            }
        }

        private void Dtp_Date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Dgv_Future_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Future.Columns[Dgv_Future.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                if (Dgv_Future.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string jobId = Dgv_Future.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    var qcProcess = QC_Process.getInstance();
                    qcProcess._job.JobId = jobId;
                    QC_Process._user = _user;
                    qcProcess._performance = _performance;
                    qcProcess.Show();

                    Tmr_Count.Stop();
                }
            }

            if (Dgv_Future.Columns[Dgv_Future.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
            {
                var productivity = Productivity.getInstance();
                if (Dgv_Future.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string team = Dgv_Future.Rows[e.RowIndex].Cells[11].Value.ToString();

                    productivity._jobID = Dgv_Future.Rows[e.RowIndex].Cells[1].Value.ToString();
                    productivity._user = _user;
                    productivity._team = team;
                    productivity.Show();
                }
            }
        }
    }
}
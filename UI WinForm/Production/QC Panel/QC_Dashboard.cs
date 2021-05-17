using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.Common_Panel;
using Skill_PMS.UI_WinForm.Production.Designer;
using System;
using System.Linq;
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
            Tbc_QC_Panel.SelectedIndex = 2;
        }

        private static QcDashboard _instance;
        private string _shift;

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
            var workload = Workload_Report.getInstance();
            workload.Show();
        }

        private void Btn_Capacity_Click(object sender, EventArgs e)
        {

        }

        private void QC_Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = @"QC Panel - " + _user.Full_Name;
            Check_Feedback();

            var date = _common.Shift_Date(DateTime.Now, _shift);
            var shiftReport = _db.Shift_Reports
                .FirstOrDefault(x => x.Date == date & x.Shift == _shift);
            
            if (shiftReport != null)
            {
                Btn_Workload.Text = @"Workload: " + shiftReport.TotalLoad;
                Btn_Capacity.Text = @"Capacity: " + shiftReport.Capacity;
            }
            Tmr_Count.Start();
            Check_QC_Job();
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
                .Where(x => x.Status == "New" & (x.Type == "Regular" | x.Type == "Test"))
                .Take(99)
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_New_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.ActualTime, 
                    job.ActualTime * job.InputAmount, job.Incoming, job.Delivery);
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

        private void Check_Feedback()
        {
            int row = 0;
            if (Dgv_Feedback.CurrentCell != null)
                row = Dgv_Feedback.CurrentCell.RowIndex;

            Dgv_Feedback.DataSource = null;
            Dgv_Feedback.Rows.Clear();
            _common.Dgv_Size(Dgv_Feedback, 11);

            var jobs = _db.New_Jobs
                .Where(x => x.Status != "Ready" & x.Status != "Done" & x.Type != "Regular" & x.Type != "Test")
                .Take(99)
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_Feedback.Rows.Add(sl++, job.JobId, job.Folder, job.Type, job.InputAmount, job.ActualTime,
                    job.ActualTime * job.InputAmount, job.Incoming, job.Delivery);
            }

            int max_row = Dgv_Feedback.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_Feedback.CurrentCell = Dgv_Feedback.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_Feedback.CurrentCell = Dgv_Feedback.Rows[row].Cells[3];
            }
            _common.Row_Color_By_Delivery(Dgv_Feedback, "Column58");
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
                .Where(x => x.Status == "Pro" & (x.Type == "Regular" | x.Type == "Test"))
                .Take(99)
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_Running_Job.Rows.Add(sl++, job.JobId, job.Folder, job.Service, job.InputAmount, job.ProDone,
                    job.OutputAmount, job.TargetTime, Math.Round(job.ProTime, 2), job.Delivery);
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
                .Where(x => x.Status == "QC" & (x.Type == "Regular" | x.Type == "Test"))
                .OrderBy(x=>x.Delivery)
                .Take(99)
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                Dgv_QC_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.ProDone, job.OutputAmount, job.Service,
                    job.ActualTime, job.TargetTime, Math.Round(job.ProTime, 2), Math.Round(job.QcTime,2), job.Delivery, job.TargetEfficiency);
            }

            int max_row = Dgv_QC_Job.Rows.Count - 1;
            if (max_row >= 0)
            {
                Dgv_QC_Job.CurrentCell = Dgv_QC_Job.Rows[max_row].Cells[3];
                if (max_row >= row)
                    Dgv_QC_Job.CurrentCell = Dgv_QC_Job.Rows[row].Cells[3];
            }
            _common.Row_Color_By_Delivery(Dgv_QC_Job, "Column53");
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
                Dgv_QC_Job.Rows.Add(sl++, job.JobId, job.Folder, job.InputAmount, job.Service, job.TargetTime, job.ProTime, job.Delivery);
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

        private void Dgv_Running_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Running_Job.Columns[Dgv_Running_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                var qcProcess = QC_Process.getInstance();
                if (Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    qcProcess._job.JobId = Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    Tmr_Count.Stop();
                    this.Hide();
                    QC_Process._user = _user;
                    qcProcess._performance = _performance;
                    qcProcess.Show();
                }
            }

            if (Dgv_Running_Job.Columns[Dgv_Running_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
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

        private void QC_Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            _performance = _db.Performances
                .FirstOrDefault(x => x.Name == _user.Short_Name & x.Date == _today);
            _common.Logout(_performance);
        }

        private void Tbc_QC_Panel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Check_Data();
        }

        private void Check_Data()
        {
            switch (Tbc_QC_Panel.SelectedIndex)
            {
                case 0:
                    Check_New_Job();
                    break;

                case 1:
                    Check_Running_Job();
                    break;
                case 2:
                    Check_Feedback();
                    break;

                case 3:
                    Check_QC_Job();
                    break;

                case 4:
                    Check_Ready_Job();
                    break;
                case 5:
                    Check_Done_Job();
                    break;
            }
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            _db = new SkillContext();
            _shift = _common.Current_Shift();
            _db.SaveChanges();
            Check_Data();
            _common.Change_Shift();
        }

        private void Dgv_QC_Job_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_QC_Job.Columns[Dgv_QC_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                var qcProcess = QC_Process.getInstance();
                if (Dgv_QC_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    qcProcess._job.JobId = Dgv_QC_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); Tmr_Count.Stop();
                    this.Hide();
                    QC_Process._user = _user;
                    qcProcess._performance = _performance;
                    qcProcess.Show();
                }
            }

            if (Dgv_QC_Job.Columns[Dgv_QC_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
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

        private void Dgv_Feedback_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Feedback.Columns[Dgv_Feedback.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                var qcProcess = QC_Process.getInstance();
                if (Dgv_Feedback.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    qcProcess._job.JobId = Dgv_Feedback.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); Tmr_Count.Stop();
                    this.Hide();
                    QC_Process._user = _user;
                    qcProcess._performance = _performance;
                    qcProcess.Show();
                }
            }

            if (Dgv_Feedback.Columns[Dgv_Feedback.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
            {
                var productivity = Productivity.getInstance();
                if (Dgv_Feedback.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    productivity._jobID = Dgv_Feedback.Rows[e.RowIndex].Cells[1].Value.ToString();
                    productivity.user = _user;
                    productivity.Show();
                }
            }

            if (Dgv_Feedback.Columns[Dgv_Feedback.CurrentCell.ColumnIndex].HeaderText.Contains("Type"))
            {
                var qc_Job_View = QC_Job_View.getInstance();
                if (Dgv_Feedback.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    qc_Job_View._job.JobId = Dgv_Feedback.Rows[e.RowIndex].Cells[1].Value.ToString();
                    QC_Job_View._user = _user;
                    qc_Job_View.Show();
                }
            }
        }
    }
}
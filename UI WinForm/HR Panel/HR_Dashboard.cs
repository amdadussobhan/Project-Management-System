using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.Common_Panel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.HR_Panel
{
    public partial class HrDashboard : Form
    {
        private readonly SkillContext _db = new SkillContext();
        private readonly Common _common = new Common();
        private readonly DateTime _today = DateTime.Now.Date;

        public static User User { get; set; }
        public Performance Performance;

        public HrDashboard()
        {
            InitializeComponent();
        }

        private static HrDashboard _instance;
        public static HrDashboard GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new HrDashboard();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void HR_Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = @"HR Dashboard - " + User.Full_Name;

            var names = _db.Users.Select(x => x.Short_Name).Distinct();
            foreach (var name in names)
            {
                if(name != null)
                    CMB_Name.Items.Add(name);
            }

            //Btn_Workload.Text = @"Workload: " + _common.Workload();
            //Btn_Capacity.Text = @"Capacity: " + _common.Capacity();

            Check_Job();
            Load_Performance();
            Tmr_Count.Start();
        }

        private void Load_Performance()
        {
            var shift = Cmb_Shift.Text.ToLower();
            var name = CMB_Name.Text.ToLower();

            DGV_Attendence.DataSource = null;
            DGV_Attendence.Rows.Clear();
            _common.Dgv_Size(DGV_Attendence, 11);

            var performances = _db.Performances
                                .Where(x=>x.Login >= DTP_From.Value & x.Login <= DTP_To.Value)
                                .ToList();

            if (shift != "all".ToLower() & !string.IsNullOrEmpty(shift) & name != "all".ToLower() & !string.IsNullOrEmpty(name))
            {
                performances = _db.Performances
                                .Where(x=>x.Login >= DTP_From.Value & x.Login <= DTP_To.Value & x.Name == name & x.Shift == shift)                                
                                .ToList();
            }
            else if (shift != "all".ToLower() & !string.IsNullOrEmpty(shift))
            {
                performances = _db.Performances                               
                               .Where(x=>x.Login >= DTP_From.Value & x.Login <= DTP_To.Value & x.Shift == shift)                                
                               .ToList();
            }
            else if (name != "all".ToLower() & !string.IsNullOrEmpty(name))
            {
                performances = _db.Performances                               
                               .Where(x=>x.Login >= DTP_From.Value & x.Login <= DTP_To.Value & x.Name == name)
                               .ToList();
            }

            var sl = 1;
            foreach (var perform in performances)
            {
                DGV_Attendence.Rows.Add(sl++, perform.Name, perform.Login, perform.Logout, perform.WorkingTime, perform.File, perform.JobTime, Math.Round(perform.ProTime, 2), perform.Efficiency, perform.Quality);
            }

            _common.Row_Color_By_Efficiency(DGV_Attendence, "Column9");
        }

        private void Check_Job()
        {
            DGV_Job_List.DataSource = null;
            DGV_Job_List.Rows.Clear();
            _common.Dgv_Size(DGV_Job_List, 11);

            var jobs = _db.New_Jobs
                .Where(x => x.Status != "Done")
                .ToList();

            var sl = 1;
            foreach (var job in jobs)
            {
                DGV_Job_List.Rows.Add(sl++, job.JobId, job.InputAmount, job.ActualTime, Math.Round(job.ProTime, 2), job.Delivery);
            }

            _common.Row_Color_By_Delivery(DGV_Job_List, "Column14");

            var shiftReport = _db.Shift_Reports
                .FirstOrDefault(x => x.Date == _common.Shift_Date(DateTime.Now, _common.Current_Shift()) & x.Shift == _common.Current_Shift());
            if (shiftReport != null)
            {
                Btn_Workload.Text = @"Workload: " + shiftReport.TotalLoad;
                Btn_Capacity.Text = @"Capacity: " + shiftReport.Capacity;
            }
        }     


        private void HR_Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Performance = _db.Performances
                .FirstOrDefault(x => x.Name == User.Short_Name & x.Date == _today);
            _common.Logout(Performance);
        }

        private void BTN_Find_Click(object sender, EventArgs e)
        {
            Load_Performance();
        }

        private void Btn_Workload_Click(object sender, EventArgs e)
        {
            var workload = Workload_Report.getInstance();
            workload.Show();
        }

        private void Btn_Designer_Report_Click(object sender, EventArgs e)
        {
            var designerReport = Designer_Report.getInstance();
            designerReport.Show();
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            Check_Job();
            Load_Performance();
        }

        private void Btn_Performance_Click(object sender, EventArgs e)
        {
            var performanceUi = Performance_UI.getInstance();
            performanceUi.Show();
        }

        private void Btn_Capacity_Click(object sender, EventArgs e)
        {
            var performanceUi = Performance_UI.getInstance();
            performanceUi.Show();
        }
    }
}

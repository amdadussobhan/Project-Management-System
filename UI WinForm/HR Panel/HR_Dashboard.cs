using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.HR_Panel
{
    public partial class HR_Dashboard : Form
    {
        SkillContext DB = new SkillContext();
        Common Common = new Common();

        static public User user { get; set; }
        static public Attend attend = new Attend();

        public HR_Dashboard()
        {
            InitializeComponent();
        }

        private static HR_Dashboard instance;
        public static HR_Dashboard getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new HR_Dashboard();
            else
                instance.BringToFront();
            return instance;
        }

        private void HR_Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = "HR Dashboard - " + user.Full_Name;

            var names = DB.Users.Select(x => x.Short_Name).Distinct();
            foreach (var name in names)
                CMB_Name.Items.Add(name);

            Check_Job();
            Check_Attendence();
        }

        void Check_Job()
        {
            DGV_Job_List.DataSource = null;
            DGV_Job_List.Rows.Clear();
            Common.Dgv_Size(DGV_Job_List, 11);

            var Jobs = DB.Jobs
                .Where(x => x.Status != "Done")
                .ToList();

            int SL = 1;
            foreach (var Job in Jobs)
            {
                DGV_Job_List.Rows.Add(SL++, Job.JobID, Job.InputAmount, Job.Target_Time, Job.Delivery);
            }

            Common.Row_Color_By_Delivery(DGV_Job_List, "Column14");
        }

        void Check_Attendence()
        {
            DGV_Attendence.DataSource = null;
            DGV_Attendence.Rows.Clear();
            Common.Dgv_Size(DGV_Attendence, 11);

            var attends = (from at in DB.Attends
                join us in DB.Users on at.User_ID equals us.ID
                orderby at.ID
                select new
                {
                    us.Short_Name,
                    at.Login,
                    at.Logout,                         
                    at.Workingtime,                         
                    at.Amount,                         
                    at.Job_Time,                         
                    at.Pro_Time,                         
                    at.Efficiency,                         
                    at.Quality,                         
                }).ToList();

            int SL = 1;
            foreach (var attend in attends)
            {
                DGV_Attendence.Rows.Add(SL++, attend.Short_Name, attend.Login, attend.Logout, attend.Workingtime, attend.Amount, attend.Job_Time, attend.Pro_Time, attend.Efficiency, attend.Quality);
            }

            //Common.Row_Color_By_Delivery(DGV_Attendence, "Column28");
        }


        private void HR_Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Logout(attend);
        }

        private void BTN_Find_Click(object sender, EventArgs e)
        {
            DGV_Attendence.DataSource = null;
            DGV_Attendence.Rows.Clear();
            Common.Dgv_Size(DGV_Attendence, 11);

            var attends = (from at in DB.Attends
                           join us in DB.Users on at.User_ID equals us.ID
                           orderby at.ID
                           where at.Login >= DTP_From.Value & at.Login <= DTP_To.Value
                           select new
                           {
                               us.Short_Name,
                               at.Login,
                               at.Logout,
                               at.Workingtime,
                               at.Amount,
                               at.Job_Time,
                               at.Pro_Time,
                               at.Efficiency,
                               at.Quality,
                           }).ToList();

            string shift = Cmb_Shift.Text.ToLower();
            string name = CMB_Name.Text.ToLower();
            if ((shift != "all".ToLower() || !string.IsNullOrEmpty(shift)) & (name != "all".ToLower() || !string.IsNullOrEmpty(name)))
            {
                attends = (from at in DB.Attends
                               join us in DB.Users on at.User_ID equals us.ID
                               orderby at.ID
                               where at.Login >= DTP_From.Value & at.Login <= DTP_To.Value & us.Short_Name == name & at.Shift == shift
                           select new
                               {
                                   us.Short_Name,
                                   at.Login,
                                   at.Logout,
                                   at.Workingtime,
                                   at.Amount,
                                   at.Job_Time,
                                   at.Pro_Time,
                                   at.Efficiency,
                                   at.Quality,
                               }).ToList();
            }else if (shift != "all".ToLower() || !string.IsNullOrEmpty(shift))
            {
                attends = (from at in DB.Attends
                           join us in DB.Users on at.User_ID equals us.ID
                           orderby at.ID
                           where at.Login >= DTP_From.Value & at.Login <= DTP_To.Value & at.Shift == shift
                           select new
                           {
                               us.Short_Name,
                               at.Login,
                               at.Logout,
                               at.Workingtime,
                               at.Amount,
                               at.Job_Time,
                               at.Pro_Time,
                               at.Efficiency,
                               at.Quality,
                           }).ToList();
            }
            else if(name != "all".ToLower() || !string.IsNullOrEmpty(name))
            {
                attends = (from at in DB.Attends
                           join us in DB.Users on at.User_ID equals us.ID
                           orderby at.ID
                           where at.Login >= DTP_From.Value & at.Login <= DTP_To.Value & us.Short_Name == name
                           select new
                           {
                               us.Short_Name,
                               at.Login,
                               at.Logout,
                               at.Workingtime,
                               at.Amount,
                               at.Job_Time,
                               at.Pro_Time,
                               at.Efficiency,
                               at.Quality,
                           }).ToList();
            }

            int SL = 1;
            foreach (var attend in attends)
            {
                DGV_Attendence.Rows.Add(SL++, attend.Short_Name, attend.Login, attend.Logout, attend.Workingtime, attend.Amount, attend.Job_Time, attend.Pro_Time, attend.Efficiency, attend.Quality);
            }
        }
    }
}

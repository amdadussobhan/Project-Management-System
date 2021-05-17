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

namespace Skill_PMS.UI_WinForm.Common_Panel
{
    public partial class Performance_UI : Form
    {
        SkillContext DB = new SkillContext();
        Common common = new Common();

        public Performance_UI()
        {
            InitializeComponent();
        }

        private static Performance_UI instance;
        public static Performance_UI getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Performance_UI();
            else
                instance.BringToFront();
            return instance;
        }

        private void Performance_Load(object sender, EventArgs e)
        {
            DTP_From.Value = DateTime.Now.Date;
            DTP_To.Value = DateTime.Now;
            Find();
        }

        void Find()
        {
            string Shift = Cmb_Shift.Text.ToLower();
            string Name = CMB_Name.Text.ToLower();

            Dgv_Performance.DataSource = null;
            Dgv_Performance.Rows.Clear();
            common.Dgv_Size(Dgv_Performance, 11);

            var performances = (from per in DB.Performances
                                join usr in DB.Users on per.Name equals usr.Short_Name
                                orderby per.Id
                                where per.Login >= DTP_From.Value & per.Login <= DTP_To.Value & usr.Role != "CS" & usr.Role != "SI" & usr.Role != "HR" & usr.Role != "QC"
                                select new
                                {
                                    per.Name,
                                    usr.Designation,
                                    per.Login,
                                    per.Logout,
                                    per.WorkingTime,
                                    Amount = per.File,
                                    Job_Time = per.JobTime,
                                    Pro_Time = per.ProTime,
                                    per.Efficiency,
                                    per.Quality
                                }).ToList();

            if (Shift != "all".ToLower() & !string.IsNullOrEmpty(Shift) & Name != "all".ToLower() & !string.IsNullOrEmpty(Name))
            {
                performances = (from per in DB.Performances
                                join usr in DB.Users on per.Name equals usr.Short_Name
                                orderby per.Id
                                where per.Login >= DTP_From.Value & per.Login <= DTP_To.Value & usr.Short_Name == Name & per.Shift == Shift
                                select new
                                {
                                    per.Name,
                                    usr.Designation,
                                    per.Login,
                                    per.Logout,
                                    per.WorkingTime,
                                    Amount = per.File,
                                    Job_Time = per.JobTime,
                                    Pro_Time = per.ProTime,
                                    per.Efficiency,
                                    per.Quality
                                }).ToList();
            }
            else if (Shift != "all".ToLower() & !string.IsNullOrEmpty(Shift))
            {
                performances = (from per in DB.Performances
                                join usr in DB.Users on per.Name equals usr.Short_Name
                                orderby per.Id
                                where per.Login >= DTP_From.Value & per.Login <= DTP_To.Value & per.Shift == Shift & usr.Role != "CS" & usr.Role != "SI" & usr.Role != "HR" & usr.Role != "QC"
                                select new
                                {
                                    per.Name,
                                    usr.Designation,
                                    per.Login,
                                    per.Logout,
                                    per.WorkingTime,
                                    Amount = per.File,
                                    Job_Time = per.JobTime,
                                    Pro_Time = per.ProTime,
                                    per.Efficiency,
                                    per.Quality
                                }).ToList();
            }
            else if (Name != "all".ToLower() & !string.IsNullOrEmpty(Name))
            {
                performances = (from per in DB.Performances
                                join usr in DB.Users on per.Name equals usr.Short_Name
                                orderby per.Id
                                where per.Login >= DTP_From.Value & per.Login <= DTP_To.Value & usr.Short_Name == Name
                                select new
                                {
                                    per.Name,
                                    usr.Designation,
                                    per.Login,
                                    per.Logout,
                                    per.WorkingTime,
                                    Amount = per.File,
                                    Job_Time = per.JobTime,
                                    Pro_Time = per.ProTime,
                                    per.Efficiency,
                                    per.Quality
                                }).ToList();
            }

            int SL = 1;
            foreach (var perform in performances)
            {
                Dgv_Performance.Rows.Add(SL++, perform.Name, perform.Designation, perform.Login, perform.Logout, perform.WorkingTime, perform.Amount, perform.Job_Time, Math.Round(perform.Pro_Time, 2), perform.Efficiency, perform.Quality);
            }

            common.Row_Color_By_Efficiency(Dgv_Performance, "Column9");
        }

        private void BTN_Find_Click(object sender, EventArgs e)
        {
            Find();
        }
    }
}

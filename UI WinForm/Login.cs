using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.CS_Panel;
using Skill_PMS.UI_WinForm.HR_Panel;
using Skill_PMS.UI_WinForm.Production.Designer;
using Skill_PMS.UI_WinForm.Production.SI_Panel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS
{
    public partial class Login : Form
    {
        User user = new User();
        SkillContext DB = new SkillContext();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //user.Full_Name = "AMDADUS SOBHAN";
            //user.Designation = "Senior Designer";
            //user.Employee_ID = "10000017";
            //user.Short_Name = "SBN";
            //user.Shift = "Morning";
            //user.Password = "123";
            //user.Role = "";
            //DB.Users.Add(user);
            //DB.SaveChanges();

            check_user();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (Cmb_Shift.Text != "")
            {
                if (user.Password == Txt_Pss.Text)
                {
                    Attend attendence = new Attend();
                    attendence =  DB.Attends
                           .SqlQuery("Select * From attends where User_ID = ' " + user.ID + " ' and Attend_Date = ' " + DateTime.Now.Date + " ' ")
                           .FirstOrDefault<Attend>();
                    if(attendence == null) {
                        attendence = new Attend();
                        attendence.User_ID = user.ID;
                        attendence.Attend_Date = DateTime.Now.Date;
                        attendence.Login = DateTime.Now;
                        DB.Attends.Add(attendence);
                    }
                    attendence.Logout = DateTime.Now;
                    attendence.Status = "Running";
                    DB.SaveChanges();

                    if (user.Role == "CS"){
                        CS_Dashboard cs_dashboard = CS_Dashboard.getInstance();
                        CS_Dashboard.user = user;
                        CS_Dashboard.Attend = attendence;
                        cs_dashboard.Show();
                    }
                    else if (user.Role == "SI"){
                        SI_Dashboard si_dashboard = SI_Dashboard.getInstance();
                        SI_Dashboard.user = user;
                        SI_Dashboard.attend = attendence;
                        si_dashboard.Show();
                    }else if (user.Role == "HR"){
                        HR_Dashboard hr_dashboard = HR_Dashboard.getInstance();
                        HR_Dashboard.user = user;
                        HR_Dashboard.attend = attendence;
                        hr_dashboard.Show();
                    }else{
                        Dashboard dashboard = Dashboard.getInstance();
                        Dashboard.user = user;
                        Dashboard.attend = attendence;
                        dashboard.Show();
                    }
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Please select Your Working Shift", "Shift is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void check_user()
        {
            user = DB.Users
                .Where(x => x.Employee_ID == Txt_Usr.Text)
                .FirstOrDefault<User>();

            if (user != null)
            {
                Txt_Name.Text = user.Full_Name;
                Txt_Designation.Text = user.Designation;
            }
            else
            {
                Txt_Name.Text = "";
                Txt_Designation.Text = "";
            }
        }

        private void Txt_Usr_TextChanged(object sender, EventArgs e)
        {
            check_user();
        }
    }
}

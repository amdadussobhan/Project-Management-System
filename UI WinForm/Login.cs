using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.CS_Panel;
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
        User User = new User();
        SkillContext DB = new SkillContext();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            User.Full_Name = "AMDADUS SOBHAN";
            User.Designation= "IT Executive";
            User.Employee_ID= "10000015";
            User.Short_Name= "SBN";
            User.Shift = "Morning";
            User.Password = "123";
            User.Role = "CS";
            //DB.Users.Add(User);
            //DB.SaveChanges();

            check_user();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (Cmb_Shift.Text != "")
            {
                if (User.Password == Txt_Pss.Text)
                {
                    Attend attendence = new Attend();
                    attendence =  DB.Attends
                           .SqlQuery("Select * From attends where User_ID = ' " + User.ID + " ' and Attend_Date = ' " + DateTime.Now.Date + " ' ")
                           .FirstOrDefault<Attend>();
                    if(attendence == null) {
                        attendence = new Attend();
                        attendence.User = User;
                        attendence.Attend_Date = DateTime.Now.Date;
                        attendence.Login = DateTime.Now;
                        DB.Attends.Add(attendence);
                    }
                    attendence.Logout = DateTime.Now;
                    attendence.Status = "Running";
                    DB.SaveChanges();

                    if (User.Role == "CS")
                    {
                        Dashboard dashboard = new Dashboard();
                        Dashboard.User = User;
                        Dashboard.Attend = attendence;
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
            string user_txt = Txt_Usr.Text;
            if (user_txt != null & user_txt != "" & user_txt != " ")
            {
                if (User.Employee_ID == user_txt)
                {
                    User = DB.Users
                        .Where(s => s.Employee_ID == user_txt)
                        .FirstOrDefault<User>();

                    Txt_Name.Text = User.Full_Name;
                    Txt_Designation.Text = User.Designation;
                }
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

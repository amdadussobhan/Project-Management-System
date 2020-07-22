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
            user.Full_Name = "AMDADUS SOBHAN";
            user.Employee_ID= "10000015";
            user.Short_Name= "SBN";
            user.Shift = "Morning";
            user.Password = "123";
            user.Role = "CS";

            check_user();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (Cmb_Shift.Text != "")
            {
                if (user.Password == Txt_Pss.Text)
                {
                    Add_Job add_job = new Add_Job(user);

                    Attendence attendence = new Attendence();
                    attendence.User = user.ID;
                    attendence.Date= DateTime.Now.Date;
                    attendence.Login = DateTime.Now;
                    attendence.Logout = DateTime.Now;
                    attendence.Status = "Running";
                    DB.Attendences.Add(attendence);
                    DB.SaveChanges();

                    add_job.Show();
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
                if (user.Employee_ID == user_txt)
                {
                    user = DB.Users.Find(Convert.ToDouble(Txt_Usr.Text)); 
                    Txt_Name.Text = user.Full_Name;
                    Txt_Designation.Text = user.Designation;
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

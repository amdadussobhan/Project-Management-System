using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.CS_Panel
{
    public partial class Dashboard : Form
    {
        SkillContext DB = new SkillContext();
        static public User User { get; set; }
        static public Attend Attend = new Attend();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = User.Full_Name;
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Attend.Logout = DateTime.Now;
            Attend.Status = "Logout";
            Attend.Workingtime =  Convert.ToInt32((Attend.Logout - Attend.Login).TotalMinutes);
            DB.Attends.AddOrUpdate(Attend);
            DB.SaveChanges();
            Application.Exit();
        }

        private void Btn_Add_New_Job_Click(object sender, EventArgs e)
        {
            Add_Job add_Job = new Add_Job();
            add_Job.Show();
        }
    }
}

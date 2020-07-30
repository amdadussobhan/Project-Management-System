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

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class Dashboard : Form
    {
        Common Common = new Common();
        SkillContext DB = new SkillContext();

        static public User user { get; set; }
        static public Attend attend = new Attend();

        public Dashboard()
        {
            InitializeComponent();
            Tbc_Designer.SelectedIndex = 1;
        }

        private void BTN_Performance_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Efficiency_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Pro_Time_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Leave_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = "SI Panel - " + user.Full_Name;
            Check_New_Job();
        }

        void Check_New_Job()
        {
            Dgv_New_Job.DataSource = null;
            Dgv_New_Job.Rows.Clear();
            Common.Dgv_Size(Dgv_New_Job, 11);

            var Jobs = DB.Jobs
                .Where(x => x.Status == "Pro")
                .ToList();

            int SL = 1;
            foreach (var Job in Jobs)
            {
                Dgv_New_Job.Rows.Add(SL++, Job.JobID, Job.Folder, Job.Category, Job.Service, Job.Target_Time, Job.InputAmount, Job.Delivery);
            }

            Common.Row_Color_By_Delivery(Dgv_New_Job, "Column28");
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Logout(attend);
        }

        private void Dgv_New_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_New_Job.Columns[Dgv_New_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                Processing processing = new Processing();
                if (Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    processing.job.JobID = Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                if (!String.IsNullOrWhiteSpace(Dgv_New_Job.CurrentCell.EditedFormattedValue.ToString()))
                {
                    processing.user = user;
                    processing.Show();
                }
            }
        }
    }
}

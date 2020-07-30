using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    public partial class SI_Dashboard : Form
    {
        SkillContext DB = new SkillContext();
        Common Common = new Common();

        static public User user { get; set; }
        static public Attend attend = new Attend();

        public SI_Dashboard()
        {
            InitializeComponent();
        }

        private static SI_Dashboard instance;
        public static SI_Dashboard getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new SI_Dashboard();
            else
                instance.BringToFront();
            return instance;
        }

        private void SI_Dashboard_Load(object sender, EventArgs e)
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
                .Where(x => x.Status == "New")
                .ToList();

            int SL = 1;
            foreach (var Job in Jobs)
            {
                Dgv_New_Job.Rows.Add(SL++, Job.JobID, Job.Folder, Job.InputAmount, Job.Actual_Time, Job.Actual_Time * Job.InputAmount, Job.Incoming, Job.Delivery);
            }

            Common.Row_Color_By_Delivery(Dgv_New_Job, "Column28");
        }

        void Check_Running_Job()
        {
            Dgv_Running_Job.DataSource = null;
            Dgv_Running_Job.Rows.Clear();
            Common.Dgv_Size(Dgv_Running_Job, 11);

            var Jobs = DB.Jobs
                .Where(x => x.Status == "Pro")
                .ToList();

            int SL = 1;
            foreach (var Job in Jobs)
            {
                Dgv_Running_Job.Rows.Add(SL++, Job.JobID, Job.Folder, Job.InputAmount, Job.Pro_Done, Job.Service, Job.Target_Time, Job.Pro_Time, Job.Delivery);
            }

            Common.Row_Color_By_Delivery(Dgv_Running_Job, "Column33");
        }

        void Check_QC_Job()
        {
            Dgv_QC_Job.DataSource = null;
            Dgv_QC_Job.Rows.Clear();
            Common.Dgv_Size(Dgv_QC_Job, 11);

            var Jobs = DB.Jobs
                .Where(x => x.Status == "QC")
                .ToList();

            int SL = 1;
            foreach (var Job in Jobs)
            {
                Dgv_QC_Job.Rows.Add(SL++, Job.JobID, Job.Folder, Job.InputAmount, Job.Pro_Done, Job.OutputAmount, Job.Service, Job.Target_Time, Job.Pro_Time, Job.Delivery, "Edit");
            }

            Common.Row_Color_By_Delivery(Dgv_QC_Job, "Column9");
        }

        void Check_Ready_Job()
        {
            Dgv_Ready_Job.DataSource = null;
            Dgv_Ready_Job.Rows.Clear();
            Common.Dgv_Size(Dgv_Ready_Job, 11);

            var Jobs = DB.Jobs
                .Where(x => x.Status == "Ready")
                .ToList();

            int SL = 1;
            foreach (var Job in Jobs)
            {
                Dgv_Ready_Job.Rows.Add(SL++, Job.JobID, Job.Folder, Job.InputAmount, Job.OutputAmount, Job.Service, Job.Target_Time, Job.Pro_Time, Job.Delivery, "Edit");
            }

            Common.Row_Color_By_Delivery(Dgv_Ready_Job, "Column9");
        }

        void Check_Done_Job()
        {
            Dgv_QC_Job.DataSource = null;
            Dgv_QC_Job.Rows.Clear();
            Common.Dgv_Size(Dgv_QC_Job, 11);

            var Jobs = DB.Jobs
                .Where(x => x.Status == "Done")
                .ToList();

            int SL = 1;
            foreach (var Job in Jobs)
            {
                Dgv_QC_Job.Rows.Add(SL++, Job.JobID, Job.Folder, Job.InputAmount, Job.Service, Job.Target_Time, Job.Pro_Time, Job.Delivery, "Edit");
            }

            Common.Row_Color_By_Delivery(Dgv_QC_Job, "Column9");
        }

        private void SI_Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Logout(attend);
        }

        private void Tbc_CS_Panel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Tbc_CS_Panel.SelectedIndex)
            {
                case 0:
                    Check_New_Job();
                    break;

                case 1:
                    Check_Running_Job();
                    break;
                case 2:
                    Check_QC_Job();
                    break;

                case 3:
                    Check_Ready_Job();
                    break;

                case 4:
                    Check_Done_Job();
                    break;
            }
        }

        private void Dgv_New_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_New_Job.Columns[Dgv_New_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                Job_assign job_assign = new Job_assign();
                if (Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    job_assign.job.JobID = Dgv_New_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                if (!String.IsNullOrWhiteSpace(Dgv_New_Job.CurrentCell.EditedFormattedValue.ToString()))
                {
                    job_assign.user = user;
                    job_assign.Show();
                }
            }
        }

        private void Dgv_Running_Job_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Running_Job.Columns[Dgv_Running_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Job_ID"))
            {
                Job_assign job_assign = new Job_assign();
                if (Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    job_assign.job.JobID = Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                if (!String.IsNullOrWhiteSpace(Dgv_Running_Job.CurrentCell.EditedFormattedValue.ToString()))
                {
                    job_assign.user = user;
                    job_assign.Show();
                }
            }

            if (Dgv_Running_Job.Columns[Dgv_Running_Job.CurrentCell.ColumnIndex].HeaderText.Contains("Folder"))
            {
                Productivity view_productivity = Productivity.getInstance();
                if (Dgv_Running_Job.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    view_productivity.job.JobID = Dgv_Running_Job.Rows[e.RowIndex].Cells[1].Value.ToString();
                }

                if (!String.IsNullOrWhiteSpace(Dgv_Running_Job.CurrentCell.EditedFormattedValue.ToString()))
                {
                    Productivity.user = user;
                    view_productivity.Show();
                }
            }
        }
    }
}

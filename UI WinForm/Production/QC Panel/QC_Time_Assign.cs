using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    public partial class QC_Time_Assign : Form
    {
        public QC_Time_Assign()
        {
            InitializeComponent();
        }

        private static QC_Time_Assign instance;
        public static QC_Time_Assign getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new QC_Time_Assign();
            else
                instance.BringToFront();
            return instance;
        }

        public User User { get; set; }
        SkillContext _db = new SkillContext();
        public NewJob _job = new NewJob();

        private void QC_Time_Assign_Load(object sender, EventArgs e)
        {
            this.Text = "QC Time assign - " + User.Full_Name;
            _job = _db.New_Jobs.FirstOrDefault(x => x.JobId == _job.JobId);

            Lbl_Job_ID.Text = _job.JobId;
            Lbl_Actual_Time.Text = _job.ActualTime + "";
            Lbl_Target_Time.Text = _job.TargetTime + "";
            Lbl_Delivery.Text = _job.Delivery.ToString("ddd dd-MMM hh:mm tt");
            Txt_Location.Text = _job.WorkingLocation + "";
            Txt_QC.Text = _job.QcTime + "";
            Txt_Folder.Text = _job.Folder + "";
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Txt_Location.Text))
            {
                MessageBox.Show(@"Invalid Location Entered.!!! Please Enter Correct Folder Location", @"Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(Txt_QC.Text) | Txt_QC.Text == "0")
            {
                MessageBox.Show(@"QC Time is empty.!!! Please enter actual QC time", @"QC Time is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--Update Job Table

            _job.QcTime = Convert.ToDouble(Txt_QC.Text);
            _job.WorkingLocation = Txt_Location.Text;
            _job.Up = 0;

            _db.SaveChanges();
            this.Close();
        }

        private void Btn_Ready_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Open_Folder_Click(object sender, EventArgs e)
        {
            string location = Txt_Location.Text;
            if (Directory.Exists(location))
                Process.Start(location);
            else
                MessageBox.Show(@"Folder doesn't Exist. Please Enter Correct Location...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

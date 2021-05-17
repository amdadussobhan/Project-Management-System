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
    public partial class QC_Job_View : Form
    {
        readonly SkillContext _db = new SkillContext();
        public NewJob _job = new NewJob();
        public static User _user { get; set; }

        public QC_Job_View()
        {
            InitializeComponent();
        }

        private static QC_Job_View instance;
        public static QC_Job_View getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new QC_Job_View();
            else
                instance.BringToFront();
            return instance;
        }

        private void Btn_Open_Click(object sender, EventArgs e)
        {
            string location = _job.WorkingLocation;
            if (Directory.Exists(location))
                Process.Start(location);
            else
                MessageBox.Show(@"Folder doesn't Exist. Please Enter Correct Location...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void QC_Job_Viewcs_Load(object sender, EventArgs e)
        {
            _job = _db.New_Jobs
                .Where(x => x.JobId == _job.JobId)
                .FirstOrDefault<NewJob>();

            Lbl_Job_ID.Text = _job.JobId;
            Lbl_Incoming.Text = _job.Incoming.ToString("ddd  dd-MM-yy  hh:mm tt");
            Lbl_Delivery.Text = _job.Delivery.ToString("ddd  dd-MM-yy  hh:mm tt");
            Lbl_Amount.Text = _job.InputAmount + "";
            Lbl_Actual_Time.Text = _job.ActualTime + "";
            Lbl_Target_Time.Text = Math.Round(_job.TargetTime, 2)+ "";
            Lbl_Total_Time.Text = Math.Round(_job.InputAmount * _job.TargetTime, 2) + "";
            Lbl_Service.Text = _job.Service;
            Cmb_Type.Text = _job.Type;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            _job.Type = Cmb_Type.Text;
            _job.Remarks = Txt_Remarks.Text;
            _db.SaveChanges();
            this.Close();
        }
    }
}

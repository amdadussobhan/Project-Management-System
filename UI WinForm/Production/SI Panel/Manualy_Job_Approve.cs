using Microsoft.SqlServer.Management.Smo.Agent;
using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.Production.Designer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    public partial class Manualy_Job_Approve : Form
    {
        public User _user { get; set; }
        public int _logId;
        private Log _log;
        SkillContext _db = new SkillContext();

        public Manualy_Job_Approve()
        {
            InitializeComponent();
        }

        private static Manualy_Job_Approve _instance;

        public static Manualy_Job_Approve GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Manualy_Job_Approve();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Btn_Approve_Click(object sender, EventArgs e)
        {
            var targetTime=Convert.ToDouble(Txt_Target_Time.Text);

            if (targetTime < 0)
            {
                MessageBox.Show(@"Image time is empty. Please enter image time first...", @"Image time is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _log.TargetTime = targetTime;
            _log.Status = "Done";
            _log.Remarks = "Reason:" + _log.Remarks + "_approved_by_" + _user.Short_Name;
            _log.Up = 0;

            var efficiency = 0;
            if (_log.ProTime != 0)
                efficiency = (int)(_log.TargetTime / _log.ProTime * 100);

            _log.Efficiency = efficiency;
            _db.SaveChanges();
            this.Close();
        }

        private void Btn_Reject_Click(object sender, EventArgs e)
        {
            _log.Status = "Reject";
            _log.Remarks = "Reason:" + _log.Remarks + "_rejected_by_" + _user.Short_Name;
            _db.SaveChanges();
            this.Close();
        }

        private void Manualy_Job_Approve_Load(object sender, EventArgs e)
        {
            _log = _db.Logs.FirstOrDefault(x => x.Id == _logId);

            Txt_Target_Time.Text = _log.TargetTime+"";
            Txt_File.Text = _log.Image;
            Txt_Reason.Text = _log.Remarks;
            Cmb_JobID.Text = _log.JobId;

            Dtp_Start_Time.Value = _log.StartTime;
            Dtp_End_Time.Value = _log.EndTime;

            if (_log.Service.Contains("CP"))
                Chk_Clipping_Path.Checked = true;

            if (_log.Service.Contains("RET"))
                Chk_Clipping_Path.Checked = true;

            if (_log.Service.Contains("Pre"))
                Chk_Clipping_Path.Checked = true;

            if (_log.Service.Contains("Post"))
                Chk_Clipping_Path.Checked = true;
        }
    }
}

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
using ZstdSharp.Unsafe;

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class Leave_Apply : Form
    {
        private SkillContext _db = new SkillContext();

        public User _user { get; set; }

        public Leave_Apply()
        {
            InitializeComponent();
        }

        private static Leave_Apply _instance;

        public static Leave_Apply GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Leave_Apply();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Leave_Apply_Load(object sender, EventArgs e)
        {
            Dtp_Start_Date.Value = Dtp_End_Date.Value = DateTime.Now;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            string leave_type = Cmb_Leave_Type.Text;

            if (string.IsNullOrEmpty(leave_type))
            {
                MessageBox.Show(@"Leave Type Empty.!!! Please select a Leave type first", @"Leave Type Empty.!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Dtp_Start_Date.Value > Dtp_End_Date.Value)
            {
                MessageBox.Show(@"Invalid Time.!!! Start Time or End Time Invalid", @"Invalid Time.!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string leave_reason = Txt_Reason.Text;

            if (string.IsNullOrEmpty(leave_reason))
            {
                MessageBox.Show(@"Leave Reason Empty.!!! Please write leave reason properly", @"Leave Reason Empty.!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taskTime = (Dtp_End_Date.Value - Dtp_Start_Date.Value).Days;

            while (taskTime >= 0)
            {
                var leave = new Leave
                {
                    Name = _user.Short_Name,
                    Reason = leave_reason,
                    Type = leave_type,
                    Status = "Pending",
                    Apply_Date = DateTime.Now.Date,
                    Leave_Date = Dtp_Start_Date.Value,
                    HR_Status = false,
                    PM_Status = false,
                    SI_Status = false,
                    Up = false,
                };

                _db.Leave.Add(leave);
                Dtp_Start_Date.Value = Dtp_Start_Date.Value.AddDays(1); 
                taskTime--;
            }

            _db.SaveChanges();

            this.Close();
        }
    }
}

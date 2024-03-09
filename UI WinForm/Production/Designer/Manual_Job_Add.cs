using Microsoft.SqlServer.Management.Smo.Agent;
using Skill_PMS.Controller;
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

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class Manual_Job_Add : Form
    {
        SkillContext _db = new SkillContext();
        private readonly Common _common = new Common();
        public Performance _performance = new Performance();
        private ImageTime _imageTime;
        public NewJob _job = new NewJob();
        private string _myService = "";
        private double _myTime = 0;

        public Manual_Job_Add()
        {
            InitializeComponent();
        }

        private static Manual_Job_Add _instance;

        public static Manual_Job_Add GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Manual_Job_Add();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manual_Job_Add_Load(object sender, EventArgs e)
        {
            Dtp_Start_Time.Value = Dtp_End_Time.Value = DateTime.Now;

            _performance = _db.Performances.FirstOrDefault(x => x.Id == _performance.Id);
            var jobIds = _db.New_Jobs.OrderByDescending(x => x.Id).Take(999).Select(x => x.JobId);
            foreach (var job in jobIds)
                Cmb_JobID.Items.Add(job);

            Check_Service();
        }

        private void Check_Service()
        {
            _job = _db.New_Jobs.FirstOrDefault(x => x.JobId == Cmb_JobID.Text);

            if (_job != null)
            {
                _imageTime = _db.ImageTime.FirstOrDefault(x => x.Job_ID == _job.JobId);

                if (_imageTime != null)
                {
                    if (_imageTime.Clipping_Time > 0)
                        Chk_Clipping_Path.Enabled = true;
                    else
                        Chk_Clipping_Path.Enabled = false;

                    if (_imageTime.Basic_Time > 0)
                        Chk_Basic_Process.Enabled = true;
                    else
                        Chk_Basic_Process.Enabled = false;

                    if (_imageTime.Pre_Process > 0)
                        Chk_Pre_Process.Enabled = true;
                    else
                        Chk_Pre_Process.Enabled = false;

                    if (_imageTime.Post_Process > 0)
                        Chk_Post_Process.Enabled = true;
                    else
                        Chk_Post_Process.Enabled = false;
                }
            }
        }

        private void Generate_Service()
        {
            _myService = "";
            _myTime = 0;

            if (Chk_Clipping_Path.Checked)
            {
                _myService += "CP+";
                _myTime += _imageTime.Clipping_Time;
            }

            if (Chk_Basic_Process.Checked)
            {
                _myService += "B_RET+";
                _myTime += _imageTime.Basic_Time;
            }

            if (Chk_Pre_Process.Checked)
            {
                _myService += "Pre_Pro+";
                _myTime += _imageTime.Post_Process;
            }

            if (Chk_Post_Process.Checked)
            {
                _myService += "Post_Pro+";
                _myTime += _imageTime.Clipping_Time;
            }

            _myService = _myService.TrimEnd('+');
            Txt_Target_Time.Text = _myTime + "";
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (_job == null)
            {
                MessageBox.Show(@"Job ID is empty. Please select actual Job ID first...", @"Job ID is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Dtp_Start_Time.Value == Dtp_End_Time.Value)
            {
                MessageBox.Show(@"Start or End Time invalid. Please select actual Time...", @"Start Time or End Time invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_myService == "")
            {
                MessageBox.Show(@"Service not selected. Please select all services that you done...", @"Service is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Txt_File.Text == "")
            {
                MessageBox.Show(@"Image Name is empty. Please enter image name first...", @"Image Name is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Txt_Reason.Text == "")
            {
                MessageBox.Show(@"Reason is empty. Please describe the reason...", @"Reason is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_performance.Date != Dtp_Start_Time.Value.Date)
            {
                MessageBox.Show(@"Don't try to entry without today's work...", @"Not allow to entry without today's work", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Log log = new Log
            {
                JobId = _job.JobId,
                Image = Txt_File.Text,
                TargetTime = _myTime,
                Service = _myService,
                Shift = _performance.Shift,
                StartTime = Dtp_Start_Time.Value,
                EndTime = Dtp_End_Time.Value,
                Name = _performance.Name,
                Remarks = Txt_Reason.Text,
                Status = "Pending"
            };

            log.Date = _common.Shift_Date(Dtp_Start_Time.Value, log.Shift);
            log.ProTime = (Dtp_End_Time.Value - Dtp_Start_Time.Value).TotalMinutes;

            _db.Logs.Add(log);
            _db.SaveChanges();
            this.Close();
        }

        private void Chk_Clipping_Path_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_Basic_Process_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_Pre_Process_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_Post_Process_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Cmb_JobID_SelectedValueChanged(object sender, EventArgs e)
        {
            Check_Service();
        }
    }
}

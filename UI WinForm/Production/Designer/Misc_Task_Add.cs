using Babel;
using Microsoft.SqlServer.Management.Smo.Agent;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class Misc_Task_Add : Form
    {
        private SkillContext _db = new SkillContext();
        Dashboard _dashboard = Dashboard.GetInstance();
        Misc_Task _miscTask;
        string _taskType = "";
        DateTime _taskStart;

        public User _user { get; set; }

        public Misc_Task_Add()
        {
            InitializeComponent();
        }

        private static Misc_Task_Add _instance;

        public static Misc_Task_Add GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Misc_Task_Add();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Misc_Task_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            var taskTime = Math.Round((DateTime.Now - _taskStart).TotalMinutes);

            _miscTask.End_Time = DateTime.Now;
            _miscTask.Status = "Approved";
            _miscTask.Time = taskTime;
            _miscTask.Up = false;

            _db.SaveChanges();
            this.Close();

            _dashboard.Enabled = true;
            _dashboard.Check_Misc_Task();
            _dashboard.Check_Data();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Clear_data();
        }

        private void Clear_data()
        {
            Rdb_Training.Enabled = true;
            Rdb_Prayer.Enabled = true;
            Rdb_Meeting.Enabled = true;
            Rdb_Instruction_Brief.Enabled = true;
            Rdb_Lunch.Enabled = true;
            Rdb_Snacks.Enabled = true;
            Rdb_Others.Enabled = true;

            Txt_Reason.Enabled = true;
            Txt_Reason.Text = "";

            Rdb_Training.Checked = false;
            Rdb_Prayer.Checked = false;
            Rdb_Meeting.Checked = false;
            Rdb_Instruction_Brief.Checked = false;
            Rdb_Lunch.Checked = false;
            Rdb_Snacks.Checked = false;
            Rdb_Others.Checked = false;

            Btn_Start.Visible = true;
            Btn_Save.Visible = false;
            Tmr_Count.Stop();

            Lbl_Time_Count.Text = "";
            _dashboard.Enabled = true;

            if (_miscTask != null)
            {
                _db.Misc_Task.Remove(_miscTask);
                _db.SaveChanges();
            }

            _dashboard.Check_Misc_Task();
        }

        private void Rdb_Training_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_Training.Checked)
                _taskType = "Training";
            else
                _taskType = "";
        }

        private void Rdb_Prayer_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_Prayer.Checked)
                _taskType = "Prayer";
            else
                _taskType = "";
        }

        private void Rdb_Instruction_Brief_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_Instruction_Brief.Checked)
                _taskType = "Instruction_Brief";
            else
                _taskType = "";
        }

        private void Rdb_Lunch_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_Lunch.Checked)
                _taskType = "Lunch";
            else
                _taskType = "";
        }

        private void Rdb_Snacks_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_Snacks.Checked)
                _taskType = "Snacks";
            else
                _taskType = "";
        }

        private void Rdb_Meeting_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_Meeting.Checked)
                _taskType = "Meeting";
            else
                _taskType = "";
        }

        private void Rdb_Others_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_Others.Checked)
                _taskType = "Others";
            else
                _taskType = "";
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_taskType))
            {
                MessageBox.Show(@"Task Type Empty.!!! Please select a task type first", @"Task Type Empty.!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Rdb_Others.Checked)
            {
                if (string.IsNullOrEmpty(Txt_Reason.Text))
                {
                    MessageBox.Show(@"Task Reason Empty.!!! Please write your task reason", @"Task Reason Empty.!!! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _taskStart = DateTime.Now;
            Tmr_Count.Start();
            Btn_Start.Visible = false;
            Btn_Save.Visible = true;

            Rdb_Training.Enabled = false;
            Rdb_Prayer.Enabled = false;
            Rdb_Meeting.Enabled = false;
            Rdb_Instruction_Brief.Enabled = false;
            Rdb_Lunch.Enabled = false;
            Rdb_Snacks.Enabled = false;
            Rdb_Others.Enabled = false;

            Txt_Reason.Enabled = false;
            _dashboard.Enabled = false;

            _miscTask = new Misc_Task
            {
                Name = _user.Short_Name,
                Start_Time = _taskStart,
                End_Time = _taskStart,
                Apply_Time = DateTime.Now.Date,
                Type = _taskType,
                Reason = Txt_Reason.Text,
                Status = "Running",
                SI_Status = false,
                Up = false,
            };

            _db.Misc_Task.Add(_miscTask);
            _db.SaveChanges();

            _dashboard.Check_Misc_Task();
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            Lbl_Time_Count.Text = (DateTime.Now - _taskStart).ToString(@"mm\:ss");
        }

        private void Misc_Task_Add_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clear_data();
        }
    }
}
using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    public partial class Job_assign : Form
    {
        public User User { get; set; }
        SkillContext _db = new SkillContext();
        private readonly Common _common = new Common();
        public NewJob _job = new NewJob();
        public Sub_Folder _subFolder;
        private Job_assign instance;
        private Assign_Time _assignTime;
        public int _runningJobsId;
        double _jobTime = 0, _clipping = 0, _pre_process= 0, _post_process = 0, _basic = 0;
        string _type;

        public Job_assign()
        {
            InitializeComponent();
        }

        public Job_assign getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Job_assign();
            else
                instance.BringToFront();
            return instance;
        }

        private void Btn_Subfolder_Click(object sender, EventArgs e)
        {
            Btn_Save.Enabled = false;
            string Loc = Txt_Location.Text;
            Loc = Merge_Folder(Loc);
            if (!string.IsNullOrEmpty(Loc))
            {
                Txt_Location.Text = Loc;
                Btn_Subfolder.Enabled = false;
            }
            Btn_Save.Enabled = true;
        }

        public string Merge_Folder(string Loc)
        {
            if (!string.IsNullOrEmpty(Loc) & Directory.Exists(Loc))
            {
                string[] files = Directory.GetFiles(Loc, "*", SearchOption.AllDirectories);
                Loc += @"\Images";
                Directory.CreateDirectory(Loc);
                //Prb_FolderTime.Value = 0;
                //Prb_FolderTime.Maximum = files.Count();
                foreach (string file_path in files)
                {
                    string ext = Path.GetExtension(file_path);
                    string Old_Name = Path.GetFileNameWithoutExtension(file_path);
                    string F_Name = new DirectoryInfo(Path.GetDirectoryName(file_path)).Name;
                    string New_Name = F_Name + "_" + Old_Name;

                a:
                    string Des_File = Path.Combine(Loc, New_Name + ext);
                    if (File.Exists(Des_File))
                    {
                        New_Name += New_Name + "_";
                        goto a;
                    }
                    File.Move(file_path, Des_File);

                    _subFolder = _db.Sub_Folders.FirstOrDefault(x => x.Job_ID == _job.JobId & x.Old_Name == Old_Name);

                    if (_subFolder == null)
                    {
                        _subFolder = new Sub_Folder
                        {
                            Job_ID = _job.JobId,
                            Old_Name = Old_Name,
                            Created = DateTime.Now,
                        };

                        _db.Sub_Folders.Add(_subFolder);
                    }

                    _subFolder.Path = file_path;
                    _subFolder.New_Name = New_Name;
                    _subFolder.Updated = DateTime.Now;
                    //Prb_FolderTime.Increment(1);
                }
                _db.SaveChanges();
                MessageBox.Show(@"Successfully Saved Sub Folder Please check this Folder ", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return Loc;
            }
            else
                MessageBox.Show(@"Folder Location maybe Empty. Please Enter correct folder Location", @"Invalid Folder Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void Rdb_PSD_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_PSD.Checked)
                _job.Format = ".psd";
        }

        private void Rdb_JPG_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_JPG.Checked)
                _job.Format = ".jpg";
        }

        private void Rdb_PNG_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_PNG.Checked)
                _job.Format = ".png";
        }

        private void Rdb_TIF_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_TIF.Checked)
                _job.Format = ".tif";
        }

        private void Btn_assign_Click(object sender, EventArgs e)
        {
            Assign_Time();
        }

        private void Txt_Clipping_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_Clipping.Text))
                _clipping = Convert.ToInt32(Txt_Clipping.Text);
            else
                _clipping = 0;

            Time_Calculate();
        }

        private void Txt_Basics_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_Basics.Text))
                _basic = Convert.ToInt32(Txt_Basics.Text);
            else
                _basic = 0;

            Time_Calculate();
        }

        private void Cmb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            _type = Cmb_Type.Text;
            Check_Time();
        }

        private void Check_Time()
        {
            _assignTime = _db.Assign_Time.FirstOrDefault(x => x.Client == _job.Client & x.Type == _type);

            if (_assignTime != null)
            {
                Txt_Clipping.Text = _assignTime.Clipping_Time + "";
                Txt_Basics.Text = _assignTime.Basic_Time + "";
                Txt_Pre_Process.Text = _assignTime.Pre_Process + "";
                Txt_Post_Process.Text = _assignTime.Post_Process + "";
            }
            else
            {
                Txt_Clipping.Text = "";
                Txt_Basics.Text = "";
                Txt_Pre_Process.Text = "";
                Txt_Post_Process.Text = "";
            }
        }

        private void Txt_Pre_Process_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_Pre_Process.Text))
                _pre_process = Convert.ToInt32(Txt_Pre_Process.Text);
            else
                _pre_process = 0;

            Time_Calculate();
        }

        private void Txt_Post_Process_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_Post_Process.Text))
                _post_process = Convert.ToInt32(Txt_Post_Process.Text);
            else
                _post_process = 0;

            Time_Calculate();
        }

        private void Time_Calculate()
        {
            _jobTime = _clipping + _basic + _pre_process + _post_process;
            Lbl_Target_Time.Text = _jobTime + "";

            Txt_QC.Text = _jobTime * 0.1 + "";
        }

        public void Assign_Time()
        {
            if (Job_Validated())
            {
                var timeAssign = Time_assign.GetInstance();
                timeAssign._loc = Txt_Location.Text;
                timeAssign._team = Cmb_Team.Text;
                timeAssign._type = _type;
                timeAssign._jobId = _job.JobId;
                timeAssign._jobTime = _jobTime;
                timeAssign._clipping = _clipping;
                timeAssign._basic = _basic;
                timeAssign._pre_process = _pre_process;
                timeAssign._post_process = _post_process;

                timeAssign.Show();
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool Job_Validated()
        {
            if (!Directory.Exists(Txt_Location.Text))
            {
                MessageBox.Show(@"Invalid Location Entered.!!! Please Enter Correct Folder Location", @"Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(Cmb_Team.Text))
            {
                MessageBox.Show(@"Job Team is empty.!!! Please Select a Job Team", @"Job Team is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(_type))
            {
                MessageBox.Show(@"Job Type is empty.!!! Please Select Correct Job Type", @"Job Type is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_jobTime == 0)
            {
                MessageBox.Show(@"Job Time is empty.!!! Please Enter Proper Job Time", @"Job Time is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (Job_Validated())
            {
                if (string.IsNullOrEmpty(Txt_File.Text))
                {
                    MessageBox.Show(@"Job File is empty.!!! Please enter actual job file count", @"Job File is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(Txt_QC.Text))
                {
                    MessageBox.Show(@"QC Time is empty.!!! Please enter actual QC time", @"QC Time is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(_job.Format))
                {
                    MessageBox.Show(@"File format can't be empty.!!! Please Select a file format", @"File format is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var count = _db.ImageTime.Where(x => x.Job_ID == _job.JobId & x.Type == _type).Count();
                if (count == 0)
                    Assign_Time();

                //--Update Job Table
                _job.Team = Cmb_Team.Text;

                if (_job.Status == "New")
                    _job.ProStart = DateTime.Now;

                _job.Status = "Pro";
                _job.InputAmount = Convert.ToInt32(Txt_File.Text);
                _job.QcTime = Convert.ToDouble(Txt_QC.Text);
                _job.WorkingLocation = Txt_Location.Text;
                _job.SiName = User.Short_Name;

                count = _db.ImageTime.Where(x => x.Job_ID == _job.JobId).Select(x=>x.Total_Time).Distinct().Count();

                if (count != 0)
                    _job.TargetTime = _db.ImageTime.Where(x => x.Job_ID == _job.JobId).Select(x => x.Total_Time).Distinct().Average();
                else
                    _job.TargetTime = _jobTime;

                _job.Up = 0;
                //--End update New Job Table

                if (_assignTime == null)
                {
                    _assignTime = new Assign_Time
                    {
                        Client = _job.Client,
                        Type = _type
                    };

                    _db.Assign_Time.Add(_assignTime);
                }

                _assignTime.Format = _job.Format;
                _assignTime.Clipping_Time = _clipping;
                _assignTime.Basic_Time = _basic;
                _assignTime.Pre_Process = _pre_process;
                _assignTime.Post_Process = _post_process;
                _assignTime.Up = 0;

                _db.SaveChanges();
                this.Close();
            }
        }

        private void Job_assign_Load(object sender, EventArgs e)
        {
            this.Text = "Job assign - " + User.Full_Name;
            _job = _db.New_Jobs.FirstOrDefault(x => x.JobId == _job.JobId);

            Lbl_Job_ID.Text = _job.JobId;
            Lbl_Incoming.Text = _job.Incoming.ToString("ddd dd-MMM hh:mm tt");
            Lbl_Delivery.Text = _job.Delivery.ToString("ddd dd-MMM hh:mm tt");
            Lbl_Amount.Text = _job.InputAmount + "";
            Lbl_Actual_Time.Text = _job.ActualTime + "";
            Txt_Location.Text = _job.WorkingLocation + "";
            Txt_File.Text = _job.InputAmount + "";
            Txt_Folder.Text = _job.Folder + "";
            Cmb_Team.Text = _job.Team + "";

            string ext = _job.Format;

            if (ext == ".jpg")
                Rdb_JPG.Checked = true;
            else if (ext == ".psd")
                Rdb_PSD.Checked = true;
            else if (ext == ".png")
                Rdb_PNG.Checked = true;
            else if(ext == ".tif")
                Rdb_TIF.Checked = true;
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

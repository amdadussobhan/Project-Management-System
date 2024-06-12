using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.Common_Panel;
using Skill_PMS.UI_WinForm.Production.Designer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    public partial class QC_Process : Form
    {
        SkillContext _db = new SkillContext();
        public Performance _performance = new Performance();
        QC_Progress _qcProgress;

        Common common = new Common();
        public NewJob _job = new NewJob();
        public int _fileAmount, _runningJobsId;
        public static bool _minimized = false;
        List<string> _files = new List<string>();
        List<string> _pro_files_name = new List<string>();
        List<string> _QC_files_name = new List<string>();
        public static double _total_Time = 0;
        string _instruction, _job_Folder, _my_Folder, _destination;

        public static User _user { get; set; }

        public QC_Process()
        {
            InitializeComponent();
        }

        private static QC_Process instance;
        public static QC_Process getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new QC_Process();
            else
                instance.BringToFront();
            return instance;
        }

        private void QC_Process_Load(object sender, EventArgs e)
        {
            this.Text = "QC Processing - By " + _user.Short_Name + "_" + _job.JobId;

            _job = _db.New_Jobs.FirstOrDefault(x => x.JobId == _job.JobId);
            _performance = _db.Performances.FirstOrDefault(x => x.Id == _performance.Id);

            _instruction = _job_Folder + @"\ins";
            _instruction = Path.Combine(_instruction, @"ins.txt");
            _job_Folder = _job.WorkingLocation;

            Btn_My_Folder.Enabled = true;
            Btn_Ready_Folder.Enabled = true;
            
            //Create my folder to local drive
            var localDrive = "";

            if (Directory.Exists(@"D:\"))
                localDrive = @"D:\";
            else if (Directory.Exists(@"E:\"))
                localDrive = @"E:\";
            else if (Directory.Exists(@"F:\"))
                localDrive = @"F:\";
            else if (Directory.Exists(@"G:\"))
                localDrive = @"G:\";

            _my_Folder = localDrive + @"Workfile\" + DateTime.Now.ToString("dd_MMM_yy") + "\\" + _job.JobId + "\\" + _user.Short_Name + "\\QC";
            Directory.CreateDirectory(_my_Folder);

            if (Directory.Exists(_job_Folder))
            {
                Process.Start(_job_Folder);
                _destination = _job_Folder + @"\QC" + "_Done";
                Directory.CreateDirectory(_destination); 
                
                Process.Start(_my_Folder);
            }
            else
                MessageBox.Show(@"Job Folder doesn't Exist. Please inform Your in-charge Or Manager about this...", @"Job Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void Reset_Process()
        {
            Tmr_Count.Stop();
            _total_Time = 0;

            var timespan = TimeSpan.FromSeconds(0);
            Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");

            DGV_Files.DataSource = null;
            DGV_Files.Rows.Clear();

            Btn_Cancel.Enabled = false;
            Btn_Pause.Enabled = false;
            Btn_Save.Enabled = false;
            DGV_Files.AllowDrop = true;
        }

        void Clear_Job()
        {
            if (_pro_files_name == null)
                return;

            foreach (string file in _pro_files_name)
            {
                if (string.IsNullOrEmpty(file))
                    break;

                Remove_File(file);
                if (_fileAmount == 0)
                {
                    _db.SaveChanges();
                    break;
                }
            }

            if (_pro_files_name != null)
                _pro_files_name.Clear();

            if (_QC_files_name != null)
                _QC_files_name.Clear();
        }

        private void Btn_Instruction_Click(object sender, EventArgs e)
        {
            if (File.Exists(_instruction))
                Process.Start(_instruction);
            else
                MessageBox.Show(@"Instruction doesn't Exist. Please inform Your Incharge Or Manager about this...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Btn_Job_Folder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_job_Folder))
                Process.Start(_job_Folder);
            else
                MessageBox.Show(@"Folder doesn't Exist. Please inform Your Incharge Or Manager about this...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Btn_My_Folder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_my_Folder))
                Process.Start(_my_Folder);
            else
                MessageBox.Show(@"My Folder doesn't Exist. Please Start Job First then try again...", @"My Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Btn_Ready_Folder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_destination))
                Process.Start(_destination);
            else
                MessageBox.Show(@"Folder doesn't Exist. Please Start Job First then try again...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            _total_Time++;
            if (Pnl_Counter.BackColor == Color.FromArgb(180, 180, 180))
                Pnl_Counter.BackColor = Color.MediumOrchid;
            else
                Pnl_Counter.BackColor = Color.FromArgb(180, 180, 180);            
            
            //TimeSpan timespan = TimeSpan.FromSeconds(_total_Time);
            //Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");
        }

        private void DGV_Files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string file_name = "";
            if (DGV_Files.Columns[DGV_Files.CurrentCell.ColumnIndex].HeaderText.Contains("X"))
            {
                if (DGV_Files.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    file_name = DGV_Files.Rows[e.RowIndex].Cells[1].Value.ToString();
                }

                if (!String.IsNullOrWhiteSpace(DGV_Files.CurrentCell.EditedFormattedValue.ToString()))
                {
                    if (!string.IsNullOrEmpty(file_name))
                    {
                        DGV_Files.Rows.RemoveAt(e.RowIndex);
                        Remove_File(file_name);
                        _db.SaveChanges();
                    }
                }
            }
        }

        private void QC_Process_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clear_Job();
            _minimized = false;
            if (_user.Role == "QC")
            {
                QcDashboard qc_dashboard = QcDashboard.GetInstance();
                qc_dashboard.Show();
            }
        }

        void Remove_File(string file)
        {
            var log = _db.Logs.FirstOrDefault(x => x.JobId == _job.JobId & x.Image == file & x.Status == "Running" & x.Name == _user.Short_Name & x.Service == "QC");

            if (log != null)
            {
                if (log.ProTime == 0)
                    _db.Logs.Remove(log);
                else
                    log.Status = "Done";
            }
            
            if (--_fileAmount <= 0)
                Reset_Process();

            _db.SaveChanges();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Clear_Job();
            Reset_Process();
            DGV_Files.Rows.Clear();
        }

        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            if (Btn_Pause.Text == "Pause")
            {
                Tmr_Count.Stop();
                Btn_Pause.Text = "Resume";
            }
            else
            {
                Tmr_Count.Start();
                Btn_Pause.Text = "Pause";
            }
        }

        private void DGV_Files_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void DGV_Files_DragDrop(object sender, DragEventArgs e)
        {
            _db = new SkillContext();
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
            _files = data.ToList();
            //Tmr_Open.Start();

            int SL = 1;
            DGV_Files.DataSource = null;
            DGV_Files.Rows.Clear();
            common.Dgv_Size(DGV_Files, 11);
            _fileAmount = _files.Count();

            Tmr_Count.Start();
            this.WindowState = FormWindowState.Minimized;

            DateTime now = DateTime.Now;
            DateTime today = now.Date;

            // Assuming _files contains valid file paths
            var nonEmptyFiles = _files.Where(file => !string.IsNullOrEmpty(file));

            // Create a list to store existing logs
            var existingLogs = _db.Logs.Where(x => x.JobId == _job.JobId && x.Name == _user.Short_Name && x.Service == "QC").ToList();

            foreach (string file in nonEmptyFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                _pro_files_name.Add(fileName);
                DGV_Files.Rows.Add(SL++, fileName, "X");

                var log = existingLogs.FirstOrDefault(it => it.Image == fileName);

                if (log == null)
                {
                    // Create a new Log record
                    log = new Log
                    {
                        JobId = _job.JobId,
                        Image = fileName,
                        Name = _user.Short_Name,
                        Date = today,
                        StartTime = now,
                        EndTime = now,
                    };
                    _db.Logs.Add(log);
                }

                //    // Update existing log
                log.Service = "QC";
                log.TargetTime = _job.QcTime;
                log.Shift = _performance.Shift;
                log.Status = "Running";
                log.Up = 0;
            }

            // Batch save changes to the database
            _db.SaveChanges();

            TimeSpan timespan = TimeSpan.FromSeconds(_job.QcTime * 60 * _fileAmount);
            Lbl_Job_Time.Text = "Time " + timespan.ToString(@"h\:mm\:s");

            _db.SaveChanges();
            DGV_Files.AllowDrop = false;
            Btn_Save.Enabled = true;
            Btn_Cancel.Enabled = true;
            Btn_Pause.Enabled = true;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Tmr_Count.Stop();
            var currentTime = DateTime.Now;
            DateTime today = currentTime.Date;
            if (_performance.Shift == "Night" & currentTime.ToString("tt").ToUpper() == "AM")
                today = currentTime.AddDays(-1).Date;

            _total_Time /= 60;
            double pro_Time = Math.Round(_total_Time / _fileAmount, 1);

            Reset_Process();
            Chenge_Quality_Btn(true);

            var existinglog = _db.Logs.Where(x => x.JobId == _job.JobId && x.Status == "Running" && x.Name == _user.Short_Name && x.Service == "QC").ToList();

            foreach (string file in _pro_files_name)
            {
                var log = existinglog.FirstOrDefault(it => it.Image == file);

                if (log != null)
                {
                    log.ProTime += pro_Time;
                    log.EndTime = currentTime;
                    log.Status = "Done";
                    log.Quality = 100;
                    log.Up = 0;

                    if (log.ProTime != 0)
                    {
                        log.Efficiency = (int)(log.TargetTime / log.ProTime * 100);
                    }

                    --_fileAmount;
                }
            }

            _db.SaveChanges();

            //My_Job Performance Entry in Performance Table
            Performance performance = _db.Performances.FirstOrDefault(x => x.Name == _user.Short_Name & x.Date == today);

            performance.File = _db.Logs
                .Count(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime);

            if (performance.File != 0)
            {
                performance.JobTime = _db.Logs
                        .Where(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.TargetTime);

                performance.ProTime = _db.Logs
                        .Where(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.ProTime);

                if (performance.ProTime != 0)
                    performance.Efficiency = (int)(performance.JobTime / performance.ProTime * 100);
            }

            performance.Up = 0;
            _db.SaveChanges();

            //_qcProgress = new QC_Progress
            //{
            //    _job = _job,
            //    _user = _user,
            //    _performance = _performance,
            //    _pro_files_name = _pro_files_name.ToList(),
            //    _fileAmount = _fileAmount,
            //    pro_Time = pro_Time,
            //};

            //_qcProgress.Show();

            _QC_files_name = _pro_files_name.ToList();
            _pro_files_name.Clear();
        }

        private void QC_Process_Resize(object sender, EventArgs e)
        {
            /*
            var counter = new Counter();
            if (this.WindowState == FormWindowState.Minimized)
            {
                counter.Show();
                _minimized = true;
            }
            else
                _minimized = false;

            Counter.Status = "QC";
            Counter.Minimized = _minimized;
            Counter.TotalTime = _total_Time;
            */
        }

        void Chenge_Quality_Btn(bool state)
        {
            Btn_100.Enabled = state;
            Btn_90.Enabled = state;
            Btn_80.Enabled = state;
            Btn_70.Enabled = state;
            Btn_60.Enabled = state;
            Btn_50.Enabled = state;
        }

        private void Btn_Find_Click(object sender, EventArgs e)
        {
            _QC_files_name.Add(Txt_File.Text);

            var productivity = Productivity.getInstance();
            productivity._user = _user;
            productivity._jobID = _job.JobId;
            productivity._image = Txt_File.Text;
            productivity.Show();

            Chenge_Quality_Btn(true);
        }

        void Update_Quality(int quality)
        {
            foreach (string file in _QC_files_name)
            {
                if (string.IsNullOrEmpty(file))
                    break;

                var logs = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Image == file & x.Status == "Done" & x.Service != "QC");

                if (logs != null)
                {
                    foreach (var log in logs)
                    {
                        if (log != null)
                        {
                            log.Quality = quality;
                            log.Up = 0;
                        }
                    }
                }
                //_backup.Add(file);
            }
            _QC_files_name.Clear();
            _db.SaveChanges();
            MessageBox.Show(@"Thanks for feedback.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Chenge_Quality_Btn(false);
        }

        private void Btn_75_Click(object sender, EventArgs e)
        {
            Update_Quality(50);
        }

        private void Btn_80_Click(object sender, EventArgs e)
        {
            Update_Quality(60);
        }

        private void Btn_85_Click(object sender, EventArgs e)
        {
            Update_Quality(70);
        }

        private void Tmr_Open_Tick(object sender, EventArgs e)
        {
            Tmr_Open.Stop();
            int SL = 1;
            DGV_Files.DataSource = null;
            DGV_Files.Rows.Clear();
            common.Dgv_Size(DGV_Files, 11);
            _fileAmount = _files.Count();

            Tmr_Count.Start();
            this.WindowState = FormWindowState.Minimized;

            DateTime now = DateTime.Now;
            DateTime today = now.Date;

            // Assuming _files contains valid file paths
            var nonEmptyFiles = _files.Where(file => !string.IsNullOrEmpty(file));

            // Create a dictionary to store existing logs (keyed by image name)
            var existingLogs = _db.Logs
                .Where(x => x.JobId == _job.JobId && x.Name == _user.Short_Name && x.Service == "QC")
                .ToDictionary(x => x.Image, StringComparer.OrdinalIgnoreCase);


            foreach (string file in nonEmptyFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                _pro_files_name.Add(fileName);
                DGV_Files.Rows.Add(SL++, fileName, "X");

                if (!existingLogs.TryGetValue(fileName, out Log log))
                {
                    // Create a new Log record
                    log = new Log
                    {
                        JobId = _job.JobId,
                        Image = fileName,
                        Name = _user.Short_Name,
                        Date = today,
                        StartTime = now,
                        EndTime = now,
                    };
                    _db.Logs.Add(log);
                }

                //    // Update existing log
                log.Service = "QC";
                log.TargetTime = _job.QcTime;
                log.Shift = _performance.Shift;
                log.Status = "Running";
                log.Up = 0;
            }

            // Batch save changes to the database
            _db.SaveChanges();

            TimeSpan timespan = TimeSpan.FromSeconds(_job.QcTime * 60 * _fileAmount);
            Lbl_Job_Time.Text = "Time " + timespan.ToString(@"h\:mm\:s");

            _db.SaveChanges();
            DGV_Files.AllowDrop = false;
            Btn_Save.Enabled = true;
            Btn_Cancel.Enabled = true;
            Btn_Pause.Enabled = true;
        }

        private void Tmr_Save_Tick(object sender, EventArgs e)
        {
            Tmr_Save.Stop();
            _qcProgress.Show();
        }

        private void Btn_90_Click(object sender, EventArgs e)
        {
            Update_Quality(80);
        }

        private void Btn_95_Click(object sender, EventArgs e)
        {
            Update_Quality(90);
        }

        private void Btn_100_Click(object sender, EventArgs e)
        {
            Update_Quality(100);
        }
    }
}

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

namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    public partial class QC_Process : Form
    {
        SkillContext _db = new SkillContext();
        public Performance _performance = new Performance();

        Log log = new Log();
        Common common = new Common();
        public NewJob _job = new NewJob();
        public static User _user { get; set; }

        int _fileAmount;
        public static bool _minimized = false;
        List<string> _files = new List<string>();
        List<string> _pro_files_name = new List<string>();
        List<string> _QC_files_name = new List<string>();
        public static double _total_Time = 0;
        string _instruction, _job_Folder, _my_Folder, _destination;

        public QC_Process()
        {
            InitializeComponent();
        }

        private static QC_Process instance;
        private string _myService;
        private double _jobTime;
        private List<string> _backup;

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

            _job = _db.New_Jobs.Where(x => x.JobId == _job.JobId).FirstOrDefault<NewJob>();
            _performance = _db.Performances.Where(x => x.Id == _performance.Id).FirstOrDefault<Performance>();

            _job_Folder = _job.InputLocation;
            _instruction = _job_Folder + @"\ins";
            _instruction = Path.Combine(_instruction, @"ins.txt");

            Btn_My_Folder.Enabled = true;
            Btn_Ready_Folder.Enabled = true;
            
            Chenge_Service();
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

        private void Chenge_Service()
        {
            if (_job.Service == null)
                return;

            if (_job.Service.Contains("CP"))
                Chk_CP.Enabled = true;

            if (_job.Service.Contains("RET"))
                Chk_RET.Enabled = true;

            if (_job.Service.Contains("MSK"))
                Chk_MSK.Enabled = true;

            if (_job.Service.Contains("SHA"))
                Chk_SHA.Enabled = true;

            if (_job.Service.Contains("NJ"))
                Chk_NJ.Enabled = true;

            if (_job.Service.Contains("CC"))
                Chk_CC.Enabled = true;

            if (_job.Service.Contains("LIQ"))
                Chk_LIQ.Enabled = true;

            Chk_QC.Enabled = true;
        }

        private void Generate_Service()
        {
            _myService = "";

            if (Chk_CP.Checked)
                _myService += "CP+";

            if (Chk_RET.Checked)
                _myService += "RET+";

            if (Chk_MSK.Checked)
                _myService += "MSK+";

            if (Chk_SHA.Checked)
                _myService += "SHA+";

            if (Chk_LIQ.Checked)
                _myService += "LIQ+";

            if (Chk_NJ.Checked)
                _myService += "NJ+";

            if (Chk_CC.Checked)
                _myService += "CC+";

            _myService = _myService.TrimEnd('+');
            if (Chk_QC.Checked)
            {
                if (string.IsNullOrEmpty(_myService))
                    Txt_Service.Text = "QC";
                else
                    Txt_Service.Text = _myService + "+QC";
            }
            else
                Txt_Service.Text = _myService;

            if(!string.IsNullOrEmpty(_myService) | Chk_QC.Checked)
                DGV_Files.AllowDrop = true;
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

            if (_backup != null)
                _backup.Clear();

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
            log = _db.Logs
                .Where(x => x.JobId == _job.JobId & x.Image == file & x.Status == "Running" & x.Name == _user.Short_Name & x.Service == "QC")
                .FirstOrDefault<Log>();

            if (log != null)
                _db.Logs.Remove(log);

            if (--_fileAmount <= 0)
                Reset_Process();

            _backup.Add(file);
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Clear_Job();
            Reset_Process();
            DGV_Files.Rows.Clear();
            Chenge_Service();
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
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
            _files = data.ToList();

            int SL = 1;
            DGV_Files.DataSource = null;
            DGV_Files.Rows.Clear();
            common.Dgv_Size(DGV_Files, 11);
            _fileAmount = _files.Count();
                        
            Tmr_Count.Start();
            this.WindowState = FormWindowState.Minimized;

            foreach (string file in _files)
            {
                if (string.IsNullOrEmpty(file))
                    break;

                string fileName = Path.GetFileNameWithoutExtension(file);
                _pro_files_name.Add(fileName);
                DGV_Files.Rows.Add(SL++, fileName, "X");

                var imageTime = _db.ImageTime
                    .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == fileName);

                var category = "";
                if (imageTime != null)
                    category = imageTime.Category;

                double total_job_time = 0;

                if (!string.IsNullOrEmpty(_myService))
                {
                    _jobTime = 0;
                    if (imageTime != null)
                    {
                        if (Chk_CP.Checked)
                            _jobTime += imageTime.CP_Time;

                        if (Chk_RET.Checked)
                            _jobTime += imageTime.RET_Time;

                        if (Chk_MSK.Checked)
                            _jobTime += imageTime.MSK_Time;

                        if (Chk_SHA.Checked)
                            _jobTime += imageTime.SHA_Time;

                        if (Chk_LIQ.Checked)
                            _jobTime += imageTime.LIQ_Time;

                        if (Chk_NJ.Checked)
                            _jobTime += imageTime.NJ_Time;

                        if (Chk_CC.Checked)
                            _jobTime += imageTime.CC_Time;
                    }
                    else
                    {
                        if (Chk_CP.Checked)
                            _jobTime += _job.CP_Time;

                        if (Chk_RET.Checked)
                            _jobTime += _job.RET_Time;

                        if (Chk_MSK.Checked)
                            _jobTime += _job.MSK_Time;

                        if (Chk_SHA.Checked)
                            _jobTime += _job.SHA_Time;

                        if (Chk_LIQ.Checked)
                            _jobTime += _job.LIQ_Time;

                        if (Chk_NJ.Checked)
                            _jobTime += _job.NJ_Time;

                        if (Chk_CC.Checked)
                            _jobTime += _job.CC_Time;
                    }

                    log = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Image == fileName & x.Name == _user.Short_Name & x.Service == _myService)
                        .FirstOrDefault<Log>();

                    if (log == null)
                    {
                        log = new Log
                        {
                            JobId = _job.JobId,
                            Image = fileName,
                            Name = _user.Short_Name,
                            Shift = _performance.Shift,
                            Service = _myService,
                            TargetTime = _jobTime,
                            Date = DateTime.Now.Date,
                            StartTime = DateTime.Now,
                            EndTime = DateTime.Now
                        };
                        _db.Logs.Add(log);
                    }
                    log.Status = "Running";
                    log.Category = category;
                    log.Up = 0;

                    total_job_time = _jobTime;
                }

                if (Chk_QC.Checked)
                {
                    if (imageTime != null)
                        _jobTime = imageTime.QC_Time;

                    if(_jobTime == 0)
                        _jobTime = _job.QC_Time;

                    log = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Image == fileName & x.Name == _user.Short_Name & x.Service == "QC")
                        .FirstOrDefault<Log>();

                    if (log == null)
                    {
                        log = new Log
                        {
                            JobId = _job.JobId,
                            Image = fileName,
                            Name = _user.Short_Name,
                            Shift = _performance.Shift,
                            Service = "QC",
                            TargetTime = _jobTime,
                            Date = DateTime.Now.Date,
                            StartTime = DateTime.Now,
                            EndTime = DateTime.Now
                        };
                        _db.Logs.Add(log);
                        log.Category = category;
                    }
                    log.Status = "Running";
                    log.Up = 0;

                    total_job_time += _jobTime;
                }

                TimeSpan timespan = TimeSpan.FromSeconds(total_job_time * 60 * _fileAmount);
                Lbl_Job_Time.Text = "Time " + timespan.ToString(@"h\:mm\:s");
            }

            _db.SaveChanges();
            /*
            foreach (string file in _files)
            {
                if (string.IsNullOrEmpty(file))
                    break;

                try
                {
                    Process Open = new Process();
                    Open.StartInfo.FileName = @"Photoshop";
                    Open.StartInfo.Arguments = file;
                    Open.Start();
                }
                catch
                {
                    Process Open = new Process();
                    Open.StartInfo.FileName = @"C:\Program Files (x86)\Adobe\Adobe Photoshop CS6\Photoshop.exe";
                    Open.StartInfo.Arguments = file;
                    Open.Start();
                }

                Thread.Sleep(1000);
            }*/

            DGV_Files.AllowDrop = false;
            Btn_Save.Enabled = true;
            Btn_Cancel.Enabled = true;
            Btn_Pause.Enabled = true;

            Chk_CP.Enabled = false;
            Chk_RET.Enabled = false;
            Chk_MSK.Enabled = false;
            Chk_NJ.Enabled = false;
            Chk_CC.Enabled = false;
            Chk_LIQ.Enabled = false;
            Chk_SHA.Enabled = false;
            Chk_QC.Enabled = false;

            _backup = new List<string>();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
            if (this._performance.Shift == "Night" & DateTime.Now.ToString("tt").ToUpper() == "AM")
                today = DateTime.Now.AddDays(-1).Date;

            Tmr_Count.Stop();
            _total_Time = _total_Time / 60;
            double pro_Time = _total_Time / _fileAmount;
            double qc_Time = pro_Time * 0.1;

            if (!string.IsNullOrEmpty(_myService))
                pro_Time -= qc_Time;
            else
                qc_Time = pro_Time;

            if (_backup != null)
            {
                foreach (string file in _backup.ToList())
                    _pro_files_name.Remove(file);
            }

            //My_Job Report Entry in Log Table
            foreach (string file in _pro_files_name)
            {
                if (file == null)
                    break;

                if (!string.IsNullOrEmpty(_myService)) 
                {
                    log = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Image == file & x.Status == "Running" & x.Name == _user.Short_Name & x.Service == _myService)
                        .FirstOrDefault<Log>();

                    log.ProTime += pro_Time;
                    log.EndTime = DateTime.Now;
                    log.Status = "Done";
                    log.Up = 0;

                    if (log.ProTime != 0)
                        log.Efficiency = (int)(log.TargetTime / log.ProTime * 100);
                }

                if (Chk_QC.Checked)
                {
                    log = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Image == file & x.Status == "Running" & x.Name == _user.Short_Name & x.Service == "QC")
                        .FirstOrDefault<Log>();

                    log.ProTime += qc_Time;
                    log.EndTime = DateTime.Now;
                    log.Status = "Done";
                    log.Up = 0;

                    if (log.ProTime != 0)
                        log.Efficiency = (int)(log.TargetTime / log.ProTime * 100);
                }

                --_fileAmount;
            }

            _db.SaveChanges();

            //Job Report Entry in Job Table
            int done_file = _db.Logs
                .Where(x => x.JobId == _job.JobId & x.Service == "QC")
                .Count();

            if (done_file != 0) {
                double done_time = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Service == "QC")
                    .Sum(x => x.ProTime);

                _job.QcTime = done_time / done_file;
            }

            _job.OutputAmount = done_file;
            _job.Up = 0;

            //My_Job Report Entry in My_Job Table
            MyJob my_job;
            if (!string.IsNullOrEmpty(_myService))
            {
                my_job = _db.My_Jobs
                .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService)
                .FirstOrDefault<MyJob>();

                if (my_job == null)
                {
                    my_job = new MyJob();
                    my_job.JobId = _job.JobId;
                    my_job.Name = _user.Short_Name;
                    my_job.Service = _myService;
                    my_job.Date = DateTime.Now.Date;
                    my_job.StartTime = DateTime.Now;

                    _db.My_Jobs.Add(my_job);
                }

                done_file = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService)
                    .Count();

                my_job.Amount = done_file;
                if (done_file != 0)
                {
                    double done_time = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService)
                        .Sum(x => x.TargetTime);

                    my_job.JobTime = done_time;

                    done_time = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService)
                        .Sum(x => x.ProTime);

                    my_job.ProTime = done_time;
                    if (my_job.ProTime != 0)
                        my_job.Efficiency = (int)(my_job.JobTime / my_job.ProTime * 100);
                }

                my_job.EndTime = DateTime.Now;
                my_job.Up = 0;
                _db.SaveChanges();
            }

            if (Chk_QC.Checked)
            {
                my_job = _db.My_Jobs
                .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == "QC")
                .FirstOrDefault<MyJob>();

                if (my_job == null)
                {
                    my_job = new MyJob();
                    my_job.JobId = _job.JobId;
                    my_job.Name = _user.Short_Name;
                    my_job.Service = "QC";
                    my_job.Date = DateTime.Now.Date;
                    my_job.StartTime = DateTime.Now;

                    _db.My_Jobs.Add(my_job);
                }

                done_file = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == "QC")
                    .Count();

                my_job.Amount = done_file;
                if (done_file != 0)
                {
                    double done_time = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == "QC")
                        .Sum(x => x.TargetTime);

                    my_job.JobTime = done_time;

                    done_time = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == "QC")
                        .Sum(x => x.ProTime);

                    my_job.ProTime = done_time;
                    if (my_job.ProTime != 0)
                        my_job.Efficiency = (int)(my_job.JobTime / my_job.ProTime * 100);
                }

                my_job.EndTime = DateTime.Now;
                my_job.Up = 0;
                _db.SaveChanges();
            }

            //My_Job Performance Entry in Performance Table
            Performance performance;
            performance = _db.Performances
                .Where(x => x.Name == _user.Short_Name & x.Date == today)
                .FirstOrDefault<Performance>();

            done_file = _db.My_Jobs
                .Where(x => x.Name == _user.Short_Name & x.Date == today)
                .Count();

            if (done_file != 0)
            {
                done_file = _db.My_Jobs
                   .Where(x => x.Name == _user.Short_Name & x.Date == today)
                   .Sum(x => x.Amount);

                performance.File = done_file;

                double done_time = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name)
                    .Sum(x => x.TargetTime);

                performance.JobTime = done_time;
                done_time = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name)
                    .Sum(x => x.ProTime);

                performance.ProTime = done_time;

                if (performance.ProTime != 0)
                    performance.Efficiency = (int)(performance.JobTime / performance.ProTime * 100);
            }
            performance.Up = 0;
            _db.SaveChanges();
            Reset_Process();
            Chenge_Quality_Btn(true);
            Chenge_Service();

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
            productivity.user = _user;
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
                _backup.Add(file);
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

        private void Chk_CP_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_RET_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_MSK_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_NJ_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_CC_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_LIQ_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_SHA_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_QC_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Btn_80_Click(object sender, EventArgs e)
        {
            Update_Quality(60);
        }

        private void Btn_85_Click(object sender, EventArgs e)
        {
            Update_Quality(70);
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

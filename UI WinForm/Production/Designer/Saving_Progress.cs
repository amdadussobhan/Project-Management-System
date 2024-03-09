using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Skill_PMS.Controller;

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class SavingProgress : Form
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        private readonly SkillContext _db = new SkillContext();
        public Performance _performance = new Performance();
        public NewJob _job = new NewJob();
        private readonly Common _common = new Common();
        public User _user { get; set; }
        private Log _log = new Log();

        public double _proTime;
        public int _previousValue = 0;
        private DateTime _currentTime;
        public string _myService, _fileName;
        public bool _pause = false, finish = false;
        public string _source, _destination, Backup, Raw_Source, Raw_Backup, Status;

        private void Tmr_Close_Tick(object sender, EventArgs e)
        {
            Tmr_Close.Stop();
            this.Close();
        }

        private void Tmr_Copy_Tick(object sender, EventArgs e)
        {
            Tmr_Copy.Stop();
            backgroundWorker.RunWorkerAsync();
            //if (Prb_Copier.Value == _previousValue & Prb_Copier.Value != 100)
            //{
            //    if (File.Exists(_source))
            //    {
            //        if (!_pause & !File.Exists(_destination))
            //            File.Copy(_source, _destination);
            //    }
            //    else
            //        MessageBox.Show(@"Find done file & keep it to Done folder manually...", @"Done file doesn't Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    SavePerformance();
            //}
        }

        public SavingProgress()
        {
            InitializeComponent();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.WorkerReportsProgress = true;

            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
        }

        public static class ModifyProgressBarColor
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]

            static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

            public static void SetState(ProgressBar prB, int state)
            {
                SendMessage(prB.Handle, 1040, (IntPtr)state, IntPtr.Zero);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (File.Exists(_source))
            {
                if (!_pause)
                    CopyFile(_source, _destination);
            }
            else
            {
                MessageBox.Show(@"Find done file & keep it to Done folder manually...", @"Done file doesn't Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Tmr_Copy.Stop();
            Prb_Copier.Value = _previousValue = e.ProgressPercentage;
            if (Prb_Copier.Value == 100)
                SavePerformance();
        }

        void SavePerformance()
        {
            //Tmr_Copy.Stop();
            Lbl_Success.Visible = true;
            var date = _currentTime.Date;
            if (_performance.Shift == "Night" & DateTime.Now.ToString("tt").ToUpper() == "AM")
                date = DateTime.Now.AddDays(-1).Date;

            Lbl_Success.Left = 85;
            Lbl_Success.ForeColor = Color.Black;
            Lbl_Success.Text = "Pro_Time:" + Math.Round(_proTime, 1) + " Efficiency:" + _log.Efficiency + "%";

            //2022
            //_common.UpdateJob(_user, _job, _runningJob);

            //---Update My_Job Report in My_Job Table
            var myJob = _db.My_Jobs
                .FirstOrDefault(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService & x.Date == date);

            if (myJob == null)
            {
                myJob = new MyJob
                {
                    JobId = _job.JobId,
                    Name = _user.Short_Name,
                    Service = _myService,
                    Date = date,
                    StartTime = _log.StartTime
                };
                _db.My_Jobs.Add(myJob);
            }

            var fileCount = myJob.Amount = _db.Logs
                .Count(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService &
                    x.StartTime >= _performance.Login & x.StartTime <= _currentTime);

            double quality;
            if (fileCount != 0)
            {
                myJob.TotalJobTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService &
                                x.StartTime >= _performance.Login & x.StartTime <= _currentTime).Sum(x => x.TargetTime);

                myJob.JobTime = myJob.TotalJobTime / fileCount;

                myJob.TotalProTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService &
                                x.StartTime >= _performance.Login & x.StartTime <= _currentTime).Sum(x => x.ProTime);

                myJob.ProTime = myJob.TotalProTime / fileCount;

                if (myJob.ProTime != 0)
                    myJob.Efficiency = (int)(myJob.JobTime / myJob.ProTime * 100);

                quality = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService &
                                x.StartTime >= _performance.Login & x.StartTime <= _currentTime).Average(x => x.Quality);

                myJob.Quality = (int)(quality);
            }

            myJob.EndTime = _currentTime;
            myJob.Up = 0;
            //---End Update My_Job Report in My_Job Table

            //---Update My_Job Performance in Performance Table
            _performance = _db.Performances.FirstOrDefault(x => x.Id == _performance.Id);

            _performance.File = fileCount = _db.Logs
                .Count(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime);

            if (fileCount != 0)
            {
                _performance.JobTime = _db.Logs
                        .Where(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime)
                        .Sum(x => x.TargetTime);

                _performance.ProTime = _db.Logs
                        .Where(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime)
                        .Sum(x => x.ProTime);

                if (_performance.ProTime != 0)
                    _performance.Efficiency = (int)(_performance.JobTime / _performance.ProTime * 100);

                quality = _db.Logs
                        .Where(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime)
                        .Average(x => x.Quality);

                _performance.Quality = (int)(quality);
            }

            _performance.Logout = _currentTime;
            _performance.WorkingTime = (int)(_currentTime - _performance.Login).TotalMinutes;
            _performance.Up = 0;
            _db.SaveChanges();

            var dashboard = Dashboard.GetInstance();
            dashboard._performance = _performance;
            Tmr_Close.Start();
        }

        void CopyFile(string source, string destination)
        {
            FileStream fsIn = new FileStream(source, FileMode.Open);
            FileStream fsOut = new FileStream(destination, FileMode.Create);
            byte[] bt = new byte[1048756];
            int readByte;
            while ((readByte = fsIn.Read(bt, 0, bt.Length)) >0)
            {
                fsOut.Write(bt, 0, readByte);
                backgroundWorker.ReportProgress((int)(fsIn.Position * 100 / fsIn.Length));
            }
            fsIn.Close();
            fsOut.Close();
        }

        private void Saving_Progress_Load(object sender, EventArgs e)
        {
            Prb_Copier.Value = 0;
            _currentTime = DateTime.Now;

            //update log Report in Log Table
            _log = _db.Logs.FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Name == _user.Short_Name & x.Service == _myService);

            _log.ProTime += _proTime;
            _log.OutputLocation = _destination;
            _log.EndTime = _currentTime;
            _log.Status = "Done";
            _log.Quality = 100;
            _log.Up = 0;

            if (_log.ProTime != 0)
                _log.Efficiency = (int)(_log.TargetTime / _log.ProTime * 100);

            _db.SaveChanges();

            if (_log.Efficiency < 75)
                ModifyProgressBarColor.SetState(Prb_Copier, 2);
            else if (_log.Efficiency < 100)
                ModifyProgressBarColor.SetState(Prb_Copier, 3);
            else if (_log.Efficiency == 0)
                ModifyProgressBarColor.SetState(Prb_Copier, 1);

            Tmr_Copy.Start();
        }
    }
}

using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    public partial class QC_Progress : Form
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        private readonly SkillContext _db = new SkillContext();
        public List<string> _pro_files_name = new List<string>();
        public Performance _performance = new Performance();
        private readonly Common _common = new Common();
        public NewJob _job = new NewJob();
        public User _user = new User();
        public double pro_Time, qc_Time;
        public bool QC, finish = false;
        public int _fileAmount;

        public QC_Progress()
        {
            InitializeComponent();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.WorkerReportsProgress = true;

            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var currentTime = DateTime.Now;
            DateTime today = currentTime.Date;
            if (_performance.Shift == "Night" & currentTime.ToString("tt").ToUpper() == "AM")
                today = currentTime.AddDays(-1).Date;

            Log log = new Log();
            //Prb_Copier.Value = 0;
            //Prb_Copier.Maximum = _fileAmount + 5;
            //Prb_Copier.Increment(1);

            //My_Job Report Entry in Log Table


            //Optimized 1
            // Retrieve all relevant logs in a single query
            //var relevantLogs = _db.Logs
            //    .Where(x =>
            //        x.JobId == _job.JobId &&
            //        x.Status == "Running" &&
            //        x.Name == _user.Short_Name &&
            //        x.Service == "QC" &&
            //        _pro_files_name.Contains(x.Image))
            //    .ToList();

            //foreach (var log in relevantLogs)
            //{
            //    log.ProTime += pro_Time;
            //    log.EndTime = currentTime;
            //    log.Status = "Done";
            //    log.Quality = 100;
            //    log.Up = 0;

            //    if (log.ProTime != 0)
            //    {
            //        log.Efficiency = (int)(log.TargetTime / log.ProTime * 100);
            //    }

            //    --_fileAmount;
            //}


            //Optimized 2
            // Create a dictionary to store logs by image file name
            var logDictionary = _db.Logs.Where(x => x.JobId == _job.JobId && x.Status == "Running" && x.Name == _user.Short_Name && x.Service == "QC" &&
                    _pro_files_name.Contains(x.Image)).ToDictionary(x => x.Image, StringComparer.OrdinalIgnoreCase);

            foreach (string file in _pro_files_name)
            {
                if (logDictionary.TryGetValue(file, out log))
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


            //Original
            //foreach (string file in _pro_files_name)
            //{
            //    if (file == null)
            //        break;

            //    log = _db.Logs.FirstOrDefault(x => x.JobId == _job.JobId & x.Image == file & x.Status == "Running" & x.Name == _user.Short_Name & x.Service == "QC");

            //    log.ProTime += pro_Time;
            //    log.EndTime = currentTime;
            //    log.Status = "Done";
            //    log.Quality = 100;
            //    log.Up = 0;

            //    if (log.ProTime != 0)
            //        log.Efficiency = (int)(log.TargetTime / log.ProTime * 100);

            //    --_fileAmount;
            //    //Prb_Copier.Increment(1);
            //}


            _db.SaveChanges();

            //My_Job Report Entry in My_Job Table
            MyJob my_job = _db.My_Jobs.FirstOrDefault(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == "QC" & x.Date == currentTime.Date);

            if (my_job == null)
            {
                my_job = new MyJob
                {
                    JobId = _job.JobId,
                    Name = _user.Short_Name,
                    Service = "QC",
                    Date = currentTime.Date,
                    StartTime = log.StartTime
                };

                _db.My_Jobs.Add(my_job);
            }

            var fileCount =  my_job.Amount = _db.Logs
                .Count(x => x.JobId == _job.JobId & x.Status == "Done" & x.Name == _user.Short_Name &
                            x.Service == "QC" & x.StartTime >= _performance.Login & x.StartTime <= currentTime);

            if (fileCount != 0)
            {
                my_job.TotalJobTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Status == "Done" & x.Name == _user.Short_Name &
                            x.Service == "QC" & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                    .Sum(x => x.TargetTime);

                my_job.JobTime = my_job.TotalJobTime / fileCount;

                my_job.TotalProTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Status == "Done" & x.Name == _user.Short_Name &
                                x.Service == "QC" & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                    .Sum(x => x.ProTime);

                my_job.ProTime = my_job.TotalProTime / fileCount;

                if (my_job.ProTime != 0)
                    my_job.Efficiency = (int)(my_job.JobTime / my_job.ProTime * 100);
            }

            my_job.EndTime = currentTime;
            my_job.Up = 0;

            //Prb_Copier.Increment(1);

            //My_Job Performance Entry in Performance Table
            Performance performance = _db.Performances.FirstOrDefault(x => x.Name == _user.Short_Name & x.Date == today);

            performance.File = fileCount = _db.Logs
                .Count(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime);

            if (fileCount != 0)
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
            //Prb_Copier.Increment(1);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Prb_Copier.Increment(1);
        }

        private void Tmr_QC_Progress_Tick(object sender, EventArgs e)
        {
            Tmr_QC_Progress.Stop();
        }

        private void QC_Progress_Load(object sender, EventArgs e)
        {
            Prb_Copier.Value = 0;
            backgroundWorker.RunWorkerAsync();
            //Tmr_QC_Progress.Start();
        }
    }
}

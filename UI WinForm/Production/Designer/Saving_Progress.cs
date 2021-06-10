using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class SavingProgress : Form
    {
        private readonly SkillContext _db = new SkillContext();
        public Performance _performance = new Performance();
        public NewJob _job = new NewJob();
        public User User { get; set; }
        private Log _log = new Log();

        public string _myService, _fileName;
        public double _proTime;
        public bool resume = false, finish = false;

        private class UiProgress
        {
            public UiProgress(string name, long bytes, long maxbytes)
            {
                this.name = name; this.bytes = bytes; this.maxbytes = maxbytes;
            }
            public string name;
            public long bytes;
            public long maxbytes;
        }

        // Class to report exception {
        private class UIError
        {
            public UIError(Exception ex, string path_)
            {
                msg = ex.Message; path = path_; result = DialogResult.Cancel;
            }
            public string msg;
            public string path;
            public DialogResult result;
        }
        private BackgroundWorker mCopier;
        private delegate void ProgressChanged(UiProgress info);
        private delegate void CopyError(UIError err);
        private ProgressChanged OnChange;
        private CopyError OnError;

        public SavingProgress()
        {
            InitializeComponent();

            mCopier = new BackgroundWorker();
            mCopier.DoWork += Copier_DoWork;
            mCopier.RunWorkerCompleted += Copier_RunWorkerCompleted;
            mCopier.WorkerSupportsCancellation = true;
            OnChange += Copier_ProgressChanged;
            OnError += Copier_Error;
            ChangeUi(false);
        }

        public string Source, Destination, Backup, Raw_Source, Raw_Backup, Status;

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            var currentTime = DateTime.Now;
            var date = currentTime.Date;
            if (_performance.Shift == "Night" & DateTime.Now.ToString("tt").ToUpper() == "AM")
                date = DateTime.Now.AddDays(-1).Date;

            double myTime = 0;
            //update log Report in Log Table
            _log = _db.Logs
                .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Status == "Running" & x.Name == User.Short_Name & x.Service == _myService);

            if (_log != null)
            {
                myTime = _log.TargetTime;
                _log.ProTime += _proTime;

                if (_log.ProTime != 0)
                    _log.Efficiency = Convert.ToInt32(_log.TargetTime / _log.ProTime * 100);

                _log.OutputLocation = Destination;
                _log.EndTime = currentTime;
                _log.Status = "Done";
                _log.Quality = 100;
                _log.Up = 0;
            }

            //Update Job report in job table
            var fileCount = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Status == "Done")
                    .Select(x => x.Image)
                    .Distinct()
                    .Count();

            if (fileCount != 0)
            {
                var proTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Status == "Done")
                    .Sum(x => x.ProTime);

                _job.ProTime = proTime / fileCount;
            }

            _job.ProDone = fileCount;
            _job.Up = 0;

            //Update My_Job Report in My_Job Table

            var myJob = _db.My_Jobs
                .FirstOrDefault(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService & x.Date == date);

            if (myJob == null)
            {
                myJob = new MyJob
                {
                    JobId = _job.JobId,
                    Name = User.Short_Name,
                    Service = _myService,
                    Date = date,
                    StartTime = _log.StartTime
                };
                _db.My_Jobs.Add(myJob);
            }

            fileCount = _db.Logs
                .Where(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService &
                    x.StartTime >= _performance.Login & x.StartTime <= currentTime).Count();

            myJob.Amount = fileCount;

            double quality;
            if (fileCount != 0)
            {
                quality = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService &
                                x.StartTime >= _performance.Login & x.StartTime <= currentTime).Average(x => x.Quality);

                myJob.Quality = Convert.ToInt32(quality);

                myJob.TotalJobTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService &
                                x.StartTime >= _performance.Login & x.StartTime <= currentTime).Sum(x => x.TargetTime);

                myJob.JobTime = myJob.TotalJobTime / fileCount;

                myJob.TotalProTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService &
                                x.StartTime >= _performance.Login & x.StartTime <= currentTime).Sum(x => x.ProTime);

                myJob.ProTime = myJob.TotalProTime / fileCount;

                if (myJob.ProTime != 0)
                    myJob.Efficiency = Convert.ToInt32(myJob.JobTime / myJob.ProTime * 100);
            }

            myJob.EndTime = currentTime;
            myJob.Up = 0;

            //Update My_Job Performance in Performance Table

            fileCount = _db.My_Jobs
                .Count(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime);

            if (fileCount != 0)
            {
                _performance.File = _db.My_Jobs
                        .Where(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.Amount);

                _performance.JobTime = _db.My_Jobs
                        .Where(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.TotalJobTime);

                _performance.ProTime = _db.My_Jobs
                        .Where(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.TotalProTime);

                quality = _db.My_Jobs
                        .Where(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Average(x => x.Quality);

                _performance.Quality = Convert.ToInt32(quality);
            }

            if (_performance.ProTime != 0)
                _performance.Efficiency = Convert.ToInt32(_performance.JobTime / _performance.ProTime * 100);

            _performance.Logout = currentTime;
            _performance.WorkingTime = (int)(currentTime - _performance.Login).TotalMinutes;
            _performance.Up = 0;
            _db.SaveChanges();

            Tmr_Count.Stop();

            var dashboard = Dashboard.GetInstance();
            dashboard.Performance = _performance;

            if (finish) Finished();
            else finish = true;
        }

        void Finished()
        {
            this.Close();
        }

        private void Copier_DoWork(object sender, DoWorkEventArgs e)
        {
            //Copy done image to server ready folder
            if (File.Exists(Source))
            {
                // Create list of files to copy
                long maxbytes = 0;
                maxbytes += Source.Length;
                // Copy files
                long bytes = 0;
                try
                {
                    this.BeginInvoke(OnChange, new object[] { new UiProgress(Source, bytes, maxbytes) });
                    if (resume)
                        File.Move(Source, Destination);
                    else
                        File.Copy(Source, Destination, true);
                }
                catch (Exception ex)
                {
                    UIError err = new UIError(ex, Source);
                    this.Invoke(OnError, new object[] { err });
                    if (err.result == DialogResult.Cancel)
                    {

                    }
                }
                bytes += Source.Length;
            }
            else
                MessageBox.Show(@"Find done file & keep it to Ready folder manually...", @"Done file doesn't Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Copier_ProgressChanged(UiProgress info)
        {
            // Update progress
            Prb_Copier.Value = (int)(100.0 * info.bytes / info.maxbytes);
        }

        private void Copier_Error(UIError err)
        {
            // Error handler
            string msg = string.Format("Error copying file {0}\n{1}\nClick OK to continue copying files", err.path, err.msg);
            err.result = MessageBox.Show(msg, @"Copy error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }

        private void Copier_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Operation completed, update UI
            if (!File.Exists(Destination))
                File.Copy(Source, Destination, true);

            Thread.Sleep(1000);
            ChangeUi(false);

            if (finish) Finished();
            else finish = true;
        }

        private void ChangeUi(bool docopy)
        {
            Prb_Copier.Visible = docopy;
            Prb_Copier.Value = 0;
        }

        private void Saving_Progress_Load(object sender, EventArgs e)
        {
            Tmr_Count.Start();
            ChangeUi(true); 
            mCopier.RunWorkerAsync();
        }
    }
}

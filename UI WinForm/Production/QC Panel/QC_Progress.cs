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
        private readonly SkillContext _db = new SkillContext();
        public List<string> _pro_files_name = new List<string>();
        public Performance _performance = new Performance();
        public NewJob _job = new NewJob();
        public User _user = new User();
        public double pro_Time, qc_Time;
        public string _myService;
        public bool QC, finish = false;
        public int _fileAmount;


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

        public QC_Progress()
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

        private void Copier_DoWork(object sender, DoWorkEventArgs e)
        {

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

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            var currentTime = DateTime.Now;
            DateTime today = currentTime.Date;
            if (_performance.Shift == "Night" & currentTime.ToString("tt").ToUpper() == "AM")
                today = currentTime.AddDays(-1).Date;

            Log log = new Log();
            //My_Job Report Entry in Log Table
            foreach (string file in _pro_files_name)
            {
                if (file == null)
                    break;

                if (!string.IsNullOrEmpty(_myService))
                {
                    log = _db.Logs
                        .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == file & x.Status == "Running" & x.Name == _user.Short_Name & x.Service == _myService);

                    log.ProTime += pro_Time;
                    log.EndTime = currentTime;
                    log.Status = "Done";
                    log.Quality = 100;
                    log.Up = 0;

                    if (log.ProTime != 0)
                        log.Efficiency = (int)(log.TargetTime / log.ProTime * 100);
                }

                if (QC)
                {
                    log = _db.Logs
                        .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == file & x.Status == "Running" & x.Name == _user.Short_Name & x.Service == "QC");

                    log.ProTime += qc_Time;
                    log.EndTime = currentTime;
                    log.Status = "Done";
                    log.Up = 0;

                    if (log.ProTime != 0)
                        log.Efficiency = (int)(log.TargetTime / log.ProTime * 100);
                }

                --_fileAmount;
                //Prb_Copier.Increment(1);
            }

            //Job Report Entry in Job Table
            int fileCount = _db.Logs
                .Where(x => x.JobId == _job.JobId & x.Service == "QC")
                .Count();

            if (fileCount != 0)
            {
                double qcTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Service == "QC")
                    .Sum(x => x.ProTime);

                _job.QcTime = qcTime / fileCount;
            }

            _job.OutputAmount = fileCount;
            _job.Up = 0;

            //My_Job Report Entry in My_Job Table
            MyJob my_job;
            if (!string.IsNullOrEmpty(_myService))
            {
                my_job = _db.My_Jobs
                .FirstOrDefault(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == _myService);

                if (my_job == null)
                {
                    my_job = new MyJob
                    {
                        JobId = _job.JobId,
                        Name = _user.Short_Name,
                        Service = _myService,
                        Date = currentTime.Date,
                        StartTime = log.StartTime
                    };

                    _db.My_Jobs.Add(my_job);
                }

                fileCount = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Status == "Done" & x.Name == _user.Short_Name &
                                x.Service == _myService & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                    .Select(x => x.Image)
                    .Distinct()
                    .Count();

                my_job.Amount = fileCount;
                if (fileCount != 0)
                {
                    my_job.TotalJobTime = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Status == "Done" & x.Name == _user.Short_Name &
                                x.Service == _myService & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.TargetTime);

                    my_job.JobTime = my_job.TotalJobTime / fileCount;

                    my_job.TotalProTime = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Status == "Done" & x.Name == _user.Short_Name &
                                    x.Service == _myService & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.ProTime);

                    my_job.ProTime = my_job.TotalProTime / fileCount;

                    if (my_job.ProTime != 0)
                        my_job.Efficiency = (int)(my_job.JobTime / my_job.ProTime * 100);
                }

                my_job.EndTime = currentTime;
                my_job.Up = 0;
            }

            if (QC)
            {
                my_job = _db.My_Jobs
                .FirstOrDefault(x => x.JobId == _job.JobId & x.Name == _user.Short_Name & x.Service == "QC");

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

                fileCount = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Status == "Done" & x.Name == _user.Short_Name &
                                x.Service == "QC" & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                    .Select(x => x.Image)
                    .Distinct()
                    .Count();

                my_job.Amount = fileCount;
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
            }

            //My_Job Performance Entry in Performance Table
            Performance performance;
            performance = _db.Performances
                .FirstOrDefault(x => x.Name == _user.Short_Name & x.Date == today);

            fileCount = _db.My_Jobs
                .Where(x => x.Name == _user.Short_Name & x.Date == today)
                .Count();

            if (fileCount != 0)
            {
                performance.File = _db.My_Jobs
                        .Where(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.Amount);

                performance.JobTime = _db.My_Jobs
                        .Where(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.TotalJobTime);

                performance.ProTime = _db.My_Jobs
                        .Where(x => x.Name == _user.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= currentTime)
                        .Sum(x => x.TotalProTime);

                if (performance.ProTime != 0)
                    performance.Efficiency = (int)(performance.JobTime / performance.ProTime * 100);
            }

            performance.Up = 0;
            _db.SaveChanges();

            var qc_dashboard = QcDashboard.GetInstance();
            qc_dashboard._performance = _performance;

            Tmr_Count.Stop();

            if (finish) Finished();
            else finish = true;
        }

        void Finished()
        {
            this.Close();
        }

        private void QC_Progress_Load(object sender, EventArgs e)
        {
            Tmr_Count.Start();
            ChangeUi(true);
            mCopier.RunWorkerAsync();
        }
    }
}

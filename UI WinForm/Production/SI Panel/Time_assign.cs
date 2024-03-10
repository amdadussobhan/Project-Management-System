using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    public partial class Time_assign : Form
    {
        public User User { get; set; }

        public Time_assign()
        {
            InitializeComponent();
        }

        private static Time_assign _instance;

        public static Time_assign GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Time_assign();
            else
                _instance.BringToFront();
            return _instance;
        }

        SkillContext _db = new SkillContext();
        public string _jobId, _type, _team, _loc;
        public double _jobTime, _clipping = 0, _basic = 0, _pre_process = 0, _post_process = 0;

        private async void Time_assign_Load(object sender, EventArgs e)
        {
            var progress = new Progress<ProgressReport>();
            progress.ProgressChanged += (o, report) => {
                Prb_Assign.Value = report.PercentComplete;
                Prb_Assign.Update();
            };
            await Assign_Time(progress);
            this.Close();
        }

        private Task Assign_Time(IProgress<ProgressReport> progress)
        {
            var progressReport = new ProgressReport();
            string[] files = Directory.GetFiles(_loc, "*", SearchOption.AllDirectories);
            int index = 1, totalProgress = files.Count();

            var fileNames = files.Select(Path.GetFileNameWithoutExtension).ToList();
            var existingImageTimes = _db.ImageTime
                .Where(it => fileNames.Contains(it.Image) && it.Job_ID == _jobId)
                .ToDictionary(it => it.Image);

            return Task.Run(() => {
                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (!existingImageTimes.TryGetValue(fileName, out var imageTime))
                    {
                        imageTime = new ImageTime
                        {
                            Job_ID = _jobId,
                            Image = fileName,
                        };
                        _db.ImageTime.Add(imageTime);
                    }

                    // Update properties
                    imageTime.Type = _type;
                    imageTime.Total_Time = _jobTime;
                    imageTime.Clipping_Time = _clipping;
                    imageTime.Basic_Time = _basic;
                    imageTime.Pre_Process = _pre_process;
                    imageTime.Post_Process = _post_process;
                    imageTime.Assigner = User.Short_Name;

                    // Update progress
                    progressReport.PercentComplete = index++ * 100 / totalProgress;
                    progress.Report(progressReport);
                }
                _db.SaveChanges();
            });

            //var progressReport = new ProgressReport();
            //string[] files = Directory.GetFiles(_loc, "*", SearchOption.AllDirectories);
            //int index = 1, totalProgress = files.Count();

            //return Task.Run(() => {
            //    foreach (string file in files)
            //    {
            //        string fileName = Path.GetFileNameWithoutExtension(file);
            //        var imageTime = _db.ImageTime.FirstOrDefault(x => x.Job_ID == _jobId & x.Image == fileName);

            //        if (imageTime == null)
            //        {
            //            imageTime = new ImageTime
            //            {
            //                Job_ID = _jobId,
            //                Image = fileName,
            //            };
            //            _db.ImageTime.Add(imageTime);
            //        }

            //        imageTime.Type = _type;
            //        imageTime.Total_Time = _jobTime;
            //        imageTime.Clipping_Time = _clipping;
            //        imageTime.Basic_Time = _basic;
            //        imageTime.Pre_Process = _pre_process;
            //        imageTime.Post_Process = _post_process;

            //        progressReport.PercentComplete = index++ * 100 / totalProgress;
            //        progress.Report(progressReport);
            //    }
            //    _db.SaveChanges();
            //});
        }
    }
}

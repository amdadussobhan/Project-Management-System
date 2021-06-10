using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Skill_PMS.UI_WinForm.admin_Panel
{
    public partial class AdminPanel : Form
    {
        private readonly Common _common = new Common();
        private readonly SkillContext _db = new SkillContext();
        private DateTime _nowTime;

        public AdminPanel()
        {
            InitializeComponent();
        }

        private static AdminPanel _instance;
        public static AdminPanel GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new AdminPanel();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Update_Shift_Report()
        {
            var date = _nowTime.Date;
            string shift = _common.Current_Shift();
            var starTime = _common.Shift_Time(shift);

            if (shift == "Night" & _nowTime.ToString("tt").ToUpper() == "AM")
                date = starTime.AddDays(-1).Date;

            var shiftReport = _db.Shift_Reports
                   .FirstOrDefault(x => x.Date == date & x.Shift == shift);

            if (shiftReport == null)
            {
                shiftReport = _common.Add_New_Shift_Report(date, shift);
                shiftReport = _db.Shift_Reports
                .FirstOrDefault(x => x.Date == date & x.Shift == shift);
            }

            var count = _db.Logs
                .Where(x => x.StartTime >= starTime & x.StartTime <= _nowTime & x.Status == "Done" & x.Service != "QC")
                .Select(x => x.Image)
                .Distinct()
                .Count();

            if (count != 0)
            {
                var achiveLoad = _db.Logs
                    .Where(x => x.StartTime >= starTime & x.StartTime <= _nowTime & x.Status == "Done" & x.Service != "QC")
                    .Sum(x => x.TargetTime);

                var achiveProTime = _db.Logs
                    .Where(x => x.StartTime >= starTime & x.StartTime <= _nowTime & x.Status == "Done" & x.Service != "QC")
                    .Sum(x => x.ProTime);

                var quality = _db.Logs
                    .Where(x => x.StartTime >= starTime & x.StartTime <= _nowTime & x.Status == "Done" & x.Service != "QC")
                    .Average(x => x.Quality);

                var qcCount = _db.Logs
                    .Where(x => x.StartTime >= starTime & x.StartTime <= _nowTime & x.Status == "Done" & x.Service == "QC")
                    .Select(x => x.Image)
                    .Distinct()
                    .Count();

                shiftReport.AchieveLoad = achiveLoad;
                shiftReport.Quality = (int)quality;
                shiftReport.AchieveProTime = achiveProTime;

                if (shiftReport.TotalLoad > achiveLoad)
                    shiftReport.HandLoad = shiftReport.TotalLoad - achiveLoad;

                if (shiftReport.TotalFile > count)
                    shiftReport.HandFile = shiftReport.TotalFile - count;

                shiftReport.ProDone = count;
                shiftReport.QcDone = qcCount;

                if (shiftReport.TotalLoad != 0)
                    shiftReport.TargetAchieve = (int)((shiftReport.AchieveLoad / shiftReport.TotalLoad) * 100);

                if (shiftReport.AchieveProTime != 0)
                    shiftReport.Efficiency = (int)((shiftReport.AchieveLoad / shiftReport.AchieveProTime) * 100);
            }

            if(shiftReport.Capacity == 0)
                shiftReport.Capacity = _common.Current_Designers().Count * 420;

            //generate last 24 input
            var startday = _common.Shift_Time("Morning");
            if(shift == "Night" & _nowTime.ToString("tt").ToUpper() == "AM")
                startday = startday.AddDays(-1);

            count = _db.New_Jobs
                .Where(x => x.Incoming >= startday & x.Incoming <= _nowTime)
                .Count();

            var totalInput = 0;
            if (count != 0)
            {
                totalInput = _db.New_Jobs
                    .Where(x => x.Incoming >= startday & x.Incoming <= _nowTime)
                    .Sum(x => x.InputAmount);
            }

            count = _db.Logs
                .Where(x => x.StartTime >= startday & x.StartTime <= _nowTime & x.Status == "Done" & x.Service != "QC")
                .Select(x => x.Image)
                .Distinct()
                .Count();

            shiftReport.Last24Input = totalInput;
            shiftReport.Last24Output = count;
            shiftReport.Up = 0;
            _db.SaveChanges();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            _nowTime = DateTime.Now;
            _common.Change_Shift();
            var shift = _common.Current_Shift();
            var date = _common.Shift_Date(_nowTime, shift);
            var shiftReport = _db.Shift_Reports
                   .FirstOrDefault(x => x.Date == date & x.Shift == shift);

            if (shiftReport == null)
                shiftReport = _common.Add_New_Shift_Report(date, shift);

            shiftReport.Capacity = _common.Current_Designers().Count * 420;
            shiftReport.Up = 0;
            _db.SaveChanges();

            if (shiftReport.TotalLoad == 0)
                _common.Check_Workload(shift);

            //Update_Shift_Report();
            //Upload_Shift_Report();
            //Upload_Workloads();
            //Upload_New_Jobs();
            //Upload_My_Jobs();
            //Upload_Performances();
            //Upload_Logs();

            //try{Upload_Shift_Report();}
            //catch (Exception){}

            //try{Upload_Workloads();}
            //catch (Exception) { }

            //try { Upload_New_Jobs(); }
            //catch (Exception) { }

            //try { Upload_My_Jobs(); }
            //catch (Exception) { }

            //try { Upload_Performances(); }
            //catch (Exception) { }

            //try{Upload_Logs();}
            //catch (Exception) { }

            Tmr_Count.Start();
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            _nowTime = DateTime.Now;

            if (Lbl_Status.Text == @"Running")
            {
                Lbl_Status.Text = @"Updated";
                Lbl_Status.ForeColor = Color.Green;
            }
            else
            {
                Lbl_Status.Text = @"Running";
                Lbl_Status.ForeColor = Color.OrangeRed;
            }

            //Update_Shift_Report();
            //_common.Change_Shift();
            //Upload_Shift_Report();
            //Upload_Workloads();
            //Upload_New_Jobs();
            //Upload_My_Jobs();
            //Upload_Performances();
            //Upload_Logs();

            //try { Update_Shift_Report(); }
            //catch (Exception) { }

            //try { _common.Change_Shift(); }
            //catch (Exception) { }

            //try { Upload_Shift_Report(); }
            //catch (Exception) { }

            //try { Upload_Workloads(); }
            //catch (Exception) { }

            //try { Upload_New_Jobs(); }
            //catch (Exception) { }

            //try { Upload_My_Jobs(); }
            //catch (Exception) { }

            //try { Upload_Performances(); }
            //catch (Exception) { }

            try { Upload_Logs(); }
            catch (Exception) { }

            Tmr_Count.Start();
        }

        private void Upload_Shift_Report()
        {
            var shiftReports = _db.Shift_Reports
                .Where(x => x.Up == 0)
                .ToList();
                
            foreach (var sR in shiftReports)
            {
                var query = @" Select * From `shift_reports` Where `SL` = '" + sR.Id + "' and `Loc` = 'DHK' ";

                int CapacityAchieve = 0;
                if (sR.Capacity != 0)
                    CapacityAchieve = (int)(sR.AchieveProTime / sR.Capacity * 100);                

                if (_common.IsExist(query))
                {
                    query = @" Update `shift_reports` Set Capacity = '" + sR.Capacity + "', CapacityAchieve = '"+ CapacityAchieve + "', RevenueTarget = '', RevenueAchieve = '', AchieveLoad = '" + sR.AchieveLoad + "', " +
                        " AchieveProTime = '" + (int)(sR.AchieveProTime) + "', NewFile = '" + sR.NewFile + "', PreFile = '" + sR.PreFile + "', PreLoad = '"+ sR.PreLoad + "'," + " TotalFile = '" + sR.TotalFile + "', TotalLoad = '" + sR.TotalLoad + "', " +
                        " HandFile = '" + sR.HandFile + "', HandLoad = '" + sR.HandLoad + "', Last24Input = '" + sR.Last24Input + "', Last24Output = '" + sR.Last24Output + "', " + " ProDone = '" + sR.ProDone + "', " +
                        " QcDone = '" + sR.QcDone + "', Quality = '" + sR.Quality + "', TargetAchieve = '" + sR.TargetAchieve + "', Efficiency = '" + sR.Efficiency + "' Where `SL` = '" + sR.Id + "' ";
                }
                else
                {
                    query = @" INSERT INTO `shift_reports`(`SL`, `Loc`, `Date`, `Shift`, `Capacity`, `CapacityAchieve`, `RevenueTarget`, `RevenueAchieve`, `AchieveLoad`, `AchieveProTime`, 
                        `NewFile`, `PreFile`, `PreLoad`, `TotalFile`, `TotalLoad`, `HandFile`, `HandLoad`, `Last24Input`, `Last24Output`, `ProDone`, `QcDone`, `Quality`, `TargetAchieve`, `Efficiency`) 
                        Values('" + sR.Id + "', 'DHK', '" + sR.Date.ToString("yyyy-MM-dd") + "', '" + sR.Shift + "', '" + sR.Capacity + "', '" + CapacityAchieve + "', '', '', '" + sR.AchieveLoad + "', '"
                        + (int)(sR.AchieveProTime) + "', '" + sR.NewFile + "', '" + sR.PreFile + "', '" + sR.PreLoad + "', " + " '" + sR.TotalFile + "', '" + sR.TotalLoad  + "', '" + sR.HandFile + "', '" + sR.HandLoad + "', '" 
                        + sR.Last24Input + "', '" + sR.Last24Output+ "', '" + sR.ProDone + "', '" + sR.QcDone + "', '" + sR.Quality + "', '" + sR.TargetAchieve + "', '" + sR.Efficiency + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                sR.Up = 1;
            }
            _db.SaveChanges();
            Common.Online.Close();
        }        

        private void Upload_New_Jobs()
        {
            var newJobs = _db.New_Jobs
                .Where(x => x.Up == 0)
                .ToList();

            foreach (var nJ in newJobs)
            {
                var query = @" Select * From `new_jobs` Where `SL` = '" + nJ.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `new_jobs` Set JobId = '" + nJ.JobId + "', Client = '" + nJ.Client + "', Category = '" + nJ.Category + "', Service = '" + nJ.Service + "', Status = '" + nJ.Status + "'," +
                            " Type = '" + nJ.Type + "'," + " Delivery = '" + nJ.Delivery.ToString("yyyy-MM-dd HH:mm:ss") + "', InputAmount = '" + nJ.InputAmount + "', ProDone = '" + nJ.ProDone + "', " +
                            " OutputAmount = '" + nJ.OutputAmount + "', Price = '" + nJ.Price + "', Taka = '" + nJ.Taka + "', Currency = '" + nJ.Currency + "', ActualTime = '" + nJ.ActualTime + "'," +
                            " TargetTime = '" + nJ.TargetTime + "', ProTime = '" + Math.Round(nJ.ProTime, 2)+ "', QcTime = '" + nJ.QcTime + "', ActualEfficiency = '" + nJ.ActualEfficiency + "', TargetEfficiency = '" + nJ.TargetEfficiency + "', " +
                            " Receiver = '" + nJ.Receiver + "', Sender = '" + nJ.Sender + "', SiName = '" + nJ.SiName + "', QcName = '" + nJ.QcName + "' Where `SL` = '" + nJ.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query =
                        @" INSERT INTO `new_jobs`(`SL`, `Loc`, `Date`, `JobId`, `Client`, `Category`, `Service`, `Status`, `Type`, `Incoming`, `Delivery`, `InputAmount`, `ProDone`, `OutputAmount`,
                            `Price`, `Taka`, `Currency`, `ActualTime`, `TargetTime`, `ProTime`, `QcTime`, `ActualEfficiency`, `TargetEfficiency`, `Receiver`, `Sender`, `SiName`, `QcName`) 
                        Values('" + nJ.Id + "', 'DHK', '" + nJ.Date.ToString("yyyy-MM-dd") + "', '" + nJ.JobId + "', '" + nJ.Client + "', '" + nJ.Category+ "', '" + nJ.Service+ "', '" +
                            nJ.Status+ "', '" + nJ.Type+ "', " + " '" + nJ.Incoming.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + nJ.Delivery.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + 
                            nJ.InputAmount+ "', '" + nJ.ProDone+ "', '" + nJ.OutputAmount+ "', '" + nJ.Price+ "', '" + nJ.Taka+ "', '" + nJ.Currency+ "', '" + nJ.ActualTime+ "', '" + nJ.TargetTime+ "', '" +
                            Math.Round(nJ.ProTime, 2)+ "', '" + nJ.QcTime+ "', '" + nJ.ActualEfficiency+ "', '" + nJ.TargetEfficiency+ "', '" + nJ.Receiver+ "', '" + nJ.Sender+ "', '" + nJ.SiName+ "', '" + nJ.QcName+ "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                nJ.Up = 1;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        private void Upload_My_Jobs()
        {
            var my_jobs = _db.My_Jobs
                .Where(x => x.Up == 0)
                .ToList();

            foreach (var m in my_jobs)
            {
                var query = @" Select * From `my_jobs` Where `SL` = '" + m.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `my_jobs` Set EndTime = '" + m.EndTime + "', Status = '" + m.Status + "', File = '" + m.Amount 
                        + "', JobTime = '" + m.JobTime + "'," + " ProTime = '" + Math.Round(m.ProTime, 2)+ "', TotalJobTime = '" + m.TotalJobTime + "', TotalProTime = '" + Math.Round(m.TotalProTime, 2)
                        + "', Efficiency = '" + m.Efficiency + "', Quality = '" + m.Quality + "' Where `SL` = '" + m.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query =
                        @" INSERT INTO `my_jobs`(`SL`, `Loc`, `Date`, `StartTime`, `EndTime`, `Name`, `JobId`, `Service`, `Status`, `File`, `JobTime`, `ProTime`,
                            `TotalJobTime`, `TotalProTime`, `Efficiency`, `Quality`) 
                        Values('" + m.Id + "', 'DHK', '" + m.Date.ToString("yyyy-MM-dd") + "', '" + m.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '"
                            + m.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + m.Name+ "', '" + m.JobId + "', '" + m.Service + "', '" + m.Status + "', " + " '" + m.Amount + "', '"
                            + m.JobTime + "', '" + Math.Round(m.ProTime, 2) + "',  '" + m.TotalJobTime + "',  '" + Math.Round(m.TotalProTime, 2)+ "', '" + m.Efficiency + "', '" + m.Quality + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                m.Up = 1;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        private void Upload_Logs()
        {
            var logs = _db.Logs
                .Where(x => x.Up == 0 & x.Status == "Done")
                .OrderByDescending(x=>x.Id)
                .ToList();

            var count = 0;
            foreach (var l in logs)
            {
                var image = l.Image;
                if(image.Contains("\'"))
                    image = image.Replace("\'", "");

                var query = @" Select * From `logs` Where `SL` = '" + l.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `logs` Set EndTime = '" + l.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "', Status = '" + l.Status + "', ProTime = '" + Math.Round(l.ProTime, 2) + "'," +
                            " Remarks = '" + l.Remarks + "', Efficiency = '" + l.Efficiency + "', Quality = '" + l.Quality + "' Where `SL` = '" + l.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query =
                        @" INSERT INTO `logs`(`SL`, `Loc`, `Date`, `StartTime`, `EndTime`, `Name`, `JobId`, `Service`, `Category`,
                        `Status`, `ActualTime`, `TargetTime`, `ProTime`, `Image`,`Remarks`,`Efficiency`,`Quality`) 
                        Values('" + l.Id + "', 'DHK', '" + l.Date.ToString("yyyy-MM-dd") + "', '" + l.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" 
                            + l.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + l.Name + "', '" + l.JobId + "', '" + l.Service + "', '" + l.Category + "', '" + l.Status + "', '" 
                            + l.ActualTime + "', '" + Math.Round(l.TargetTime, 2) + "', " + " '" + Math.Round(l.ProTime, 2) + "', '" + image + "', '" + l.Remarks + "', '" + l.Efficiency + "', '" + l.Quality + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                l.Up = 1;
                if (count++ > 99)
                    break;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        private void Upload_Performances()
        {
            var performances = (from p in _db.Performances
                join u in _db.Users on p.Name equals u.Short_Name
                where (u.Role == "" | u.Role == "QC" | u.Role == "SI") & p.Up == 0
                select p).ToList();

            var count = 0;
            foreach (var p in performances)
            {
                var query = @" Select * From `performances` Where `SL` = '" + p.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `performances` Set Logout = '" + p.Logout.ToString("yyyy-MM-dd HH:mm:ss") + "', Status = '" + p.Status + "', WorkingTime = '" + p.WorkingTime + "', File = '" + p.File + "'," +
                            " JobTime = '" + p.JobTime + "'," + " ProTime = '" + Math.Round(p.ProTime,2) + "', Efficiency = '" + p.Efficiency + "', Quality = '" + p.Quality + "' Where `SL` = '" + p.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    var user = _db.Users
                        .Where(x => x.Short_Name == p.Name)
                        .FirstOrDefault();

                    query =
                        @" INSERT INTO `performances`(`SL`, `Loc`, `Date`, `Login`, `Logout`, `Shift`, `Status`, `Name`, `Role`, `WorkingTime`, `File`, `JobTime`, `ProTime`, `Efficiency`, `Quality`) 
                        Values('" + p.Id + "', 'DHK', '" + p.Date.ToString("yyyy-MM-dd") + "', '" + p.Login.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + p.Logout.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                            p.Shift+ "', '" + p.Status+ "', '" + p.Name+ "', '" + user.Role + "', '" + p.WorkingTime+ "', " + " '" + p.File + "', '" + p.JobTime + "', '" + Math.Round(p.ProTime,2)+ "', '" + p.Efficiency+ "', '" + p.Quality+ "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                p.Up = 1;
                if (count++ > 99)
                    break;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        private void Upload_Workloads()
        {
            var workloads = _db.Workloads
                .Where(x => x.Up == 0)
                .ToList();

            foreach (var workload in workloads)
            {
                var query = @" Select * From `work_loads` Where `SL` = '" + workload.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `work_loads` Set File = '" + workload.File + "', Time = '" + workload.Time +
                            "' Where `SL` = '" + workload.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query = @" INSERT INTO `work_loads`(`SL`, `Loc`, `Date`, `Shift`, `JobId`, `File`, `Time`) 
                        Values('" + workload.Id + "', 'DHK', '" + workload.Date.ToString("yyyy-MM-dd") + "', '" + workload.Shift +
                            "', '" + workload.JobId + "', '" + workload.File + "', '" + workload.Time + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                workload.Up = 1;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }        
    }
}

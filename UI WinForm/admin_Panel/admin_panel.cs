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
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Skill_PMS.UI_WinForm.admin_Panel
{
    public partial class AdminPanel : Form
    {
        private readonly Common _common = new Common();
        private SkillContext _db = new SkillContext();
        public DateTime _nowTime;
        int _count = 0;

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

        private async void AdminPanel_Load(object sender, EventArgs e)
        {
            _nowTime = DateTime.Now;
            var shift = _common.Current_Shift();
            var date = _common.Shift_Date(_nowTime, shift);
            var shiftReport = _db.Shift_Reports.FirstOrDefault(x => x.Date == date & x.Shift == shift & x.Team == "");
        }

        private async void Tmr_Count_Tick(object sender, EventArgs e)
        {
            Tmr_Count.Stop();
            _nowTime = DateTime.Now;
            _db = new SkillContext();

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

            await Task.Run(() => Upload_Users());
            //await Task.Run(() => Upload_Workloads());
            //await Task.Run(() => Upload_RunningJobs());
            await Task.Run(() => Upload_New_Jobs());
            //await Task.Run(() => Upload_Feedback());
            await Task.Run(() => Upload_Performances());

            if (_count++ >= 9)
            {
                //await Task.Run(() => _common.Update_Shift_Report());
                //await Task.Run(() => Upload_Shift_Report());
                //await Task.Run(() => Upload_Performances());
                await Task.Run(() => Upload_Logs());
                //await Task.Run(() => Upload_My_Jobs());
                _count = 0;
            }
            Tmr_Count.Start();
        }

        public void Upload_Shift_Report()
        {
            var shiftReports = _db.Shift_Reports.Where(x => x.Up == 0).ToList();

            foreach (var sR in shiftReports)
            {
                var query = @" Select * From `shift_reports` Where `SL` = '" + sR.Id + "' and `Loc` = 'DHK' ";

                int CapacityAchieve = 0;
                if (sR.Capacity != 0)
                    CapacityAchieve = (int)(sR.ProAchieve / sR.Capacity * 100);

                if (_common.IsExist(query))
                {
                    query = @" Update `shift_reports` Set Capacity = '" + sR.Capacity + "', QC_Capacity = '" + sR.QC_Capacity + "', CapacityAchieve = '" + CapacityAchieve + "', RevenueTarget = '', RevenueAchieve = '', AchieveLoad = '" + sR.LoadAchieve + "', " +
                        " AchieveProTime = '" + (int)sR.ProAchieve + "', NewFile = '" + sR.NewFile + "', PreFile = '" + sR.PreFile + "', PreLoad = '" + (int)sR.PreLoad + "'," + " TotalFile = '" + sR.TotalFile + "', " + " OutputFile = '" + sR.OutputFile + "', TotalLoad = '" + (int)sR.TotalLoad + "', " +
                        " HandFile = '" + sR.HandFile + "', HandLoad = '" + (int)sR.HandLoad + "', Last24Input = '" + sR.Last24Input + "', Last24Output = '" + sR.Last24Output + "', " + " ProDone = '" + sR.ProDone + "', " +
                        " QcDone = '" + sR.QcDone + "', Quality = '" + sR.Quality + "', TargetAchieve = '" + sR.TargetAchieve + "', Efficiency = '" + sR.Efficiency + "' Where `SL` = '" + sR.Id + "' ";
                }
                else
                {
                    query = @" INSERT INTO `shift_reports`(`SL`, `Loc`, `Date`, `Shift`, `Team`, `Capacity`, `QC_Capacity`, `CapacityAchieve`, `RevenueTarget`, `RevenueAchieve`, `AchieveLoad`, `AchieveProTime`, 
                        `NewFile`, `PreFile`, `PreLoad`, `TotalFile`, `OutputFile`, `TotalLoad`, `HandFile`, `HandLoad`, `Last24Input`, `Last24Output`, `ProDone`, `QcDone`, `Quality`, `TargetAchieve`, `Efficiency`) 
                        Values('" + sR.Id + "', 'DHK', '" + sR.Date.ToString("yyyy-MM-dd") + "', '" + sR.Shift + "', '" + sR.Team + "', '" + sR.Capacity + "', '" + sR.QC_Capacity+ "', '" + CapacityAchieve + "', '', '', '" + sR.LoadAchieve + "', '"
                        + (int)sR.ProAchieve + "', '" + sR.NewFile + "', '" + sR.PreFile + "', '" + (int)sR.PreLoad + "', " + " '" + sR.TotalFile + "', '" + sR.OutputFile + "', '" + (int)sR.TotalLoad + "', '" + sR.HandFile + "', '" + (int)sR.HandLoad + "', '"
                        + sR.Last24Input + "', '" + sR.Last24Output + "', '" + sR.ProDone+ "', '" + sR.QcDone + "', '" + sR.Quality + "', '" + sR.TargetAchieve + "', '" + sR.Efficiency + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                sR.Up = 1;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        public void Upload_New_Jobs()
        {
            int count = 0;
            var newJobs = _db.New_Jobs.Where(x => x.Up == 0).OrderByDescending(x => x.Id).ToList();

            foreach (var nJ in newJobs)
            {
                var query = @" Select * From `new_jobs` Where `SL` = '" + nJ.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `new_jobs` Set JobId = '" + nJ.JobId + "', Folder = '" + nJ.Folder + "', Client = '" + nJ.Client + "', Category = '" + nJ.Category + "', Service = '" + nJ.Service + "', Status = '" + nJ.Status + "'," +
                            " Type = '" + nJ.Type + "'," + " Delivery = '" + nJ.Delivery.ToString("yyyy-MM-dd HH:mm:ss") + "', InputAmount = '" + nJ.InputAmount + "', " +
                            " OutputAmount = '" + nJ.OutputAmount + "', Price = '" + nJ.Price + "', Taka = '" + nJ.Taka + "', ActualTime = '" + nJ.ActualTime + "'," +
                            " TargetTime = '" + nJ.TargetTime + "', ProTime = '" + Math.Round(nJ.ProTime, 2)+ "', QcTime = '" + nJ.QcTime + "', ActualEfficiency = '" + nJ.ActualEfficiency + "', TargetEfficiency = '" + nJ.TargetEfficiency + "', " +
                            " Receiver = '" + nJ.Receiver + "', Sender = '" + nJ.Sender + "', SiName = '" + nJ.SiName + "', QcName = '" + nJ.QcName + "', Team = '" + nJ.Team+ "' Where `SL` = '" + nJ.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query =
                        @" INSERT INTO `new_jobs`(`SL`, `Loc`, `Date`, `JobId`, `Folder`, `Client`, `Category`, `Service`, `Status`, `Type`, `Incoming`, `Delivery`, `InputAmount`, `OutputAmount`,
                            `Price`, `Taka`, `ActualTime`, `TargetTime`, `ProTime`, `QcTime`, `ActualEfficiency`, `TargetEfficiency`, `Receiver`, `Sender`, `SiName`, `QcName`, `Team`) 
                        Values('" + nJ.Id + "', 'DHK', '" + nJ.Date.ToString("yyyy-MM-dd") + "', '" + nJ.JobId + "', '" + nJ.Folder+ "', '" + nJ.Client + "', '" + nJ.Category+ "', '" + nJ.Service+ "', '" +
                            nJ.Status+ "', '" + nJ.Type+ "', " + " '" + nJ.Incoming.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + nJ.Delivery.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + 
                            nJ.InputAmount+ "', '" + nJ.OutputAmount+ "', '" + nJ.Price+ "', '" + nJ.Taka+ "', '" + nJ.ActualTime+ "', '" + nJ.TargetTime+ "', '" +
                            Math.Round(nJ.ProTime, 2)+ "', '" + nJ.QcTime+ "', '" + nJ.ActualEfficiency+ "', '" + nJ.TargetEfficiency+ "', '" + nJ.Receiver+ "', '" + nJ.Sender+ "', '" + nJ.SiName+ "', '" + nJ.QcName+ "', '" + nJ.Team + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                nJ.Up = 1;

                if (count++ >= 9)
                    break;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        public void Upload_Price_Time()
        {
            int count = 0;
            var price_time = _db.Price_Times.Where(x => x.ID == 0).ToList();

            foreach (var pt in price_time)
            {
                var query = @" Select * From `pms_price_time` Where `SL` = '" + pt.Up + "' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `pms_price_time` Set client = '" + pt.Client + "', category = '" + pt.Category + "', lock_time = '" 
                        + pt.Lock_Time + "', price = '" + pt.Price + "', " + " type = '" + pt.Type + "', rate_id = '" + pt.Rate_ID + "' Where `SL` = '" + pt.ID+ "' ";
                }
                else
                {
                    query =
                        @" INSERT INTO `pms_price_time`(`SL`, `client`, `category`, `lock_time`, `price`, `type`, `rate_id`) 
                        Values('" + pt.ID + "', '" + pt.Client + "', '" + pt.Category + "', '" + pt.Lock_Time + "', '" + pt.Price + "', '" + pt.Type + "', '" + pt.Rate_ID + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                pt.Up = 1;

                if (count++ >= 9)
                    break;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        public void Upload_Feedback()
        {
            int count = 0;
            var feedback = _db.Feedback.Where(x => x.Up == 0).OrderByDescending(x => x.Id).ToList();

            foreach (var fd in feedback)
            {
                var query = @" Select * From `feedback` Where `SL` = '" + fd.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `feedback` Set Remarks = '" + fd.Remarks + "' Where `SL` = '" + fd.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query =
                        @" INSERT INTO `feedback`(`SL`, `Loc`, `Name`, `JobId`, `Folder`, `Reporter`, `Image`, `Remarks`, `Location`, `ReportTime`) 
                        Values('" + fd.Id + "', 'DHK', '" + fd.Name + "', '" + fd.JobId + "', '" + fd.Folder + "', '" + fd.Reporter + "', '" +
                        fd.Image + "', '" + fd.Remarks + "', '" + fd.Location + "',  '" + fd.ReportTime.ToString("yyyy-MM-dd HH:mm:ss") + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                fd.Up = 1;

                if (count++ >= 9)
                    break;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }



        public void Upload_Users()
        {
            int count = 0;
            var users = _db.Users.Where(x => x.UP == 0).ToList();

            foreach (var user in users)
            {
                var query = @" Select * From `users` Where `SL` = '" + user.ID + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @"Update `users` Set name = '" + user.Full_Name + "', short_name = '" + user.Short_Name + "', designation = '" + user.Designation + "', team = '" + user.Team+ "' Where `sl` = '" + user.ID + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query = @"INSERT INTO `users`(`sl`, `loc`, `name`, `short_name`, `email`, `designation`, `employee_id`, `team`) 
                        Values('" + user.ID + "', 'DHK', '" + user.Full_Name + "', '" + user.Short_Name + "', '"+user.Short_Name +"@skillgraphics.biz', '" + user.Designation + "', '" + user.Employee_ID + "',  '" + user.Team + "')";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                user.UP = 1;

                if (count++ >= 9)
                    _db.SaveChanges();

                if (count++ >= 99)
                    break;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        private void Upload_My_Jobs()
        {
            var my_jobs = _db.My_Jobs.Where(x => x.Up == 0).ToList();

            foreach (var m in my_jobs)
            {
                var query = @" Select * From `my_jobs` Where `SL` = '" + m.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `my_jobs` Set EndTime = '" + m.EndTime + "', Status = '" + m.Status + "', File = '" + m.Amount 
                        + "', JobTime = '" + m.JobTime + "'," + " ProTime = '" + Math.Round(m.ProTime, 2)+ "', TotalJobTime = '" + m.TotalJobTime + "', TotalProTime = '" 
                        + Math.Round(m.TotalProTime, 2) + "', Efficiency = '" + m.Efficiency + "', Quality = '" + m.Quality + "' Where `SL` = '" + m.Id + "' and `Loc` = 'DHK' ";
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

        public void Upload_Logs()
        {
            int count = 0;
            var logs = _db.Logs
                .Where(x => x.Up == 0 & x.Status == "Done")
                .OrderByDescending(x=>x.Id)
                .ToList();

            foreach (var log in logs)
            {
                var image = log.Image;
                if(image.Contains("\'"))
                    image = image.Replace("\'", "");

                var query = @" Select * From `logs` Where `SL` = '" + log.Id + "' and `Loc` = 'DHK' ";

                if (_common.IsExist(query))
                {
                    query = @" Update `logs` Set EndTime = '" + log.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "', Status = '" + log.Status + "', Type = '" + log.Type + "', ProTime = '" 
                        + Math.Round(log.ProTime, 2) + "'," + " Remarks = '" + log.Remarks + "', Rest_Time = '" + log.RestTime + "', Pause_Time = '" + log.PauseTime + "', Efficiency = '" 
                        + log.Efficiency + "', Quality = '" + log.Quality + "', Revenue = '" + log.Revenue + "', Support = '" + log.Support + "' Where `SL` = '" + log.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query =
                        @" INSERT INTO `logs`(`SL`, `Loc`, `Date`, `Shift`, `Revenue`, `Support`, `StartTime`, `EndTime`, `Name`, `JobId`, `Service`, `Type`, `Status`, 
                            `ActualTime`, `TargetTime`, `ProTime`, `Rest_Time`, `Pause_Time`, `Image`,`Remarks`,`Efficiency`,`Quality`) 
                        Values('" + log.Id + "', 'DHK', '" + log.Date.ToString("yyyy-MM-dd") + "', '" + log.Shift + "', '" + log.Revenue + "', '" + log.Support+ "','" 
                        + log.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '"  + log.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + log.Name + "', '" + log.JobId + "', '" 
                        + log.Service + "', '" + log.Type + "', '" + log.Status + "', '" + log.ActualTime + "', '" + Math.Round(log.TargetTime, 2) + "', " + " '" + Math.Round(log.ProTime, 2) + "', '" 
                        + log.RestTime + "', '" + log.PauseTime + "', '" + image + "', '" + log.Remarks + "', '" + log.Efficiency + "', '" + log.Quality + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                log.Up = 1;

                if (count++ > 9)
                    _db.SaveChanges();

                if (count++ > 99)
                    break;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        public void Upload_Performances()
        {
            int count = 0;
            //var performances = (from p in _db.Performances
            //    join u in _db.Users on p.Name equals u.Short_Name
            //    where (u.Role == "" | u.Role == "QC" | u.Role == "SI") & p.Up == 0
            //    select p).ToList();

            var performances = _db.Performances
                .Where(x => x.Up == 0)
                .OrderByDescending(x => x.Id)
                .ToList();

            foreach (var p in performances)
            {
                var query = @" Select * From `performances` Where `SL` = '" + p.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `performances` Set Shift = '" + p.Shift + "', Logout = '" + p.Logout.ToString("yyyy-MM-dd HH:mm:ss") + "', Status = '" 
                        + p.Status + "', WorkingTime = '" + p.WorkingTime + "', File = '" + p.File + "'," + " JobTime = '" + p.JobTime + "'," + " ProTime = '" 
                        + Math.Round(p.ProTime,2) + "', Efficiency = '" + p.Efficiency + "', Quality = '" + p.Quality + "', Support = '" + p.Support 
                        + "', Revenue = '" + p.Revenue + "' Where `SL` = '" + p.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    var user = _db.Users.Where(x => x.Short_Name == p.Name).FirstOrDefault();
                    query =
                        @" INSERT INTO `performances`(`SL`, `Loc`, `Date`, `Login`, `Logout`, `Shift`, `Status`, `Name`, `Support`, `WorkingTime`, `File`, `JobTime`, `ProTime`, `Efficiency`, `Quality`, `Revenue`) 
                        Values('" + p.Id + "', 'DHK', '" + p.Date.ToString("yyyy-MM-dd") + "', '" + p.Login.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + p.Logout.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                            p.Shift+ "', '" + p.Status+ "', '" + p.Name+ "', '" + p.Support + "', '" + p.WorkingTime+ "', " + " '" + p.File + "', '" + p.JobTime + "', '" 
                            + Math.Round(p.ProTime,2)+ "', '" + p.Efficiency+ "', '" + p.Quality+ "', '" + p.Revenue + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                p.Up = 1;

                if (count++ > 9)
                    _db.SaveChanges();

                if (count++ > 99)
                    break;
            }

            _db.SaveChanges();
            Common.Online.Close();
        }

        public void Upload_Workloads()
        {
            int count = 0;
            var workloads = _db.Workloads.Where(x => x.Up == 0).ToList();

            foreach (var workload in workloads)
            {
                var query = @" Select * From `work_loads` Where `SL` = '" + workload.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `work_loads` Set Team = '" + workload.Team + "', Type = '" + workload.Type + "', Service = '" + workload.Service + "', Input_File = '" + workload.Input_File + 
                        "', Target_Time = '" + workload.TargetTime + "', Output_File = '" + workload.Output_File + "', Total_Load = '" + workload.Total_Load + "', Load_Achieve = '" + workload.Load_Achieve + 
                        "', Pro_Time = '" + workload.ProTime + "', Pro_Achieve = '" + workload.Pro_Achieve + "' Where `SL` = '" + workload.Id + "' and `Loc` = 'DHK'; ";
                }
                else
                {
                    query = @" INSERT INTO `work_loads`(`SL`, `Loc`, `Date`, `JobId`, `Shift`, `Team`, `Type`, `Service`, `Input_File`, `Output_File`, `Target_Time`, `Total_Load`, `Load_Achieve`, `Pro_Time`, `Pro_Achieve`) 
                        Values('" + workload.Id + "', 'DHK', '" + workload.Date.ToString("yyyy-MM-dd") + "', '" + workload.JobId + "', '" + workload.Shift + "', '" + workload.Team + "','" + workload.Type + "','" 
                        + workload.Service+ "','" + workload.Input_File+ "', '" + workload.Output_File+ "', '" + workload.TargetTime + "', '" + workload.Total_Load + "', '" 
                        + workload.Load_Achieve + "', '" + workload.ProTime + "', '" + workload.Pro_Achieve + "'); ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                workload.Up = 1;

                if (count++ >= 9)
                    break;
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

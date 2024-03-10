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
using System.Text;

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
            await Task.Run(() => Upload_Logs());
        }

        private async void Tmr_Count_Tick(object sender, EventArgs e)
        {
            Tmr_Count.Stop();
            _nowTime = DateTime.Now;
            _db = null;
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
            await Task.Run(() => Upload_New_Jobs());
            await Task.Run(() => Upload_Performances());

            if (_count++ >= 9)
            {
                await Task.Run(() => Upload_Logs());
                _count = 0;
            }
            Tmr_Count.Start();
        }

        //public void sync()
        //{
        //    using (var mysqlContext = new MySqlDbContext())
        //    {
        //        foreach (var item in dataToSync)
        //        {
        //            var existingRecord = mysqlContext.YourEntities.FirstOrDefault(e => e.Id == item.Id);

        //            if (existingRecord == null)
        //            {
        //                mysqlContext.YourEntities.Add(item);
        //            }
        //            else
        //            {
        //                existingRecord.Property1 = item.Property1;
        //            }
        //        }
        //        mysqlContext.SaveChanges();
        //    }
        //}

        public void Upload_New_Jobs()
        {
            int count = 0;
            var newJobs = _db.New_Jobs.Where(x => x.Up == 0).OrderByDescending(x => x.Id).ToList();

            foreach (var nJ in newJobs)
            {
                var query = @" Select * From `new_jobs` Where `SL` = '" + nJ.Id + "' ";
                if (_common.IsExist(query))
                {
                    query = @" Update `new_jobs` Set Loc = '" + nJ.Loc + "', Date = '" + nJ.Date.ToString("yyyy-MM-dd") + "', JobId = '" + nJ.JobId + "', Folder = '" 
                        + nJ.Folder + "', Client = '" + nJ.Client + "', Category = '" + nJ.Category + "', Service = '" + nJ.Service + "', Status = '" 
                        + nJ.Status + "', Type = '" + nJ.Type + "', Incoming = '" + nJ.Incoming.ToString("yyyy-MM-dd HH:mm:ss") + "', Delivery = '" 
                        + nJ.Delivery.ToString("yyyy-MM-dd HH:mm:ss") + "', InputAmount = '" + nJ.InputAmount + "', ProDone = '" + nJ.ProDone + "', OutputAmount = '" 
                        + nJ.OutputAmount + "', Price = '" + nJ.Price + "', Taka = '" + nJ.Taka + "', ActualTime = '" + nJ.ActualTime + "', TargetTime = '" 
                        + nJ.TargetTime + "', ProTime = '" + Math.Round(nJ.ProTime, 2)+ "', QcTime = '" + nJ.QcTime + "', ActualEfficiency = '" 
                        + nJ.ActualEfficiency + "', TargetEfficiency = '" + nJ.TargetEfficiency + "', Receiver = '" + nJ.Receiver + "', Sender = '" 
                        + nJ.Sender + "', SiName = '" + nJ.SiName + "', QcName = '" + nJ.QcName + "', Team = '" + nJ.Team+ "', Up = '0', ProEnd = '"
                        + nJ.ProEnd.ToString("yyyy-MM-dd HH:mm:ss") + "' Where `SL` = '" + nJ.Id + "' ";
                }
                else
                {
                    query =
                        @" INSERT INTO `new_jobs`(`SL`, `Loc`, `Date`, `JobId`, `Folder`, `Client`, `Category`, `Service`, `Status`, `Type`, `Incoming`,
                            `Delivery`, `InputAmount`, `ProDone`, `OutputAmount`, `Price`, `Taka`, `ActualTime`, `TargetTime`, `ProTime`, 
                            `QcTime`, `ActualEfficiency`, `TargetEfficiency`, `Receiver`, `Sender`, `SiName`, `QcName`, `Team`, `ProEnd`, `Up`) 
                        Values('" + nJ.Id + "', '"+nJ.Loc+"' , '" + nJ.Date.ToString("yyyy-MM-dd") + "', '" + nJ.JobId + "', '" + nJ.Folder+ "', '" + nJ.Client + "', '" 
                            + nJ.Category+ "', '" + nJ.Service+ "', '" + nJ.Status+ "', '" + nJ.Type+ "', '" + nJ.Incoming.ToString("yyyy-MM-dd HH:mm:ss") + "', '" 
                            + nJ.Delivery.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + nJ.InputAmount+ "', '" + nJ.ProDone + "', '" + nJ.OutputAmount+ "', '" + nJ.Price+ "', '" 
                            + nJ.Taka+ "', '" + nJ.ActualTime+ "', '" + nJ.TargetTime+ "', '" + Math.Round(nJ.ProTime, 2)+ "', '" + nJ.QcTime+ "', '" 
                            + nJ.ActualEfficiency+ "', '" + nJ.TargetEfficiency+ "', '" + nJ.Receiver+ "', '" + nJ.Sender+ "', '" + nJ.SiName+ "', '" 
                            + nJ.QcName+ "', '" + nJ.Team + "', '" + nJ.ProEnd.ToString("yyyy-MM-dd HH:mm:ss") + "', '0')";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                nJ.Up = 1;

                if (count++ > 9)
                {
                    _db.SaveChanges();
                    break;
                }
            }

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
                    query = @"Update `users` Set name = '" + user.Full_Name + "', short_name = '" + user.Short_Name + "', designation = '" + user.Designation + "', team = '" + user.Team + "' Where `sl` = '" + user.ID + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query = @"INSERT INTO `users`(`sl`, `loc`, `name`, `short_name`, `email`, `designation`, `employee_id`, `team`) 
                        Values('" + user.ID + "', 'DHK', '" + user.Full_Name + "', '" + user.Short_Name + "', '" + user.Short_Name + "@skillgraphics.biz', '" + user.Designation + "', '" + user.Employee_ID + "',  '" + user.Team + "')";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                user.UP = 1;

                if (count++ >= 9)
                {
                    _db.SaveChanges();
                    break;
                }
            }

            Common.Online.Close();
        }

        public void Upload_Logs()
        {
            //var logs = _db.Logs
            //    .Where(x => x.Up == 0 && x.Status == "Done" && x.ProTime != 0 && x.Efficiency != 0)
            //    .OrderByDescending(x => x.Id)
            //    .Take(3)
            //    .ToList();

            //using (var connection = Common.Active_ON())
            //{
            //    var insertQuery = new StringBuilder("INSERT INTO `logs` (`SL`, `Loc`, `Date`, `IsOT`) VALUES ");
            //    var updateQuery = new StringBuilder(" ON DUPLICATE KEY UPDATE `Date`=VALUES(`Date`), `IsOT`=VALUES(`IsOT`);");

            //    using (var command = new MySqlCommand())
            //    {
            //        command.Connection = connection;

            //        for (int i = 0; i < logs.Count; i++)
            //        {
            //            var log = logs[i];
            //            insertQuery.Append($"(@Id{i}, 'DHK', @Date{i}, @IsOT{i}),");
            //            command.Parameters.AddWithValue($"@Id{i}", log.Id);
            //            command.Parameters.AddWithValue($"@Date{i}", log.Date.ToString("yyyy-MM-dd"));
            //            command.Parameters.AddWithValue($"@IsOT{i}", log.IsOT);
            //        }


            //        insertQuery.Length--;
            //        command.CommandText = insertQuery.ToString() + updateQuery.ToString();
            //        command.ExecuteNonQuery();
            //    }
            //    connection.Close();
            //}





            //int count = 0;

            //var logs = _db.Logs
            //    .Where(x => x.Up == 0 && x.Status == "Done" && x.ProTime != 0 && x.Efficiency != 0)
            //    .OrderByDescending(x => x.Id)
            //    .ToList();

            //using (var connection = Common.Active_ON())
            //{
            //    using (var command = new MySqlCommand("", connection))
            //    {
            //        foreach (var log in logs)
            //        {
            //            var image = log.Image.Contains("'") ? log.Image.Replace("'", "''") : log.Image;
            //            var existsQuery = "SELECT EXISTS (SELECT 1 FROM `logs` WHERE `SL` = @Id AND `Loc` = 'DHK')";

            //            command.CommandText = existsQuery;
            //            command.Parameters.Clear();
            //            command.Parameters.AddWithValue("@Id", log.Id);

            //            var result = command.ExecuteScalar();
            //            var exists = (result != null && result != DBNull.Value) && Convert.ToInt32(result) > 0;


            //            if (exists)
            //            {
            //                var updateQuery = @"UPDATE `logs` SET 
            //                    Date = @Date, Shift = @Shift, EndTime = @EndTime, Name = @Name, JobId = @JobId, Service = @Service, 
            //                    Status = @Status, Type = @Type, ActualTime = @ActualTime, TargetTime = @TargetTime, ProTime = @ProTime, 
            //                    Rest_Time = @Rest_Time, Pause_Time = @Pause_Time, Image = @Image, Remarks = @Remarks, 
            //                    Efficiency = @Efficiency, Quality = @Quality,
            //                    Revenue = @Revenue, Support = @Support, IsOT = @IsOT WHERE `SL` = @Id AND `Loc` = 'DHK'";
            //                command.CommandText = updateQuery;
            //                command.Parameters.AddWithValue("@Date", log.Date.ToString("yyyy-MM-dd"));
            //                command.Parameters.AddWithValue("@Shift", log.Shift);
            //                command.Parameters.AddWithValue("@EndTime", log.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            //                command.Parameters.AddWithValue("@Name", log.Name);
            //                command.Parameters.AddWithValue("@JobId", log.JobId);
            //                command.Parameters.AddWithValue("@Service", log.Service);
            //                command.Parameters.AddWithValue("@Status", log.Status);
            //                command.Parameters.AddWithValue("@Type", log.Type);
            //                command.Parameters.AddWithValue("@ActualTime", log.ActualTime);
            //                command.Parameters.AddWithValue("@TargetTime", log.TargetTime);
            //                command.Parameters.AddWithValue("@ProTime", log.ProTime);
            //                command.Parameters.AddWithValue("@Rest_Time", log.RestTime);
            //                command.Parameters.AddWithValue("@Pause_Time", log.PauseTime);
            //                command.Parameters.AddWithValue("@Image", log.Image);
            //                command.Parameters.AddWithValue("@Remarks", log.Remarks);
            //                command.Parameters.AddWithValue("@Efficiency", log.Efficiency);
            //                command.Parameters.AddWithValue("@Quality", log.Quality);
            //                command.Parameters.AddWithValue("@Revenue", log.Revenue);
            //                command.Parameters.AddWithValue("@Support", log.Support);
            //                command.Parameters.AddWithValue("@IsOT", log.IsOT);
            //                command.ExecuteNonQuery();
            //            }
            //            else
            //            {
            //                var insertQuery = @"INSERT INTO `logs`(`SL`, `Loc`, `Date`, `Shift`, `Revenue`, `Support`, `StartTime`, 
            //                    `EndTime`, `Name`, `JobId`, `Service`, `Type`, `Status`, `ActualTime`, `TargetTime`, `ProTime`, 
            //                    `Rest_Time`, `Pause_Time`, `Image`,`Remarks`,`Efficiency`,`Quality`,`IsOT`) 
            //                    VALUES (@Idd, 'DHK', @Date, @Shift, @Revenue, @Support, @StartTime, @EndTime, @Name, @JobId, @Service, @Type, @Status, 
            //                    @ActualTime, @TargetTime, @ProTime, @RestTime, @PauseTime, @Image, @Remarks, @Efficiency, @Quality, @IsOT)";
            //                command.CommandText = insertQuery;
            //                command.Parameters.AddWithValue("@Idd", log.Id);
            //                command.Parameters.AddWithValue("@Date", log.Date.ToString("yyyy-MM-dd"));
            //                command.Parameters.AddWithValue("@Shift", log.Shift);
            //                command.Parameters.AddWithValue("@Revenue", log.Revenue);
            //                command.Parameters.AddWithValue("@Support", log.Support);
            //                command.Parameters.AddWithValue("@StartTime", log.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            //                command.Parameters.AddWithValue("@EndTime", log.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            //                command.Parameters.AddWithValue("@Name", log.Name);
            //                command.Parameters.AddWithValue("@JobId", log.JobId);
            //                command.Parameters.AddWithValue("@Service", log.Service);
            //                command.Parameters.AddWithValue("@Type", log.Type);
            //                command.Parameters.AddWithValue("@Status", log.Status);
            //                command.Parameters.AddWithValue("@ActualTime", log.ActualTime);
            //                command.Parameters.AddWithValue("@TargetTime", log.TargetTime);
            //                command.Parameters.AddWithValue("@ProTime", log.ProTime);
            //                command.Parameters.AddWithValue("@RestTime", log.RestTime);
            //                command.Parameters.AddWithValue("@PauseTime", log.PauseTime);
            //                command.Parameters.AddWithValue("@Image", log.Image);
            //                command.Parameters.AddWithValue("@Remarks", log.Remarks);
            //                command.Parameters.AddWithValue("@Efficiency", log.Efficiency);
            //                command.Parameters.AddWithValue("@Quality", log.Quality);
            //                command.Parameters.AddWithValue("@IsOT", log.IsOT);
            //                command.ExecuteNonQuery();
            //            }

            //            log.Up = 1;

            //            if (count++ > 9)
            //                _db.SaveChanges();

            //            if (count++ > 44)
            //            {
            //                _db.SaveChanges();
            //                break;
            //            }
            //        }
            //    }
            //}

            //Common.Online.Close();

            int count = 0;
            var logs = _db.Logs
                .Where(x => x.Up == 0 & x.Status == "Done" & x.ProTime != 0 & x.Efficiency != 0)
                .OrderByDescending(x => x.Id)
                .ToList();

            foreach (var log in logs)
            {
                var image = log.Image;
                if (image.Contains("\'"))
                    image = image.Replace("\'", "");

                var query = @" Select * From `logs` Where `SL` = '" + log.Id + "' and `Loc` = 'DHK' ";

                if (_common.IsExist(query))
                {
                    query = @" Update `logs` Set Date = '" + log.Date.ToString("yyyy-MM-dd") + "', Shift = '" + log.Shift + "', EndTime = '"
                        + log.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "', Name = '" + log.Name + "', JobId = '" + log.JobId + "', Service = '"
                        + log.Service + "', Status = '" + log.Status + "', Type = '" + log.Type + "', ActualTime = '" + log.ActualTime + "', TargetTime = '"
                        + log.TargetTime + "', ProTime = '" + log.ProTime + "', Rest_Time = '" + log.RestTime + "', Pause_Time = '" + log.PauseTime + "', Image = '"
                        + log.Image + "', Remarks = '" + log.Remarks + "', Efficiency = '" + log.Efficiency + "', Quality = '" + log.Quality + "', Revenue = '"
                        + log.Revenue + "', Support = '" + log.Support + "', IsOT = '" + log.IsOT + "' Where `SL` = '" + log.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    query =
                        @" INSERT INTO `logs`(`SL`, `Loc`, `Date`, `Shift`, `Revenue`, `Support`, `StartTime`, `EndTime`, `Name`, `JobId`, `Service`, `Type`, `Status`, 
                            `ActualTime`, `TargetTime`, `ProTime`, `Rest_Time`, `Pause_Time`, `Image`,`Remarks`,`Efficiency`,`Quality`,`IsOT`) 
                        Values('" + log.Id + "', 'DHK', '" + log.Date.ToString("yyyy-MM-dd") + "', '" + log.Shift + "', '" + log.Revenue + "', '" + log.Support + "','"
                        + log.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + log.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + log.Name + "', '" + log.JobId + "', '"
                        + log.Service + "', '" + log.Type + "', '" + log.Status + "', '" + log.ActualTime + "', '" + log.TargetTime + "', '" + log.ProTime + "', '"
                        + log.RestTime + "', '" + log.PauseTime + "', '" + image + "', '" + log.Remarks + "', '" + log.Efficiency + "', '" + log.Quality + "', '" + log.IsOT + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                log.Up = 1;

                if (count++ > 9)
                    _db.SaveChanges();

                if (count++ > 44)
                {
                    _db.SaveChanges();
                    break;
                }
            }

            Common.Online.Close();
        }

        public void Upload_Performances()
        {
            int count = 0;
            var performances = _db.Performances.Where(x => x.Up == 0).OrderByDescending(x => x.Id).ToList();

            foreach (var p in performances)
            {
                var query = @" Select * From `performances` Where `SL` = '" + p.Id + "' and `Loc` = 'DHK' ";
                if (_common.IsExist(query))
                {
                    query = @"Update `performances` Set Shift = '" + p.Shift + "', Logout = '" + p.Logout.ToString("yyyy-MM-dd HH:mm:ss") + "', Status = '"
                            + p.Status + "', WorkingTime = '" + p.WorkingTime + "', File = '" + p.File + "', JobTime = '" + p.JobTime + "', ProTime = '"
                            + Math.Round(p.ProTime, 2) + "', Efficiency = '" + p.Efficiency + "', Quality = '" + p.Quality + "', Support = '"
                            + p.Support + "', Revenue = '" + p.Revenue + "' Where `SL` = '" + p.Id + "' and `Loc` = 'DHK' ";
                }
                else
                {
                    var user = _db.Users.Where(x => x.Short_Name == p.Name).FirstOrDefault();
                    query = @"INSERT INTO `performances`(`SL`, `Loc`, `Date`, `Login`, `Logout`, `Shift`, `Status`, `Name`, `Support`, `WorkingTime`, `File`, `JobTime`, `ProTime`, `Efficiency`, `Quality`, `Revenue`) 
                                Values('" + p.Id + "', 'DHK', '" + p.Date.ToString("yyyy-MM-dd") + "', '" + p.Login.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + p.Logout.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                            p.Shift + "', '" + p.Status + "', '" + p.Name + "', '" + p.Support + "', '" + p.WorkingTime + "', " + " '" + p.File + "', '" + p.JobTime + "', '"
                            + Math.Round(p.ProTime, 2) + "', '" + p.Efficiency + "', '" + p.Quality + "', '" + p.Revenue + "') ";
                }

                var cmd = new MySqlCommand(query, Common.Active_ON());
                cmd.ExecuteNonQuery();

                p.Up = 1;

                if (count++ > 9)
                {
                    _db.SaveChanges();
                    break;
                }
            }

            Common.Online.Close();
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

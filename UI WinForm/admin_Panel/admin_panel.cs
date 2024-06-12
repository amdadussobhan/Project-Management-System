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
using System.Transactions;
using System.Data.Common;
using Microsoft.SqlServer.Management.Smo.Agent;

namespace Skill_PMS.UI_WinForm.admin_Panel
{
    public partial class AdminPanel : Form
    {
        private readonly Common _common = new Common();
        private SkillContext _db = new SkillContext();
        public DateTime _nowTime;

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

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            _nowTime = DateTime.Now;
            var shift = _common.Current_Shift();
            var date = _common.Shift_Date(_nowTime, shift);
            var shiftReport = _db.Shift_Reports.FirstOrDefault(x => x.Date == date & x.Shift == shift & x.Team == "");
        }

        private async void Tmr_Count_Tick(object sender, EventArgs e)
        {
            Tmr_Count.Stop();
            _db = null;
            _db = new SkillContext();
            _nowTime = DateTime.Now;

            var pending = _db.Logs.Where(x => x.Up == 0 && x.Status == "Done" && x.ProTime != 0 && x.Efficiency != 0).ToList().Count;
            Lbl_Title.Text = "Total Data Pending: " + pending;
            Lbl_Title.ForeColor = Color.Red;

            await Task.Run(() => Upload_Users());
            await Task.Run(() => Upload_New_Jobs());
            await Task.Run(() => Upload_Performances());
            await Task.Run(() => Upload_Logs());

            Thread.Sleep(2222);
            var upload = _db.Logs.Where(x => x.Up == 0 && x.Status == "Done" && x.ProTime != 0 && x.Efficiency != 0).ToList().Count;
            Lbl_Title.Text = "Total Data Upload : " + (pending - upload);
            Lbl_Title.ForeColor = Color.DarkGreen;
            
            Tmr_Count.Start();
        }

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
            var logs = _db.Logs.Where(x => x.Up == 0 && x.Status == "Done" && x.ProTime != 0 && x.Efficiency != 0).OrderByDescending(x => x.Id).Take(999).ToList();
            if (logs.Count == 0)
                return;

            var updatedIds = logs.Select(x => x.Id).ToList();
            using (MySqlConnection connection = new MySqlConnection(Common.connectionString))
            {
                connection.Open();
                var insertQuery = new StringBuilder("INSERT INTO `logs` (`SL`,`Loc`,`Date`,`Shift`,`StartTime`,`EndTime`,`Name`,`JobId`,`Service`,`Status`,`Type`,`ActualTime`," +
                    " `TargetTime`,`ProTime`,`Rest_Time`,`Pause_Time`,`Image`,`Remarks`,`Efficiency`,`Quality`,`Revenue`,`Support`,`IsOT`) VALUES ");

                var updateQuery = new StringBuilder(" ON DUPLICATE KEY UPDATE `Date`=VALUES(`Date`),`Shift`=VALUES(`Shift`),`StartTime`=VALUES(`StartTime`),`EndTime`=VALUES(`EndTime`),`Name`=VALUES(`Name`),`JobId`=VALUES(`JobId`)," +
                    " `Service`=VALUES(`Service`), `Status`=VALUES(`Status`),`Type`=VALUES(`Type`),`ActualTime`=VALUES(`ActualTime`),`TargetTime`=VALUES(`TargetTime`),`ProTime`=VALUES(`ProTime`),`Rest_Time`=VALUES(`Rest_Time`)," +
                    " `Pause_Time`=VALUES(`Pause_Time`),`Image`=VALUES(`Image`),`Remarks`=VALUES(`Remarks`),`Efficiency`=VALUES(`Efficiency`),`Quality`=VALUES(`Quality`),`Revenue`=VALUES(`Revenue`),`Support`=VALUES(`Support`),`IsOT`=VALUES(`IsOT`);");

                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;

                    for (int i = 0; i < logs.Count; i++)
                    {
                        var log = logs[i];
                        insertQuery.Append($"(@Id{i}, 'DHK', @Date{i}, @Shift{i}, @StartTime{i}, @EndTime{i}, @Name{i}, @JobId{i}, @Service{i}, @Status{i}, @Type{i}, @ActualTime{i}," +
                            $" @TargetTime{i}, @ProTime{i}, @Rest_Time{i}, @Pause_Time{i}, @Image{i}, @Remarks{i}, @Efficiency{i}, @Quality{i}, @Revenue{i}, @Support{i}, @IsOT{i}),");

                        command.Parameters.AddWithValue($"@Id{i}", log.Id);
                        command.Parameters.AddWithValue($"@Date{i}", log.Date.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue($"@Shift{i}", log.Shift);
                        command.Parameters.AddWithValue($"@StartTime{i}", log.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue($"@EndTime{i}", log.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue($"@Name{i}", log.Name);
                        command.Parameters.AddWithValue($"@JobId{i}", log.JobId);
                        command.Parameters.AddWithValue($"@Service{i}", log.Service);
                        command.Parameters.AddWithValue($"@Status{i}", log.Status);
                        command.Parameters.AddWithValue($"@Type{i}", log.Type);
                        command.Parameters.AddWithValue($"@ActualTime{i}", log.ActualTime);
                        command.Parameters.AddWithValue($"@TargetTime{i}", log.TargetTime);
                        command.Parameters.AddWithValue($"@ProTime{i}", log.ProTime);
                        command.Parameters.AddWithValue($"@Rest_Time{i}", log.RestTime);
                        command.Parameters.AddWithValue($"@Pause_Time{i}", log.PauseTime);
                        command.Parameters.AddWithValue($"@Image{i}", log.Image);
                        command.Parameters.AddWithValue($"@Remarks{i}", log.Remarks);
                        command.Parameters.AddWithValue($"@Efficiency{i}", log.Efficiency);
                        command.Parameters.AddWithValue($"@Quality{i}", log.Quality);
                        command.Parameters.AddWithValue($"@Revenue{i}", log.Revenue);
                        command.Parameters.AddWithValue($"@Support{i}", log.Support);
                        command.Parameters.AddWithValue($"@IsOT{i}", log.IsOT);
                    }

                    insertQuery.Length--;
                    command.CommandText = insertQuery.ToString() + updateQuery.ToString();

                    command.ExecuteNonQuery();

                    var logsToUpdate = _db.Logs.Where(x => updatedIds.Contains(x.Id)).ToList();
                    logsToUpdate.ForEach(x => x.Up = 1);
                    _db.SaveChanges();
                }
                connection.Close();
            }
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

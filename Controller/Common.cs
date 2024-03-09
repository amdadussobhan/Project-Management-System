using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace Skill_PMS.Controller
{
    public class Common
    {
        private readonly SkillContext _db = new SkillContext();

        private readonly DateTime _morningStart = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ")+"07:00:00");
        private readonly DateTime _morningEnd = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ") + "15:01:30");

        private readonly DateTime _eveningStart = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ")+"15:00:00");
        private readonly DateTime _eveningEnd = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ") + "23:01:30");

        private readonly DateTime _nightStart = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ")+"23:00:00");
        private readonly DateTime _nightEnd = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ") + "07:01:30");
        private readonly DateTime _lastNightStart = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("dd-MM-yy ") + "23:00:00");
        public static MySqlConnection Online = new MySqlConnection("SERVER=166.62.10.143; PORT=3306; DATABASE=PMS; UID=skill_pms; PWD=@dm!n$k!11; Connect Timeout = 28800;");

        public static MySqlConnection Active_ON()
        {
            if (Online.State == ConnectionState.Closed)
            {
                try
                {
                    Online.Open();
                }
                catch
                {
                    // ignored
                }
            }
            return Online;
        }

        public static MySqlCommand sda_on(string query)
        {
            var cmd = new MySqlCommand(query, Active_ON());
            return cmd;
        }

        public DataRowCollection sda_dta_on(string query)
        {
            var sda = new MySqlDataAdapter(query, Active_ON());
            var dta = new DataTable();
            sda.Fill(dta);
            Active_ON().Close();
            return dta.Rows;
        }

        public bool IsExist(string query)
        {
            Online.Close();
            bool result = false;

            try
            {
                var data = sda_on(query).ExecuteReader();

                if (data != null)
                    result = data.Read();

                data.Close();
            }
            catch
            {
                Application.Exit();
            }

            return result;
        }

        public static void Run_Query_ON(string query)
        {
            sda_on(query).ExecuteNonQuery();
            Active_ON().Close();
        }

        public static string Read_Data_ON(string query, string column)
        {
            var data = "";
            var user = sda_on(query).ExecuteReader();
            if (user.Read())
                data = user[column].ToString();
            user.Close();
            Active_ON().Close();
            return data;
        }

        public void Dgv_Size(DataGridView dgv, int fontSize)
        {
            dgv.RowTemplate.Height = 30;
            var dgvCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Comic Sans MS", fontSize, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.Purple
            };
            dgv.DefaultCellStyle = dgvCellStyle;
            //Dgv_Cell_Style.BackColor = Color.Beige;
            //Dgv.ColumnHeadersDefaultCellStyle = Dgv_Cell_Style;
        }

        public string Current_Shift()
        {
            var nowTime = DateTime.Now;
            if (nowTime >= _morningStart & nowTime < _eveningStart)
                return "Morning";

            if (nowTime >= _eveningStart & nowTime < _nightStart)
                return "Evening";

            return "Night";
        }

        public DateTime Shift_Time(string shift)
        {
            if (shift == "Current")
                shift = Current_Shift();

            switch (shift)
            {
                case "Morning": 
                    return _morningStart;
                case "Morning_End": 
                    return _morningEnd;
                case "Evening": 
                    return _eveningStart;
                case "Evening_End": 
                    return _eveningEnd;
                case "Night": 
                    return _nightStart;
                case "Night_End": 
                    return _nightEnd;
                default:
                    return _lastNightStart;
            }
        }

        public DateTime Shift_Date(DateTime dateTime, string shift)
        {
            DateTime date = dateTime.Date;
            if (shift == "Night" & dateTime.ToString("tt").ToUpper() == "AM")
                date = dateTime.AddDays(-1).Date;
            return date;
        }

        public void Row_Color_By_Efficiency(DataGridView dgv, string column)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var efficiencyString = Convert.ToString(row.Cells[column].Value);
                if (efficiencyString != "")
                {
                    var efficiencyArray = efficiencyString.Split('%');
                    var efficiency = Convert.ToDouble(efficiencyArray[0]);

                    if (efficiency <= 0)
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    else if (efficiency <= 89)
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    else if (efficiency <= 99)
                        row.DefaultCellStyle.ForeColor = Color.Orange;
                    else
                        row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

        public void Row_Color_By_Delivery(DataGridView dgv, string deliveryString)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DateTime now = DateTime.Now;
                if (row.Cells[deliveryString].Value != null)
                {
                    var cell_value = row.Cells[deliveryString].Value.ToString();
                    if (!string.IsNullOrEmpty(cell_value))
                    {
                        DateTime delivery = Convert.ToDateTime(cell_value);
                        var remainHour = (int)(delivery - now).TotalHours;

                        if (remainHour < 0)
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            //Row.DefaultCellStyle.BackColor = Color.Red;
                        }
                        else if (remainHour <= 0)
                        {
                            row.DefaultCellStyle.ForeColor = Color.Orange;
                            //Row.DefaultCellStyle.BackColor = Color.Orange;
                        }
                        else
                        {
                            row.DefaultCellStyle.ForeColor = Color.Green;
                            //Row.DefaultCellStyle.BackColor = Color.Green;
                        }
                    }
                }
            }
        }

        public int Designer_Capacity(DateTime date, string shift)
        {
            var Designers = Current_Designers().Count() * 420;

            var IN_Members = (from per in _db.Performances
                         join us in _db.Users
                         on per.Name equals us.Short_Name
                         orderby per.Name
                         where (us.Short_Name.Contains("_IN")) & per.Date == date & per.Shift == shift
                         select per).Count() * 210;

            return Designers - IN_Members;
        }

        public int QC_Capacity(DateTime date, string shift)
        {
            var QC_Members = (from per in _db.Performances
                              join us in _db.Users
                              on per.Name equals us.Short_Name
                              orderby per.Name
                              where (us.Role == "SI" | us.Role == "QC") & per.Date == date & per.Shift == shift
                              select per).Count() * 420;

            return QC_Members - 210;
        }

        public List<Performance> Current_Designers()
        {
            var shift = Current_Shift();
            var date = Shift_Date(DateTime.Now, shift);
            var Designers = (from per in _db.Performances
                            join us in _db.Users 
                            on per.Name equals us.Short_Name
                            orderby per.Name
                            where us.Role == "" & per.Date == date & per.Shift == shift
                            select per).ToList();

            return Designers;
        }
        
        public void Check_Shift_Changing()
        {
            var dateTime = DateTime.Now;

            if (dateTime >= Shift_Time("Evening") & dateTime <= Shift_Time("Morning_End"))
                Starting_Shift_Report(dateTime, "Evening");
            else if (dateTime >= Shift_Time("Night") & dateTime <= Shift_Time("Evening_End"))
                Starting_Shift_Report(dateTime, "Night");
            else if (dateTime >= Shift_Time("Morning") & dateTime <= Shift_Time("Night_End"))
                Starting_Shift_Report(dateTime, "Morning");
            else
            {
                var shift = Current_Shift();
                DateTime date = Shift_Date(dateTime, shift);
                var shiftReport = _db.Shift_Reports.FirstOrDefault(x => x.Date == date & x.Shift == shift & x.Team == "");

                if (shiftReport == null)
                    Starting_Shift_Report(dateTime, shift);
                else
                    Update_Shift_Report();
            }
        }

        public void Starting_Shift_Report(DateTime dateTime, string shift)
        {
            DateTime date = Shift_Date(dateTime, shift);
            var shiftReport = _db.Shift_Reports.FirstOrDefault(x => x.Date == date & x.Shift == shift & x.Team == "");

            if (shiftReport == null)
                shiftReport = Add_New_Shift_Report(date, shift);

            if (shiftReport.TotalLoad != 0)
                return;

            shiftReport.TotalLoad = 0.1;
            shiftReport.Up = 0;
            _db.SaveChanges();

            double totalPreLoad = 0, totalPreFile = 0, preFile = 0, preLoad = 0;
            var teams = new List<string>() { "Basic", "Advance", "QC_Team" };
            foreach (string team in teams)
            {
                //2022
                //var runningJob = _db.Running_Jobs.Where(x => x.Team == team & x.IsDone == false & x.Input_File > x.Output_File).ToList();

                //preFile = 0;
                //preLoad = 0;
                //foreach (var job in runningJob)
                //{
                //    var workLoad = _db.Workloads.FirstOrDefault(x => x.Date == date & x.Shift == shift & x.Team == job.Team & x.JobId == job.JobId);

                //    if (workLoad == null)
                //    {
                //        workLoad = new Workload
                //        {
                //            Shift = shift,
                //            Team = job.Team,
                //            Date = date,
                //            JobId = job.JobId,
                //        };
                //        _db.Workloads.Add(workLoad);

                //        if (job.Input_File > job.Output_File)
                //            workLoad.Input_File = job.Input_File - job.Output_File;
                //    }

                //    workLoad.Service = job.Service;
                //    workLoad.TargetTime = job.Target_Time;
                //    workLoad.Total_Load = job.Target_Time * workLoad.Input_File;
                //    preFile += workLoad.Input_File;
                //    preLoad += workLoad.Total_Load;
                //}

                var teamReport = _db.Shift_Reports.FirstOrDefault(x => x.Date == date & x.Shift == shift & x.Team == team);

                if (teamReport == null)
                    teamReport = Add_New_Shift_Report(date, shift);

                teamReport.Team = team;
                teamReport.TotalFile = teamReport.HandFile = teamReport.PreFile = (int)preFile;
                teamReport.TotalLoad = teamReport.HandLoad = teamReport.PreLoad = preLoad;
                teamReport.Up = 0;

                totalPreFile += preFile;
                totalPreLoad += preLoad;
            }

            var newWorkloads = _db.Workloads.Where(x => x.Team == "" & x.IsDone == false & x.Input_File > x.Output_File).ToList();

            foreach (var newWorkload in newWorkloads)
            {
                newWorkload.Date = shiftReport.Date;
                newWorkload.Shift = shiftReport.Shift;
                totalPreFile += newWorkload.Input_File;
                totalPreLoad += newWorkload.Total_Load;
            }

            shiftReport.TotalFile = shiftReport.HandFile = shiftReport.PreFile = (int)totalPreFile;
            shiftReport.TotalLoad = shiftReport.HandLoad = shiftReport.PreLoad = totalPreLoad;
            shiftReport.Up = 0;
            _db.SaveChanges();
        }

        public ShiftReport Add_New_Shift_Report(DateTime date, string shift)
        {
            ShiftReport shiftReport = new ShiftReport
            {
                Date = date,
                Shift = shift,
                Team = "",
            };
            _db.Shift_Reports.Add(shiftReport);
            _db.SaveChanges();

            return shiftReport;
        }

        public void Update_Shift_Report()
        {
            int count = 0, totalCount;
            var currentTime = DateTime.Now;
            string shift = Current_Shift();
            DateTime date = Shift_Date(currentTime, shift);
            var starTime = Shift_Time(shift);

            if (shift == "Night" & currentTime.ToString("tt").ToUpper() == "AM")
                starTime = starTime.AddDays(-1);

            //---Update Team Report
            var teams = new List<string>() { "Basic", "Advance", "QC_Team"};
            foreach (string team in teams)
            {
                var teamReport = _db.Shift_Reports.FirstOrDefault(x => x.Date == date & x.Shift == shift & x.Team == team);

                if (teamReport == null)
                {
                    teamReport = new ShiftReport
                    {
                        Date = date,
                        Shift = shift,
                        Team = team,
                    };
                    _db.Shift_Reports.Add(teamReport);
                }

                //2022
                //teamReport.ProDone = _db.Logs
                //   .Where(x => x.Team == team & x.StartTime >= starTime & x.StartTime <= currentTime & x.Status == "Done")
                //   .Select(x => x.Image)
                //   .Distinct()
                //   .Count();

                //    var quality = _db.Logs
                //        .Where(x => x.Team == team & x.StartTime >= starTime & x.StartTime <= currentTime & x.Status == "Done")
                //        .Average(x => x.Quality);

                //    teamReport.Quality = (int)quality;

                count = _db.Workloads.Where(x => x.Date == date & x.Shift == shift & x.Team == team).Count();
                if (count != 0)
                {
                    teamReport.TotalLoad = _db.Workloads.Where(x => x.Date == date & x.Shift == shift & x.Team == team).Sum(x => x.Total_Load);
                    teamReport.TotalFile = _db.Workloads.Where(x => x.Date == date & x.Shift == shift & x.Team == team).Sum(x => x.Input_File);
                    teamReport.LoadAchieve = _db.Workloads.Where(x => x.Date == date & x.Shift == shift & x.Team == team).Sum(x => x.Load_Achieve);
                    teamReport.ProAchieve = _db.Workloads.Where(x => x.Date == date & x.Shift == shift & x.Team == team).Sum(x => x.Pro_Achieve);
                }

                if (teamReport.TotalFile > teamReport.ProDone)
                    teamReport.HandFile = teamReport.TotalFile - teamReport.ProDone;

                if (teamReport.TotalLoad > teamReport.LoadAchieve)
                    teamReport.HandLoad = teamReport.TotalLoad - teamReport.LoadAchieve;

                if (teamReport.TotalLoad != 0)
                    teamReport.TargetAchieve = (int)(teamReport.LoadAchieve / teamReport.TotalLoad * 100);

                if (teamReport.ProAchieve != 0)
                    teamReport.Efficiency = (int)(teamReport.LoadAchieve / teamReport.ProAchieve * 100);

                teamReport.Up = 0;
            }
            //---End Update Team Report

            //---Update Shift Report
            var shiftReport = _db.Shift_Reports.FirstOrDefault(x => x.Date == date & x.Shift == shift & x.Team == "");

            if (shiftReport == null)
            {
                shiftReport = new ShiftReport
                {
                    Date = date,
                    Shift = shift,
                    Team = "",
                };
                _db.Shift_Reports.Add(shiftReport);
            }

            count = _db.Logs
                   .Where(x => x.StartTime >= starTime & x.StartTime <= currentTime & x.Status == "Done")
                   .Select(x => x.Image)
                   .Distinct()
                   .Count();

            totalCount = count;

            if (count != 0)
            {
                var quality_count = _db.Logs
                    .Where(x => x.StartTime >= starTime & x.StartTime <= currentTime & x.Status == "Done" & !x.Service.Contains("QC"))
                    .Count();

                if (quality_count != 0)
                {
                    var quality = _db.Logs
                    .Where(x => x.StartTime >= starTime & x.StartTime <= currentTime & x.Status == "Done" & !x.Service.Contains("QC"))
                    .Average(x => x.Quality);

                    shiftReport.Quality = (int)quality;
                }

                shiftReport.ProDone = _db.Logs
                   .Where(x => x.StartTime >= starTime & x.StartTime <= currentTime & x.Status == "Done" & !x.Service.Contains("QC"))
                   .Select(x => x.Image)
                   .Distinct()
                   .Count();

                shiftReport.QcDone = _db.Logs
                    .Where(x => x.StartTime >= starTime & x.StartTime <= currentTime & x.Status == "Done" & x.Service.Contains("QC"))
                    .Select(x => x.Image)
                    .Distinct()
                    .Count();
            }

            count = _db.New_Jobs.Where(x => x.ProEnd >= starTime & x.ProEnd <= currentTime & x.Status == "Ready").Count();

            if (count != 0)
                shiftReport.OutputFile = _db.New_Jobs.Where(x => x.ProEnd >= starTime & x.ProEnd <= currentTime & x.Status == "Ready").Sum(x => x.OutputAmount);

            count = _db.Workloads.Where(x => x.Date == date & x.Shift == shift).Count();
            if (count != 0)
            {
                shiftReport.TotalLoad = _db.Workloads.Where(x => x.Date == date & x.Shift == shift).Sum(x => x.Total_Load);
                shiftReport.TotalFile = _db.Workloads.Where(x => x.Date == date & x.Shift == shift).Sum(x => x.Input_File);
                shiftReport.LoadAchieve = _db.Workloads.Where(x => x.Date == date & x.Shift == shift).Sum(x => x.Load_Achieve);
                shiftReport.ProAchieve = _db.Workloads.Where(x => x.Date == date & x.Shift == shift).Sum(x => x.Pro_Achieve);
            }

            count = _db.New_Jobs.Where(x => x.Incoming >= starTime & x.Incoming <= currentTime).Count();
            if (count != 0)
                shiftReport.NewFile = _db.New_Jobs.Where(x => x.Incoming >= starTime & x.Incoming <= currentTime).Sum(x => x.InputAmount);

            if (shiftReport.TotalFile > totalCount)
                shiftReport.HandFile = shiftReport.TotalFile - totalCount;

            if (shiftReport.TotalLoad > shiftReport.LoadAchieve)
                shiftReport.HandLoad = shiftReport.TotalLoad - shiftReport.LoadAchieve;

            if (shiftReport.TotalLoad != 0)
                shiftReport.TargetAchieve = (int)(shiftReport.LoadAchieve / shiftReport.TotalLoad * 100);

            if (shiftReport.ProAchieve != 0)
                shiftReport.Efficiency = (int)(shiftReport.LoadAchieve / shiftReport.ProAchieve * 100);

            shiftReport.QC_Capacity = QC_Capacity(date, shift);
            shiftReport.Capacity = Designer_Capacity(date, shift) + shiftReport.QC_Capacity;

            //generate last 24 input
            var startday = Shift_Time("Morning");
            if (shift == "Night" & currentTime.ToString("tt").ToUpper() == "AM")
                startday = startday.AddDays(-1);

            count = _db.New_Jobs.Where(x => x.Incoming >= startday & x.Incoming <= currentTime).Count();
            if (count != 0)
                shiftReport.Last24Input = _db.New_Jobs.Where(x => x.Incoming >= startday & x.Incoming <= currentTime).Sum(x => x.InputAmount);

            count = _db.New_Jobs.Where(x => x.ProEnd >= startday & x.ProEnd <= currentTime & x.Status == "Ready").Count();
            if (count != 0)
                shiftReport.Last24Output = _db.New_Jobs.Where(x => x.ProEnd >= startday & x.ProEnd <= currentTime & x.Status == "Ready").Sum(x => x.OutputAmount);

            shiftReport.Up = 0;
            _db.SaveChanges();
        }

        public void UpdateJob(User user, NewJob newJob)
        {
            var shift = Current_Shift();
            var date = Shift_Date(DateTime.Now, shift);

            //---Update Job report in job table
            var fileCount = _db.Logs
                    .Where(x => x.JobId == newJob.JobId & x.Status == "Done")
                    .Select(x => x.Image)
                    .Distinct()
                    .Count();

            if (fileCount != 0)
            {
                var proTime = _db.Logs
                    .Where(x => x.JobId == newJob.JobId & x.Status == "Done")
                    .Sum(x => x.ProTime);

                newJob.ProTime = Math.Round(proTime / fileCount, 2);
                if (newJob.ProTime != 0)
                    newJob.ActualEfficiency = (int)(newJob.TargetTime / newJob.ProTime * 100);

                newJob.ProDone = fileCount;
                if (user.Role != "")
                {
                    newJob.Updated = DateTime.Now;
                    newJob.Updator = user.Short_Name;
                }
                newJob.Up = 0;
            }
            //---End Update Job report in job table

            //---Update Running Job table.

            //2022
            //fileCount = _db.Logs
            //        .Where(x => x.JobId == runningJob.JobId & x.Team == runningJob.Team & x.Status == "Done")
            //        .Select(x => x.Image)
            //        .Distinct()
            //        .Count();
            //
            //double targetTime = runningJob.Target_Time;
            //if (fileCount != 0)
            //{
            //    targetTime = _db.Logs.Where(x => x.JobId == runningJob.JobId & x.Team == runningJob.Team).Average(x => x.TargetTime);
            //    var proTime = _db.Logs.Where(x => x.JobId == runningJob.JobId & x.Team == runningJob.Team & x.Status == "Done").Sum(x => x.ProTime);
            //    runningJob.Pro_Time = Math.Round(proTime / fileCount, 2);
            //    runningJob.Output_File = fileCount;
            //    if (user.Role != "")
            //    {
            //        runningJob.Updated = DateTime.Now;
            //        runningJob.Updator = user.Short_Name;
            //    }
            //    runningJob.Up = 0;
            //}
            //---End Update Running Job table.

            //QC time and QC file amount update in Job Table
            fileCount = _db.Logs
                .Where(x => x.JobId == newJob.JobId & x.Status == "Done" & x.Service.Contains("QC"))
                .Select(x => x.Image)
                .Distinct()
                .Count();

            if (fileCount != 0)
            {
                var qcTime = _db.Logs
                    .Where(x => x.JobId == newJob.JobId & x.Status == "Done" & x.Service.Contains("QC"))
                    .Sum(x => x.ProTime);

                newJob.QcTime = qcTime / fileCount;
                newJob.Up = 0;
            }
            //--- End QC Time and QC file amount update in job Table
            
            //--- Update Workload table.
            var currentTime = DateTime.Now;
            var starTime = Shift_Time(shift);

            if (shift == "Night" & currentTime.ToString("tt").ToUpper() == "AM")
                starTime = starTime.AddDays(-1);

            //2022
            //fileCount = _db.Logs
            //    .Where(x => x.StartTime >= starTime & x.StartTime <= currentTime & x.JobId == runningJob.JobId & x.Team == runningJob.Team & x.Status == "Done")
            //    .Select(x => x.Image)
            //    .Distinct()
            //    .Count();

            //var workload = _db.Workloads.FirstOrDefault(x => x.Date == date & x.Shift == shift & x.JobId == runningJob.JobId & x.Team == runningJob.Team);
            //if (workload != null)
            //{
            //    workload.TargetTime = targetTime;
            //    workload.Output_File = fileCount;
            //    workload.ProTime = runningJob.Pro_Time;
            //    workload.Load_Achieve = fileCount * workload.TargetTime;
            //    workload.Pro_Achieve = fileCount * workload.ProTime;
            //    workload.Up = 0;
            //}

            _db.SaveChanges();
            //---End Update Workload table.
        }

        public void Logout(Performance Performance)
        {
            var performance = _db.Performances.FirstOrDefault(x => x.Id == Performance.Id);
            performance.Logout = DateTime.Now;
            performance.Status = "Logout";
            performance.WorkingTime = (int)(performance.Logout - performance.Login).TotalMinutes;
            performance.Up = 0;

            //var logs = _db.Logs.Where(x=>x.Name == performance.Name & x.Status != "Done");
            //foreach (var log in logs)
            //    _db.Logs.Remove(log);

            _db.SaveChanges();
            Application.Exit();
        }
    }
}
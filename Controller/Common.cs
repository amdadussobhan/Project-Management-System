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

namespace Skill_PMS.Controller
{
    public class Common
    {
        private readonly SkillContext _db = new SkillContext();

        private readonly DateTime _morningStart = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ")+"07:00:00");
        private readonly DateTime _morningEnd = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ") + "15:02:00");

        private readonly DateTime _eveningStart = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ")+"15:00:00");
        private readonly DateTime _eveningEnd = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ") + "23:02:00");

        private readonly DateTime _nightStart = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ")+"23:00:00");
        private readonly DateTime _nightEnd = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yy ") + "07:02:00");
        private readonly DateTime _lastNightStart = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("dd-MM-yy ") + "23:00:00");
        public static MySqlConnection Online = new MySqlConnection("SERVER=166.62.10.143; PORT=3306; DATABASE=PMS; UID=skill_pms; PWD=@dm!n$k!11;");

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
            bool result = false;
            var data = sda_on(query).ExecuteReader();
            if(data != null)
                result = data.Read();
            data.Close();
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
            if (shift == "Night")
            {
                if (dateTime.ToString("tt").ToUpper() == "AM")
                    date = dateTime.AddDays(-1).Date;
            }
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
                    {
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        //Row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (efficiency <= 89)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        //Row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (efficiency <= 99)
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

        public void Row_Color_By_Delivery(DataGridView dgv, string deliveryString)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DateTime now = DateTime.Now, delivery = Convert.ToDateTime(row.Cells[deliveryString].Value);

                if (Convert.ToString(delivery) != "" & Convert.ToString(delivery) != " " & Convert.ToString(delivery) != null)
                {
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

        public List<Performance> Current_Designers()
        {
            var shift = Current_Shift();
            var date = Shift_Date(DateTime.Now, shift);
            var Designers = (from per in _db.Performances
                join us in _db.Users on per.Name equals us.Short_Name
                orderby per.Name
                where us.Role == "" & per.Date == date & per.Shift == shift
                select per).ToList();

            return Designers;
        }

        public void Change_Shift()
        {
            var dateTime = DateTime.Now;
            if (dateTime >= Shift_Time("Evening") & dateTime <= Shift_Time("Morning_End"))
                Starting_Shift_Report(dateTime, "Evening");
            else if (dateTime >= Shift_Time("Night") & dateTime <= Shift_Time("Evening_End"))
                Starting_Shift_Report(dateTime, "Night");
            else if (dateTime >= Shift_Time("Morning") & dateTime <= Shift_Time("Night_End"))
                Starting_Shift_Report(dateTime, "Morning");             
        }

        public void Starting_Shift_Report(DateTime dateTime, string shift)
        {
            DateTime date = Shift_Date(dateTime, shift);
            var shiftReport = _db.Shift_Reports
                .FirstOrDefault(x => x.Date == date & x.Shift == shift);

            if (shiftReport == null)
            {
                shiftReport = Add_New_Shift_Report(date, shift); 
                shiftReport = _db.Shift_Reports
                 .FirstOrDefault(x => x.Date == date & x.Shift == shift);
            }

            if (shiftReport.TotalLoad != 0)
                return;

            shiftReport.TotalLoad = 1;
            shiftReport.Up = 0;
            _db.SaveChanges();

            var runningJob = _db.New_Jobs
               .Where(x => (x.Status == "Pro" | x.Status == "New") & x.InputAmount > x.ProDone).ToList();

            var handFile = 0;
            double handLoad = 0;
            foreach (var job in runningJob)
            {
                var workLoad = _db.Workloads
                    .FirstOrDefault(x => x.Date == date & x.Shift == shift & x.JobId == job.JobId);

                if (workLoad == null)
                {
                    workLoad = new Workload
                    {
                        Shift = shift,
                        Date = date,
                        JobId = job.JobId,
                        File = job.InputAmount - job.ProDone
                    };
                    _db.Workloads.Add(workLoad);
                }

                workLoad.Time = job.ActualTime * workLoad.File;
                handFile += workLoad.File;
                handLoad += workLoad.Time;
            }

            shiftReport.TotalFile = shiftReport.HandFile = handFile;
            shiftReport.TotalLoad = shiftReport.HandLoad = handLoad;

            var lastShift = "Night";
            if (shift == "Evening")
                lastShift = "Morning";
            else if (shift == "Night")
                lastShift = "Evening";

            var lastShiftReport = _db.Shift_Reports
                .OrderByDescending(x => x.Id)
                .FirstOrDefault(x => x.Shift == lastShift & x.Id != shiftReport.Id);

            shiftReport.PreFile = lastShiftReport.TotalFile - lastShiftReport.ProDone;
            shiftReport.PreLoad = lastShiftReport.TotalLoad - lastShiftReport.AchieveLoad;
            shiftReport.Up = 0;
            _db.SaveChanges();
        }

        public ShiftReport Add_New_Shift_Report(DateTime date, string shift)
        {
            ShiftReport shiftReport = new ShiftReport
            {
                Date = date,
                Shift = shift
            };
            _db.Shift_Reports.Add(shiftReport);

            shiftReport.Capacity = Current_Designers().Count * 420;
            _db.SaveChanges();

            if (shiftReport.TotalLoad == 0)
                Check_Workload(shift);

            return shiftReport;
        }

        public void Check_Workload(string shift)
        {
            var shiftTime = Shift_Time(shift);
            if (shift == "Night" & DateTime.Now.ToString("tt").ToUpper() == "AM")
                shiftTime = shiftTime.AddDays(-1);

            if (DateTime.Now > shiftTime)
                Starting_Shift_Report(DateTime.Now, shift);
        }

        public void Logout(Performance performance)
        {
            performance = _db.Performances.Where(x => x.Id == performance.Id).FirstOrDefault();
            performance.Logout = DateTime.Now;
            performance.Status = "Logout";
            performance.WorkingTime = (int)(performance.Logout - performance.Login).TotalMinutes;
            performance.Up = 0;
            _db.SaveChanges();
            Application.Exit();
        }
    }
}

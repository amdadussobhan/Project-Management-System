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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Common_Panel
{
    public partial class Designer_Report : Form
    {
        SkillContext DB = new SkillContext();
        Common common = new Common();
        DateTime today = DateTime.Now.Date;

        string Shift;

        public Designer_Report()
        {
            InitializeComponent();
        }

        private static Designer_Report instance;
        public static Designer_Report getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Designer_Report();
            else
                instance.BringToFront();
            return instance;
        }

        private void Btn_Capacity_Click(object sender, EventArgs e)
        {
            Performance_UI performance_ui = Performance_UI.getInstance();
            performance_ui.Show();
        }

        private void Designer_Report_Load(object sender, EventArgs e)
        {
            Shift = Cmb_Shift.Text;
            Dgv_Designer_Report.DataSource = null;
            Dgv_Designer_Report.Rows.Clear();
            common.Dgv_Size(Dgv_Designer_Report, 11);

            var Persons = DB.Logs.Select(x => x.Name).Distinct().ToList();
            int Person_Count = Persons.Count();
            int Capacity = Person_Count * 420;
            Btn_Capacity.Text = @"Capacity: " + Capacity;

            Prb_Designer.Value = 0;
            Prb_Designer.Maximum = Person_Count;

            if (Person_Count != 0)
            {
                int SL = 1;
                double? Grand_Total_Amount = 0, Grand_Est_Time = 0, Grand_Pro_Time = 0, Efficiency = 0;
                foreach (string person in Persons)
                {
                    int Count_J = 0;
                    double? Total_Amount = 0, Total_Est_Time = 0, Total_Pro_Time = 0;
                    var Jobs = DB.Logs.Where(x=>x.Name == person).Select(x => x.JobId).Distinct().ToList();
                    if (Jobs.Count() != 0)
                    {
                        foreach (string job in Jobs)
                        {
                            var Services = DB.Logs.Where(x => x.Name == person & x.JobId == job).Select(x => x.Service).Distinct().ToList();
                            if (Services.Count() != 0)
                            {
                                var Job = DB.New_Jobs.First(x => x.JobId == job);
                                foreach (string service in Services)
                                {
                                    var Amount = DB.Logs.Where(x=>x.Name == person & x.JobId == job & x.Service == service & x.Status == "Done").Count();
                                    var Est_Time = DB.Logs.Where(x=>x.Name == person & x.JobId == job & x.Service == service & x.Status == "Done").Sum(x=> (double?) x.TargetTime);
                                    var Pro_Time = DB.Logs.Where(x=>x.Name == person & x.JobId == job & x.Service == service & x.Status == "Done").Sum(x=> (double?) x.ProTime);

                                    if (Pro_Time != 0)
                                        Efficiency = Est_Time / Pro_Time * 100;

                                    Count_J++;

                                    if (Count_J == 1)
                                        Dgv_Designer_Report.Rows.Add(SL++, person, job, Job.Folder, service, Amount, Est_Time, Convert.ToInt32(Pro_Time), Convert.ToInt32(Efficiency) + "%");
                                    else
                                        Dgv_Designer_Report.Rows.Add("", "", job, Job.Folder, service, Amount, Est_Time, Convert.ToInt32(Pro_Time), Convert.ToInt32(Efficiency) + "%");

                                    Total_Amount += Amount;
                                    Total_Est_Time += Est_Time;
                                    Total_Pro_Time += Pro_Time;
                                }
                            }
                        }

                        
                    }
                    Prb_Designer.Increment(1); 
                    
                    if (Total_Pro_Time != 0)
                        Efficiency = Total_Est_Time / Total_Pro_Time * 100;
                    if (Count_J >= 2)
                        Dgv_Designer_Report.Rows.Add("", "", "", "", "Total", Total_Amount, Total_Est_Time, Convert.ToInt32(Total_Pro_Time), Convert.ToInt32(Efficiency) + "%");

                    Grand_Total_Amount += Total_Amount;
                    Grand_Est_Time += Total_Est_Time;
                    Grand_Pro_Time += Total_Pro_Time;
                }

                if (Grand_Pro_Time != 0)
                    Efficiency = Grand_Est_Time / Grand_Pro_Time * 100;

                Dgv_Designer_Report.Rows.Add("", "","","", "Grand Total", Grand_Total_Amount, Grand_Est_Time, Convert.ToInt32(Grand_Pro_Time), Convert.ToInt32(Efficiency) + "%");

                Btn_Target_Time.Text = "Est_Time: "+ Grand_Est_Time;
                Btn_Pro_Time.Text = "Pro_Time:" + Grand_Pro_Time;
                Btn_Efficiency.Text = "Efficiency: " + Convert.ToInt32(Efficiency);
            }
            common.Row_Color_By_Efficiency(Dgv_Designer_Report, "Column42");
        }
    }
}

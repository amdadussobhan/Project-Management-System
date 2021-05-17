using Skill_PMS.Controller;
using Skill_PMS.Data;
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
    public partial class Workload_Report : Form
    {
        SkillContext DB = new SkillContext();
        Common common = new Common();

        public Workload_Report()
        {
            InitializeComponent();
        }

        private static Workload_Report instance;
        public static Workload_Report getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Workload_Report();
            else
                instance.BringToFront();
            return instance;
        }

        private void Workload_Load(object sender, EventArgs e)
        {
            Dgv_Workload.DataSource = null;
            Dgv_Workload.Rows.Clear();
            common.Dgv_Size(Dgv_Workload, 11);

            var Jobs = DB.New_Jobs
                .Where(x => x.Status != "Done")
                .ToList();

            int SL = 1;
            foreach (var Job in Jobs)
            {
                Dgv_Workload.Rows.Add(SL++, Job.JobId, Job.Folder, Job.Service, Job.InputAmount, Job.ProDone, Job.ActualTime, Math.Round(Job.ProTime, 2), Job.Incoming, Job.Delivery, Job.ActualEfficiency);
            }

            common.Row_Color_By_Delivery(Dgv_Workload, "Column4");
        }
    }
}

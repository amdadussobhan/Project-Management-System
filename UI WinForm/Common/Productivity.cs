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

namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    public partial class Productivity : Form
    {
        SkillContext DB = new SkillContext();
        public Job job = new Job();
        public Log log = new Log();

        Common common = new Common();
        static public User user { get; set; }

        public Productivity()
        {
            InitializeComponent();
        }

        private static Productivity instance;
        public static Productivity getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Productivity();
            else
                instance.BringToFront();
            return instance;
        }

        private void View_Productivity_Load(object sender, EventArgs e)
        {
            this.Text = "Productivity - " + user.Full_Name;
            job = DB.Jobs
                .Where(x => x.JobID == job.JobID)
                .FirstOrDefault<Job>();

            Dgv_Productivity.DataSource = null;
            Dgv_Productivity.Rows.Clear();
            common.Dgv_Size(Dgv_Productivity, 11);

            var logs = DB.Logs
                .Where(x => x.Job_ID == job.ID)
                .ToList();

            int SL = 1;
            foreach (var log in logs)
            {
                Dgv_Productivity.Rows.Add(SL++, log.Image, log.Service, log.Job_Time, log.Pro_Time, Convert.ToInt32(log.Job_Time / log.Pro_Time * 100), log.Start_Job, log.Finish_Job);
            }
        }
    }
}

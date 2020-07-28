using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    public partial class Job_assign : Form
    {
        SkillContext DB = new SkillContext();
        public Job job = new Job();
        public Target_Pro_Time target_pro_time = new Target_Pro_Time();

        double Job_Time;
        string Job_Service;
        double cp = 0, ret = 0, msk = 0, nj = 0, ai = 0, cc = 0, liq = 0, sha = 0;

        public User User { get; set; }

        public Job_assign()
        {
            InitializeComponent();
        }

        private void Chk_CP_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_CP.Checked == true)
            {
                if(target_pro_time != null)
                    cp = target_pro_time.CP_Time;
                Txt_CP.Enabled = true;
                Txt_CP.Text = cp + "";
            }
            else
            {
                cp = 0;
                Txt_CP.Text = "";
                Txt_CP.Enabled = false;
            }

            Check_Time_Service();
        }

        private void Chk_RET_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_RET.Checked == true)
            {
                if (target_pro_time != null)
                    ret = target_pro_time.RET_Time;
                Txt_RET.Enabled = true;
                Txt_RET.Text = ret + "";
            }
            else
            {
                ret = 0;
                Txt_RET.Text = "";
                Txt_RET.Enabled = false;
            }

            Check_Time_Service();
        }

        private void Chk_NJ_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_NJ.Checked == true)
            {
                if (target_pro_time != null)
                    nj = target_pro_time.NJ_Time;
                Txt_NJ.Enabled = true;
                Txt_NJ.Text = nj + "";
            }
            else
            {
                nj = 0;
                Txt_NJ.Text = "";
                Txt_NJ.Enabled = false;
            }

            Check_Time_Service();
        }

        private void Chk_MSK_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_MSK.Checked == true)
            {
                if (target_pro_time != null)
                    msk = target_pro_time.MSK_Time;
                msk = job.MSK_Time;
                Txt_MSK.Enabled = true;
                Txt_MSK.Text = msk + "";
            }
            else
            {
                msk = 0;
                Txt_MSK.Text = "";
                Txt_MSK.Enabled = false;
            }

            Check_Time_Service();
        }

        private void Chk_SHA_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_SHA.Checked == true)
            {
                if (target_pro_time != null)
                    sha = target_pro_time.SHA_Time;
                sha = job.SHA_Time;
                Txt_SHA.Enabled = true;
                Txt_SHA.Text = sha + "";
            }
            else
            {
                sha = 0;
                Txt_SHA.Text = "";
                Txt_SHA.Enabled = false;
            }

            Check_Time_Service();
        }

        private void Chk_LIQ_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_LIQ.Checked == true)
            {
                if (target_pro_time != null)
                    liq = target_pro_time.LIQ_Time;
                liq = job.LIQ_Time;
                Txt_LIQ.Enabled = true;
                Txt_LIQ.Text = liq + "";
            }
            else
            {
                liq = 0;
                Txt_LIQ.Text = "";
                Txt_LIQ.Enabled = false;
            }

            Check_Time_Service();
        }

        private void Chk_CC_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_CC.Checked == true)
            {
                if (target_pro_time != null)
                    cc = target_pro_time.CC_Time;
                cc = job.CC_Time;
                Txt_CC.Enabled = true;
                Txt_CC.Text = cc + "";
            }
            else
            {
                cc = 0;
                Txt_CC.Text = "";
                Txt_CC.Enabled = false;
            }

            Check_Time_Service();
        }

        private void Chk_AI_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_AI.Checked == true)
            {
                if (target_pro_time != null)
                    ai = target_pro_time.AI_Time;
                ai = job.AI_Time;
                Txt_AI.Enabled = true;
                Txt_AI.Text = ai + "";
            }
            else
            {
                ai = 0;
                Txt_AI.Text = "";
                Txt_AI.Enabled = false;
            }

            Check_Time_Service();
        }

        private void Txt_CP_TextChanged(object sender, EventArgs e)
        {
            string Time = Txt_CP.Text;
            if (!string.IsNullOrEmpty(Time))
                cp = Convert.ToDouble(Time);
            else
                cp = 0;

            Check_Time_Service();
        }

        private void Txt_NJ_TextChanged(object sender, EventArgs e)
        {
            string Time = Txt_NJ.Text;
            if (!string.IsNullOrEmpty(Time))
                nj = Convert.ToDouble(Time);
            else
                nj = 0;

            Check_Time_Service();
        }

        private void Txt_RET_TextChanged(object sender, EventArgs e)
        {
            string Time = Txt_RET.Text;
            if (!string.IsNullOrEmpty(Time))
                ret = Convert.ToDouble(Time);
            else
                ret = 0;

            Check_Time_Service();
        }

        private void Txt_MSK_TextChanged(object sender, EventArgs e)
        {
            string Time = Txt_MSK.Text;
            if (!string.IsNullOrEmpty(Time))
                msk = Convert.ToDouble(Time);
            else
                msk = 0;

            Check_Time_Service();
        }

        private void Txt_SHA_TextChanged(object sender, EventArgs e)
        {
            string Time = Txt_SHA.Text;
            if (!string.IsNullOrEmpty(Time))
                sha = Convert.ToDouble(Time);
            else
                sha = 0;

            Check_Time_Service();
        }

        private void Txt_LIQ_TextChanged(object sender, EventArgs e)
        {
            string Time = Txt_LIQ.Text;
            if (!string.IsNullOrEmpty(Time))
                liq = Convert.ToDouble(Time);
            else
                liq = 0;

            Check_Time_Service();
        }

        private void Txt_CC_TextChanged(object sender, EventArgs e)
        {
            string Time = Txt_CC.Text;
            if (!string.IsNullOrEmpty(Time))
                cc = Convert.ToDouble(Time);
            else
                cc = 0;

            Check_Time_Service();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if(Job_Time != 0 & !string.IsNullOrEmpty(Job_Service))
            {
                if(Chk_Save_Time.Checked == true) { 
                    if(target_pro_time == null) { 
                        target_pro_time.Time = Job_Time;
                        target_pro_time.Client = job.Client;
                        target_pro_time.Category = job.Category;
                    }
                    target_pro_time.CP_Time = cp;
                    target_pro_time.RET_Time = ret;
                    target_pro_time.MSK_Time = msk;
                    target_pro_time.SHA_Time = sha;
                    target_pro_time.NJ_Time = nj;
                    target_pro_time.CC_Time = cc;
                    target_pro_time.LIQ_Time = liq;
                    target_pro_time.AI_Time = ai;
                    DB.Target_Pro_Times.AddOrUpdate(target_pro_time);
                }

                job.CP_Time = cp;
                job.RET_Time = ret;
                job.MSK_Time = msk;
                job.SHA_Time = sha;
                job.NJ_Time = nj;
                job.CC_Time = cc;
                job.LIQ_Time = liq;
                job.AI_Time = ai;

                double taka_per_min = job.Taka / Job_Time;

                job.CP_Price = taka_per_min * cp;
                job.RET_Price = taka_per_min * ret;
                job.MSK_Price = taka_per_min * msk;
                job.SHA_Price = taka_per_min * sha;
                job.NJ_Price = taka_per_min * nj;
                job.CC_Price = taka_per_min * cc;
                job.LIQ_Price = taka_per_min * liq;
                job.AI_Price = taka_per_min * ai;

                job.WorkingLocation = Txt_Location.Text;
                job.Target_Time = Job_Time;
                job.Status = "Pro";
                job.Service = Job_Service;
                job.Shift_Incharge = User;

                if(target_pro_time != null)
                    job.Target_Pro_Times = target_pro_time;

                DB.Jobs.AddOrUpdate(job);
                DB.SaveChanges();
                this.Close();
            }
        }

        private void Txt_AI_TextChanged(object sender, EventArgs e)
        {
            string Time = Txt_AI.Text;
            if (!string.IsNullOrEmpty(Time))
                ai = Convert.ToDouble(Time);
            else
                ai = 0;

            Check_Time_Service();
        }

        private void Job_assign_Load(object sender, EventArgs e)
        {
            job = DB.Jobs
                .Where(x => x.JobID == job.JobID)
                .FirstOrDefault<Job>();

            Lbl_Job_ID.Text = job.JobID;
            Lbl_Incoming.Text = job.Incoming.ToString("ddd  dd-MM-yy  hh:mm tt");
            Lbl_Delivery.Text = job.Delivery.ToString("ddd  dd-MM-yy  hh:mm tt");
            Lbl_Amount.Text = job.InputAmount + "";
            Lbl_Actual_Time.Text = job.Actual_Time + "";
            Lbl_Target_Time.Text = job.Pro_Time + "";
            Lbl_Total_Time.Text = job.Type + "";
            Txt_Folder.Text = job.Folder + "";
            Txt_Location.Text = job.InputLocation + "";
            Cmb_Category.Text = job.Category + "";

            var Categories = DB.Target_Pro_Times.Select(x => x.Category).Distinct();
            foreach (var Category in Categories)
                Cmb_Category.Items.Add(Category);
        }

        private void Cmb_Category_TextChanged(object sender, EventArgs e)
        {
            var Target_Pro_Times = DB.Target_Pro_Times
                .Where(x => x.Client == job.Client & x.Category == Cmb_Category.Text)
                .FirstOrDefault<Target_Pro_Time>();

            Fill_Service_Time(Target_Pro_Times);
        }

        void Check_Time_Service()
        {
            Job_Time = 0;
            Job_Service = "";

            if (Chk_CP.Checked == true)
            {
                Job_Time += cp;
                Job_Service += "CP+";
            }

            if (Chk_RET.Checked == true)
            {
                Job_Time += ret;
                Job_Service += "RET+";
            }

            if (Chk_MSK.Checked == true)
            {
                Job_Time += msk;
                Job_Service += "MSK+";
            }

            if (Chk_SHA.Checked == true)
            {
                Job_Time += sha;
                Job_Service += "SHA+";
            }

            if (Chk_LIQ.Checked == true)
            {
                Job_Time += liq;
                Job_Service += "LIQ+";
            }

            if (Chk_NJ.Checked == true)
            {
                Job_Time += nj;
                Job_Service += "NJ+";
            }

            if (Chk_CC.Checked == true)
            {
                Job_Time += cc;
                Job_Service += "CC+";
            }

            if (Chk_AI.Checked == true)
            {
                Job_Time += ai;
                Job_Service += "AI+";
            }

            Lbl_Target_Time.Text = Job_Time + "";
            Lbl_Total_Time.Text = Job_Time * job.InputAmount + "";
            Job_Service = Job_Service.TrimEnd('+');
            Lbl_Service.Text = Job_Service;
        }

        void Fill_Service_Time(Target_Pro_Time target_pro_time)
        {
            if (target_pro_time != null)
            {
                this.target_pro_time = target_pro_time;

                if (target_pro_time.CP_Time != 0)
                    Chk_CP.Checked = true;
                else
                    Chk_CP.Checked = false;

                if (target_pro_time.RET_Time != 0)
                    Chk_RET.Checked = true;
                else
                    Chk_RET.Checked = false;

                if (target_pro_time.NJ_Time != 0)
                    Chk_NJ.Checked = true;
                else
                    Chk_NJ.Checked = false;

                if (target_pro_time.MSK_Time != 0)
                    Chk_MSK.Checked = true;
                else
                    Chk_MSK.Checked = false;

                if (target_pro_time.SHA_Time != 0)
                    Chk_SHA.Checked = true;
                else
                    Chk_SHA.Checked = false;

                if (target_pro_time.LIQ_Time != 0)
                    Chk_LIQ.Checked = true;
                else
                    Chk_LIQ.Checked = false;

                if (target_pro_time.CC_Time != 0)
                    Chk_CC.Checked = true;
                else
                    Chk_CC.Checked = false;

                if (target_pro_time.AI_Time != 0)
                    Chk_AI.Checked = true;
                else
                    Chk_AI.Checked = false;
            }
        }

        private void Btn_Open_Folder_Click(object sender, EventArgs e)
        {
            string location = Txt_Location.Text;
            if (Directory.Exists(location))
                Process.Start(location);
            else
                MessageBox.Show("Folder doesn't Exist. Please Enter Correct Location...", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        
    }
}

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
        public Price_Time price_time = new Price_Time();

        string Job_Service;
        double Job_Time, cp = 0, ret = 0, msk = 0, nj = 0, ai = 0, cc = 0, liq = 0, sha = 0;

        public User user { get; set; }

        public Job_assign()
        {
            InitializeComponent();
        }

        private static Job_assign instance;
        public static Job_assign getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Job_assign();
            else
                instance.BringToFront();
            return instance;
        }

        private void Chk_CP_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_CP.Checked)
            {
                Txt_CP.Enabled = true;
                if (price_time != null)
                    Txt_CP.Text = price_time.CP_Time + "";
            }
            else
            {
                cp = 0;
                Txt_CP.Text = "";
                Txt_CP.Enabled = false;
            }
        }

        private void Chk_RET_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_RET.Checked)
            {
                Txt_RET.Enabled = true;
                if (price_time != null)
                    Txt_RET.Text = price_time.RET_Time + "";
            }
            else
            {
                ret = 0;
                Txt_RET.Text = "";
                Txt_RET.Enabled = false;
            }
        }

        private void Chk_NJ_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_NJ.Checked)
            {
                Txt_NJ.Enabled = true;
                if (price_time != null)
                    Txt_NJ.Text = price_time.NJ_Time + "";
            }
            else
            {
                nj = 0;
                Txt_NJ.Text = "";
                Txt_NJ.Enabled = false;
            }
        }

        private void Chk_MSK_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_MSK.Checked)
            {
                Txt_MSK.Enabled = true;
                if (price_time != null)
                    Txt_MSK.Text = price_time.MSK_Time + "";
            }
            else
            {
                msk = 0;
                Txt_MSK.Text = "";
                Txt_MSK.Enabled = false;
            }
        }

        private void Chk_SHA_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_SHA.Checked)
            {
                Txt_SHA.Enabled = true;
                if (price_time != null)
                    Txt_SHA.Text = price_time.SHA_Time + "";
            }
            else
            {
                sha = 0;
                Txt_SHA.Text = "";
                Txt_SHA.Enabled = false;
            }
        }

        private void Chk_LIQ_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_LIQ.Checked)
            {
                Txt_LIQ.Enabled = true;
                if (price_time != null)
                    Txt_LIQ.Text = price_time.LIQ_Time + "";
            }
            else
            {
                liq = 0;
                Txt_LIQ.Text = "";
                Txt_LIQ.Enabled = false;
            }
        }

        private void Chk_CC_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_CC.Checked)
            {
                Txt_CC.Enabled = true;
                if (price_time != null)
                    Txt_CC.Text = price_time.CC_Time + "";
            }
            else
            {
                cc = 0;
                Txt_CC.Text = "";
                Txt_CC.Enabled = false;
            }
        }

        private void Chk_AI_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_AI.Checked)
            {
                Txt_AI.Enabled = true;
                if (price_time != null)
                    Txt_AI.Text = price_time.AI_Time + "";
            }
            else
            {
                ai = 0;
                Txt_AI.Text = "";
                Txt_AI.Enabled = false;
            }
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

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Cmb_Category.Text = "";
        }

        bool Job_Validated()
        {
            if (string.IsNullOrEmpty(Job_Service))
            {
                MessageBox.Show("Job Service is empty.!!! Please Select Proper Job Service", "Job Service is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Job_Time == 0)
            {
                MessageBox.Show("Job Time is empty.!!! Please Enter Proper Job Time", "Job Time is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(Txt_Location.Text))
            {
                MessageBox.Show("Invalid Folder Location Entered.!!! Please Enter Correct Folder Location", "Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Chk_Remember.Checked & string.IsNullOrEmpty(Cmb_Category.Text))
            {
                MessageBox.Show("Job Category is empty.!!! Please Enter Correct Job Category", "Job Category is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if(Job_Validated())
            {
                if(Chk_Remember.Checked) { 
                    if(price_time == null) {
                        price_time.Client = job.Client;
                        price_time.Category = job.Category;
                    }
                    price_time.Target_Time = Job_Time;
                    price_time.CP_Time = cp;
                    price_time.RET_Time = ret;
                    price_time.MSK_Time = msk;
                    price_time.SHA_Time = sha;
                    price_time.NJ_Time = nj;
                    price_time.CC_Time = cc;
                    price_time.LIQ_Time = liq;
                    price_time.AI_Time = ai;
                    DB.Price_Times.AddOrUpdate(price_time);
                    DB.SaveChanges();
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
                job.SI_ID = user.ID;

                if (Chk_Remember.Checked)
                {
                    if (price_time != null)
                        job.Price_Times_ID = price_time.ID;
                }

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
            this.Text = "Job assign - " + user.Full_Name;
              
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
            Cmb_Category.Text = job.Category;

            var Categories = DB.Price_Times
                .Where(x => x.Client == job.Client)
                .Select(x => x.Category)
                .Distinct();

            foreach (var Category in Categories)
                Cmb_Category.Items.Add(Category);
        }

        private void Cmb_Category_TextChanged(object sender, EventArgs e)
        {
            var price_time = DB.Price_Times
                .Where(x => x.Client == job.Client & x.Category == Cmb_Category.Text)
                .FirstOrDefault<Price_Time>();

            Fill_Service_Time(price_time);
        }

        void Check_Time_Service()
        {
            Job_Time = 0;
            Job_Service = "";

            if (Chk_CP.Checked)
            {
                Job_Time += cp;
                Job_Service += "CP+";
            }

            if (Chk_RET.Checked)
            {
                Job_Time += ret;
                Job_Service += "RET+";
            }

            if (Chk_MSK.Checked)
            {
                Job_Time += msk;
                Job_Service += "MSK+";
            }

            if (Chk_SHA.Checked)
            {
                Job_Time += sha;
                Job_Service += "SHA+";
            }

            if (Chk_LIQ.Checked)
            {
                Job_Time += liq;
                Job_Service += "LIQ+";
            }

            if (Chk_NJ.Checked)
            {
                Job_Time += nj;
                Job_Service += "NJ+";
            }

            if (Chk_CC.Checked)
            {
                Job_Time += cc;
                Job_Service += "CC+";
            }

            if (Chk_AI.Checked)
            {
                Job_Time += ai;
                Job_Service += "AI+";
            }

            Lbl_Target_Time.Text = Job_Time + "";
            Lbl_Total_Time.Text = Job_Time * job.InputAmount + "";
            Job_Service = Job_Service.TrimEnd('+');
            Lbl_Service.Text = Job_Service;
        }

        void Fill_Service_Time(Price_Time price_times)
        {
            if (price_times != null)
            {
                this.price_time = price_times;

                if (price_times.CP_Time != 0)
                    Chk_CP.Checked = true;
                else
                    Chk_CP.Checked = false;

                if (price_times.RET_Time != 0)
                    Chk_RET.Checked = true;
                else
                    Chk_RET.Checked = false;

                if (price_times.NJ_Time != 0)
                    Chk_NJ.Checked = true;
                else
                    Chk_NJ.Checked = false;

                if (price_times.MSK_Time != 0)
                    Chk_MSK.Checked = true;
                else
                    Chk_MSK.Checked = false;

                if (price_times.SHA_Time != 0)
                    Chk_SHA.Checked = true;
                else
                    Chk_SHA.Checked = false;

                if (price_times.LIQ_Time != 0)
                    Chk_LIQ.Checked = true;
                else
                    Chk_LIQ.Checked = false;

                if (price_times.CC_Time != 0)
                    Chk_CC.Checked = true;
                else
                    Chk_CC.Checked = false;

                if (price_times.AI_Time != 0)
                    Chk_AI.Checked = true;
                else
                    Chk_AI.Checked = false;
            }
            else
            {
                Chk_CP.Checked = false;
                Chk_RET.Checked = false;
                Chk_MSK.Checked = false;
                Chk_SHA.Checked = false;
                Chk_LIQ.Checked = false;
                Chk_CC.Checked = false;
                Chk_NJ.Checked = false;
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

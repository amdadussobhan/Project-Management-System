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
        SkillContext _db = new SkillContext();
        public NewJob _job = new NewJob();
        public Sub_Folder _sub_folder;
        public Price_Time _price_time;

        string _job_Service;
        double _job_Time, cp = 0, ret = 0, msk = 0, nj = 0, ai = 0, cc = 0, liq = 0, sha = 0, qc = 0;

        public User _user { get; set; }

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
                if (_price_time != null)
                    Txt_CP.Text = _price_time.CP_Time + "";
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
                if (_price_time != null)
                    Txt_RET.Text = _price_time.RET_Time + "";
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
                if (_price_time != null)
                    Txt_NJ.Text = _price_time.NJ_Time + "";
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
                if (_price_time != null)
                    Txt_MSK.Text = _price_time.MSK_Time + "";
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
                if (_price_time != null)
                    Txt_SHA.Text = _price_time.SHA_Time + "";
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
                if (_price_time != null)
                    Txt_LIQ.Text = _price_time.LIQ_Time + "";
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
                if (_price_time != null)
                    Txt_CC.Text = _price_time.CC_Time + "";
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
                if (_price_time != null)
                    Txt_AI.Text = _price_time.AI_Time + "";
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

        private void Btn_Subfolder_Click(object sender, EventArgs e)
        {
            string Loc = Txt_Location.Text;
            if (!string.IsNullOrEmpty(Loc) & Directory.Exists(Loc))
            {
                string[] files = Directory.GetFiles(Loc, "*", SearchOption.AllDirectories);
                Loc += @"\Images";
                Directory.CreateDirectory(Loc);
                foreach (string file_path in files)
                {
                    string ext = Path.GetExtension(file_path);
                    string Old_Name = Path.GetFileNameWithoutExtension(file_path);
                    string F_Name = new DirectoryInfo(Path.GetDirectoryName(file_path)).Name;
                    string New_Name = F_Name + "_" + Old_Name;

                a:
                    string Des_File = Path.Combine(Loc, New_Name + ext);
                    if (File.Exists(Des_File))
                    {
                        New_Name += New_Name + "_";
                        goto a;
                    }
                    File.Move(file_path, Des_File);

                    _sub_folder = _db.Sub_Folders
                        .Where(x => x.Job_ID == _job.JobId & x.Path == file_path & x.Old_Name == Old_Name)
                        .FirstOrDefault<Sub_Folder>();

                    if(_sub_folder == null)
                    {
                        _sub_folder = new Sub_Folder();
                        _sub_folder.Job_ID = _job.JobId;
                        _sub_folder.Path = file_path;
                        _sub_folder.Old_Name = Old_Name;
                        _sub_folder.New_Name = New_Name;
                        _db.Sub_Folders.Add(_sub_folder);
                    }
                }
                Txt_Location.Text = Loc;
                Btn_Subfolder.Enabled = false;
                _db.SaveChanges();
                MessageBox.Show(@"Successfully Saved Sub Folder Please check this Folder ", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Folder Location maybe Empty. Please Enter correct folder Location", @"Invalid Folder Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Rdb_PSD_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_PSD.Checked)
                _job.Format = ".psd";
        }

        private void Rdb_JPG_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_JPG.Checked)
                _job.Format = ".jpg";
        }

        private void Rdb_PNG_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_PNG.Checked)
                _job.Format = ".png";
        }

        private void Rdb_TIF_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_TIF.Checked)
                _job.Format = ".tif";
        }

        private void Btn_assign_Click(object sender, EventArgs e)
        {
            if (Job_Validated())
            {
                Assign_Time();
                MessageBox.Show(@"Time assign Successfully", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Assign_Time()
        {
            string Loc = Txt_Location.Text;
            string[] files = Directory.GetFiles(Loc, "*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);

                var imageTime = _db.ImageTime
                    .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == fileName);

                if (imageTime == null)
                {
                    imageTime = new ImageTime
                    {
                        JobId = _job.JobId,
                        Image = fileName
                    };
                    _db.ImageTime.Add(imageTime);
                }

                imageTime.Actual_Time = _job.ActualTime;
                imageTime.Target_Time = _job_Time;
                imageTime.Category = Cmb_Category.Text;

                imageTime.CP_Time = cp;
                imageTime.RET_Time = ret;
                imageTime.MSK_Time = msk;
                imageTime.SHA_Time = sha;
                imageTime.NJ_Time = nj;
                imageTime.CC_Time = cc;
                imageTime.LIQ_Time = liq;
                imageTime.AI_Time = ai;
            }

            _db.SaveChanges();
        }

        bool Job_Validated()
        {
            if (string.IsNullOrEmpty(_job_Service))
            {
                MessageBox.Show(@"Job Service is empty.!!! Please Select Proper Job Service", @"Job Service is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_job_Time == 0)
            {
                MessageBox.Show(@"Job Time is empty.!!! Please Enter Proper Job Time", @"Job Time is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Directory.Exists(Txt_Location.Text))
            {
                MessageBox.Show(@"Invalid Folder Location Entered.!!! Please Enter Correct Folder Location", @"Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(_job.Format))
            {
                MessageBox.Show(@"File format can't be empty.!!! Please Select a file format", @"File format is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(Cmb_Category.Text))
            {
                MessageBox.Show(@"Job Category is empty.!!! Please Enter Correct Job Category", @"Job Category is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if(Job_Validated())
            {
                if (Chk_Remember.Checked) { 
                    if(_price_time.ID == 0) {
                        _price_time.Client = _job.Client;
                        _price_time.Category = Cmb_Category.Text;
                        _db.Price_Times.Add(_price_time);
                    }
                    _price_time.Target_Time = _job_Time;
                    _price_time.Format = _job.Format;
                    _price_time.CP_Time = cp;
                    _price_time.RET_Time = ret;
                    _price_time.MSK_Time = msk;
                    _price_time.SHA_Time = sha;
                    _price_time.NJ_Time = nj;
                    _price_time.CC_Time = cc;
                    _price_time.LIQ_Time = liq;
                    _price_time.AI_Time = ai;
                    _db.SaveChanges();
                }

                Assign_Time();

                string Time = Txt_QC.Text;
                if (!string.IsNullOrEmpty(Time))
                    qc = Convert.ToDouble(Time);
                else
                    qc = _job_Time * 0.1;

                _job.QC_Time = qc;
                double taka_per_min = _job.Taka / _job_Time;

                _job.CP_Price = taka_per_min * cp;
                _job.RET_Price = taka_per_min * ret;
                _job.MSK_Price = taka_per_min * msk;
                _job.SHA_Price = taka_per_min * sha;
                _job.NJ_Price = taka_per_min * nj;
                _job.CC_Price = taka_per_min * cc;
                _job.LIQ_Price = taka_per_min * liq;
                _job.AI_Price = taka_per_min * ai;

                _job.WorkingLocation = Txt_Location.Text;
                _job.TargetTime = _job_Time;
                _job.Status = "Pro";
                _job.Service = _job_Service;
                _job.SiName = _user.Short_Name;

                if (Chk_Remember.Checked)
                {
                    if (_price_time != null)
                        _job.Price_Times_ID = _price_time.ID;
                }

                _db.SaveChanges();
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
            this.Text = "Job assign - " + _user.Full_Name;
            _job = _db.New_Jobs.FirstOrDefault(x => x.JobId == _job.JobId);

            Lbl_Job_ID.Text = _job.JobId;
            Lbl_Incoming.Text = _job.Incoming.ToString("ddd  dd-MM-yy  hh:mm tt");
            Lbl_Delivery.Text = _job.Delivery.ToString("ddd  dd-MM-yy  hh:mm tt");
            Lbl_Amount.Text = _job.InputAmount + "";
            Lbl_Actual_Time.Text = _job.ActualTime + "";
            Lbl_Target_Time.Text = _job.TargetTime + "";
            Lbl_Total_Time.Text = _job.Type + "";
            Txt_Folder.Text = _job.Folder + "";
            Txt_Location.Text = _job.InputLocation + "";
            //Cmb_Category.Text = job.Category;

            string ext = _job.Format;

            if (ext == ".jpg")
                Rdb_JPG.Checked = true;
            else if (ext == ".psd")
                Rdb_PSD.Checked = true;
            else if (ext == ".png")
                Rdb_PNG.Checked = true;
            else if(ext == ".tif")
                Rdb_TIF.Checked = true;
            
            /*
            var Categories = DB.Price_Times
                .Where(x => x.Client == job.Client)
                .Select(x => x.Category)
                .Distinct();

            foreach (var Category in Categories)
                Cmb_Category.Items.Add(Category);
            */
        }

        private void Cmb_Category_TextChanged(object sender, EventArgs e)
        {
            var price_time = _db.Price_Times
                .FirstOrDefault(x => x.Client == _job.Client & x.Category == Cmb_Category.Text);

            Fill_Service_Time(price_time);
        }

        void Check_Time_Service()
        {
            _job_Time = 0;
            _job_Service = "";

            if (Chk_CP.Checked)
            {
                _job_Time += cp;
                _job_Service += "CP+";
            }

            if (Chk_RET.Checked)
            {
                _job_Time += ret;
                _job_Service += "RET+";
            }

            if (Chk_MSK.Checked)
            {
                _job_Time += msk;
                _job_Service += "MSK+";
            }

            if (Chk_SHA.Checked)
            {
                _job_Time += sha;
                _job_Service += "SHA+";
            }

            if (Chk_LIQ.Checked)
            {
                _job_Time += liq;
                _job_Service += "LIQ+";
            }

            if (Chk_NJ.Checked)
            {
                _job_Time += nj;
                _job_Service += "NJ+";
            }

            if (Chk_CC.Checked)
            {
                _job_Time += cc;
                _job_Service += "CC+";
            }

            if (Chk_AI.Checked)
            {
                _job_Time += ai;
                _job_Service += "AI+";
            }

            Lbl_Target_Time.Text = _job_Time + "";
            Lbl_Total_Time.Text = _job_Time * _job.InputAmount + "";
            _job_Service = _job_Service.TrimEnd('+');
            Lbl_Service.Text = _job_Service;
        }

        void Fill_Service_Time(Price_Time price_times)
        {
            if (price_times != null)
            {
                this._price_time = price_times;

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
                MessageBox.Show(@"Folder doesn't Exist. Please Enter Correct Location...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        
    }
}

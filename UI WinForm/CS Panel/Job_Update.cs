using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.CS_Panel
{
    public partial class Job_Update : Form
    {
        public NewJob Job = new NewJob();
        public NewJob Redo = new NewJob();
        private Price_Time _priceTime = new Price_Time();
        private Rate _rate = new Rate();
        private Common _common = new Common();
        private SkillContext _db = new SkillContext();

        private double _priceRate;
        private int _file = 0;
        private string _jobId = "", _client = "";
        public bool _isRedo = false;

        public User User { get; set; }

        public Job_Update()
        {
            InitializeComponent();
        }

        private static Job_Update _instance;
        public static Job_Update GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Job_Update();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Job_Update_Load(object sender, EventArgs e)
        {
            this.Text = @"Job Update- " + User.Full_Name;

            var clients = _db.New_Jobs
                .Select(x => x.Client)
                .Where(x => x.StartsWith("SG"))
                .Distinct();

            foreach (var client in clients)
                Cmb_Client.Items.Add(client);

            var rates = _db.Rates.Select(x => x.Currency).Distinct();
            foreach (var rate in rates)
                Cmb_Currency.Items.Add(rate);

            Job = _db.New_Jobs
                .FirstOrDefault(x => x.JobId == Job.JobId);

            Cmb_Client.Text = Job.Client;
            Cmb_Catagory.Text = Job.Category;
            Txt_Amount.Text = Job.InputAmount + "";
            Dtp_Delivery.Value = Job.Delivery;
            Txt_Location.Text = Job.InputLocation;
            Txt_Job_Time.Text = Job.ActualTime + "";
            Txt_Price.Text = Job.Price + "";
            Cmb_Currency.Text = Job.Currency;

            if (_isRedo)
            {
                Cmb_Job_Type.Text = "Feedback";
                Create_Job_ID();
                Txt_Job_ID.Text = _jobId;
            }
            else
            {
                Txt_Job_ID.Text = Job.JobId;
                Cmb_Job_Type.Text = Job.Type;
            }
        }

        private void Create_Job_ID()
        {
            var today = DateTime.Now.Date;
            var count = _db.New_Jobs
                .Count(x => x.Date == today);

            var date = DateTime.Now.ToString("yyMMdd");
            x:
            var id = date + ++count;
            if (count < 10)
                id = date + "0" + count;

            var exist_job = _db.New_Jobs
                .SqlQuery("Select * From NewJobs where JobID like '" + id + "%' ")
                .Count();

            if (exist_job != 0)
                goto x;

            _jobId = id + "_" + _client;
        }

        private void Btn_Submit_Job_Click(object sender, EventArgs e)
        {
            _db = new SkillContext();

            if (!string.IsNullOrEmpty(Txt_Amount.Text))
                _file = Convert.ToInt32(Txt_Amount.Text);

            if (!Job_Validated()) return;

            var currency = Cmb_Currency.Text;
            if (!string.IsNullOrEmpty(currency))
            {
                currency = currency.ToUpper();
                if (_rate.ID == 0)
                {
                    _rate.Currency = currency;
                    _db.Rates.AddOrUpdate(_rate);
                    _db.SaveChanges();
                }
            }

            double time = 0, price = 0, taka = 0;
            var category = Cmb_Catagory.Text;

            if (!string.IsNullOrEmpty(Txt_Job_Time.Text))
                time = Convert.ToDouble(Txt_Job_Time.Text);

            if (!string.IsNullOrEmpty(Txt_Price.Text))
            {
                price = Convert.ToDouble(Txt_Price.Text);
                taka = Convert.ToDouble(Txt_Price.Text) * _priceRate;
            }

            if (Chk_Remember.Checked)
            {
                _priceTime.Client = _client;
                _priceTime.Category = category;
                _priceTime.Rate_ID = _rate.ID;
                _priceTime.Actual_Time = time;
                _priceTime.Price = price;
                _priceTime.Taka = taka;
                _db.Price_Times.AddOrUpdate(_priceTime);
                _db.SaveChanges();
            }

            var shift = _common.Current_Shift();
            var date = _common.Shift_Date(DateTime.Now, shift);

            //add to shiftReport
            var shiftReport = _db.Shift_Reports
                   .FirstOrDefault(x => x.Date == date & x.Shift == shift);

            if (shiftReport == null)
            {
                shiftReport = _common.Add_New_Shift_Report(date, shift);
                shiftReport = _db.Shift_Reports
                   .FirstOrDefault(x => x.Date == date & x.Shift == shift);
            }

            //add to workload
            Workload workLoad = null;
            if (Job != null & Job.JobId != null)
            {
                workLoad = _db.Workloads
                    .OrderByDescending(x => x.Id)
                    .First(x => x.JobId == Job.JobId);
            }

            if (workLoad == null)
            {
                workLoad = new Workload
                {
                    Date = date,
                    Shift = shift
                };
                _db.Workloads.Add(workLoad);
            }

            var shiftTime = _common.Shift_Time(_common.Current_Shift());

            var proCount = _db.Logs
                    .Where(x => x.JobId == Job.JobId & x.StartTime < shiftTime & x.Status == "Done" & x.Service != "QC")
                    .Select(x => x.Image)
                    .Distinct()
                    .Count();


            if (_file > proCount)
            {
                workLoad.File = _file - proCount;
                workLoad.Time = workLoad.File * time;
            }

            if (shiftReport.TotalFile > _file)
            {
                shiftReport.TotalFile -= Job.InputAmount;
                shiftReport.HandFile -= Job.InputAmount;
                shiftReport.NewFile -= Job.InputAmount;
                shiftReport.TotalLoad -= Job.InputAmount * Job.ActualTime;
                shiftReport.HandLoad -= Job.InputAmount * Job.ActualTime;
            }

            if (Redo != null)
            {
                Redo_Job redoJob = new Redo_Job();
                redoJob.JobId = Job.JobId;
                redoJob.RedoJobId = Redo.JobId;
                _db.RedoJob.Add(redoJob);
            }
        }

        private bool Job_Validated()
        {
            if (string.IsNullOrEmpty(Cmb_Client.Text))
            {
                MessageBox.Show(@"Invalid Client Name Entered.!!! Please Enter Correct Client Name", @"Invalid Client Name Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_file <= 0)
            {
                MessageBox.Show(@"Invalid Job Amount Entered.!!! Please Enter Correct Job Amount", @"Invalid Job Amount Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(Txt_Location.Text))
            {
                MessageBox.Show(@"Invalid Folder Location Entered.!!! Please Enter Correct Folder Location", @"Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var type = Cmb_Job_Type.Text;
            if (string.IsNullOrEmpty(type) | (type != "Regular" & type != "Test" & type != "Feedback"))
            {
                MessageBox.Show(@"Invalid Job Type Selection.!!! Please Only select within existing Option", @"Invalid Job Type Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}

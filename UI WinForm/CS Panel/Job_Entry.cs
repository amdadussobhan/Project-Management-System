using System;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;

namespace Skill_PMS.UI_WinForm.CS_Panel
{
    public partial class JobEntry : Form
    {
        public NewJob _newJob = new NewJob();
        public Redo_Job _redoJob = new Redo_Job();
        private Price_Time _priceTime = new Price_Time();
        private Rate _rate = new Rate();
        private Common _common = new Common();
        private SkillContext _db = new SkillContext();

        private double _priceRate;
        private int _file = 0;
        public string _newJobId = "", _oldJobId = "", _client ="";
        public bool _isModify = false;
        public bool _isRedo = false;

        public User User { get; set; }

        public JobEntry()
        {
            InitializeComponent();
        }

        private static JobEntry _instance;
        public static JobEntry GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new JobEntry();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Add_Job_Load(object sender, EventArgs e)
        {
            this.Text = @"New Job - " + User.Full_Name;

            var clients = _db.New_Jobs.OrderBy(x => x.Client).Select(x => x.Client).Where(x => x.StartsWith("SG")).ToArray();
            foreach (var client in clients.Distinct())
                Cmb_Client.Items.Add(client);

            var rates = _db.Rates.Select(x => x.Currency).Distinct();
            foreach (var rate in rates)
                Cmb_Currency.Items.Add(rate);

            if (_isModify | _isRedo)
            {
                _newJob = _db.New_Jobs.FirstOrDefault(x => x.JobId == _newJob.JobId);

                Cmb_Client.Text = _newJob.Client;
                Cmb_Catagory.Text = _newJob.Category;
                Txt_Price.Text = _newJob.Price + "";
                Cmb_Currency.Text = _newJob.Currency;
            }

            if (_isModify)
            {
                Cmb_Job_Type.Text = _newJob.Type + "";
                Txt_Job_Time.Text = _newJob.ActualTime + "";
                Txt_Amount.Text = _newJob.InputAmount + "";
                Dtp_Delivery.Value = _newJob.Delivery;
                Txt_Location.Text = _newJob.InputLocation;
                Txt_Job_ID.Text = _newJob.JobId;
            }
            else
            {
                Dtp_Delivery.Value = DateTime.Now.AddHours(1);
                Create_Job_ID();
            }

            if (_isRedo)
            {
                Txt_Job_Time.Text = "";
                Cmb_Job_Type.Text = "Feedback";
            }
        }

        private void Create_Job_ID()
        {
            var today = DateTime.Now.Date;
            var count = _db.New_Jobs
                .Count(x => x.Date == today);

            var date = DateTime.Now.ToString("yyMMdd");

            string id;
            if (_isModify)
                id = _oldJobId.Split('_')[0];
            else
            { 
                //create uniqe id
                x:
                id = date + ++count;
                if (count < 10)
                    id = date + "0" + count;

                var exist_job = _db.New_Jobs
                    .SqlQuery("Select * From NewJobs where JobID like '" + id + "%' ")
                    .Count();

                if (exist_job != 0)
                    goto x;
                //................
            }

            _newJobId = id + "_" + _client;
            Txt_Job_ID.Text = _newJobId;
        }

        private void Check_Category()
        {
            var categories = _db.Price_Times
                .Where(x => x.Client == Cmb_Client.Text)
                .Select(x => x.Category)
                .Distinct();

            foreach (var category in categories)
                Cmb_Catagory.Items.Add(category);
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

        private void Btn_Submit_Job_Click(object sender, EventArgs e)
        {
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

            if(!string.IsNullOrEmpty(Txt_Job_Time.Text))
                time = Convert.ToDouble(Txt_Job_Time.Text);

            if (!string.IsNullOrEmpty(Txt_Price.Text)) {
                price = Convert.ToDouble(Txt_Price.Text);
                taka = Convert.ToDouble(Txt_Price.Text) * _priceRate;
            }

            if (Chk_Remember.Checked){
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
            }//...................

            //add to workload
            Workload workLoad = null;
            if (_newJob != null & _newJob.JobId != null)
            {
                workLoad = _db.Workloads
                    .OrderByDescending(x=>x.Id)
                    .FirstOrDefault(x => x.JobId == _newJob.JobId);
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

            workLoad.File = _file;
            workLoad.Time = _file * time;
            //.................

            //update shiftReport table
            workLoad.Up = 0;
            shiftReport.TotalFile += workLoad.File;
            shiftReport.HandFile += workLoad.File;
            shiftReport.NewFile += workLoad.File;
            shiftReport.TotalLoad += workLoad.Time;
            shiftReport.HandLoad += workLoad.Time;
            shiftReport.Up = 0;
            //........................

            //update job table
            Create_Job_ID();
            _newJob.JobId = workLoad.JobId = _newJobId;
            _newJob.Client = _client;
            _newJob.Category = category;
            _newJob.Type = Cmb_Job_Type.Text;
            _newJob.Folder = Txt_Folder.Text;
            _newJob.InputAmount = _file;
            _newJob.InputLocation = Txt_Location.Text;
            _newJob.Price = price;
            _newJob.Taka = taka;
            _newJob.Currency = currency;
            _newJob.ActualTime = time;
            _newJob.Delivery = Dtp_Delivery.Value;
            _newJob.Receiver = User.Short_Name;
            _newJob.Up = 0;

            if (_priceTime != null)
                _newJob.Price_Times_ID = _priceTime.ID;

            if (!_isModify)
            {
                _newJob.Status = "New";
                _newJob.Date = DateTime.Now.Date;
                _newJob.Incoming = DateTime.Now;
                _db.New_Jobs.Add(_newJob);
            }

            if (_isRedo)
            {
                _redoJob.RedoJobId = _newJob.JobId;
                _db.RedoJob.Add(_redoJob);
            }

            _db.SaveChanges();
            _common.Change_Shift();
            if (shiftReport.TotalLoad == 0)
                _common.Check_Workload(shift);

            this.Close();
        }

        private void Cmb_Client_TextChanged(object sender, EventArgs e)
        {
            _client = Cmb_Client.Text.ToUpper();
            Cmb_Catagory.Text = "";
            Check_Category();
            Create_Job_ID();
        }

        private void Cmb_Category_TextChanged(object sender, EventArgs e)
        {
            var priceTimes = _db.Price_Times
                .FirstOrDefault(x => x.Client == Cmb_Client.Text & x.Category == Cmb_Catagory.Text);

            if(priceTimes != null) { 
                _priceTime = priceTimes;
                Txt_Price.Text = _priceTime.Price + "";
                Txt_Job_Time.Text = _priceTime.Actual_Time + "";

                if (_priceTime.Rate_ID != 0)
                {
                    _rate = _db.Rates.FirstOrDefault(x => x.ID == _priceTime.Rate_ID);
                    if (_rate != null)
                    {
                        _priceRate = _rate.Amount;
                        Cmb_Currency.Text = _rate.Currency + "";
                    }
                }
            }
            else
            {
                Txt_Price.Text = "";
                Cmb_Currency.Text = "";
                Txt_Job_Time.Text = "";
            }
        }

        private void Txt_Job_Location_TextChanged(object sender, EventArgs e)
        {
            var location = Txt_Location.Text;
            Txt_Folder.Text = Path.GetFileName(location);

            if (!Directory.Exists(location))
                MessageBox.Show(@"Invalid Location Entered.!!! Please Enter Correct Folder Location", @"Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Btn_Open_Folder_Click(object sender, EventArgs e)
        {
            var location = Txt_Location.Text;
            if (Directory.Exists(location))
                Process.Start(location);
            else
                MessageBox.Show(@"Folder doesn't Exist. Please Enter Correct Location...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Cmb_Currency_TextChanged(object sender, EventArgs e)
        {
            var rates = _db.Rates
                .FirstOrDefault(x => x.Currency == Cmb_Currency.Text);

            if (rates == null) return;
            _rate = rates;
            _priceTime.Rate_ID = _rate.ID;
            _priceRate = _rate.Amount;
        }

        private void Check_Total_Time()
        {
            var time = Txt_Job_Time.Text;
            var amount = Txt_Amount.Text;
            if(!string.IsNullOrEmpty(time) & !string.IsNullOrEmpty(amount))
                Lbl_Total_Time.Text = Convert.ToDouble(time) * Convert.ToDouble(amount) + "";
            else
                Lbl_Total_Time.Text = "";
        }

        private void Txt_Job_Time_TextChanged(object sender, EventArgs e)
        {
            Check_Total_Time();
        }

        private void Chk_Price_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Price.Checked)
            {
                Cmb_Currency.Visible = true;
                Txt_Price.Visible = true;
            }
            else
            {
                Cmb_Currency.Visible = false;
                Txt_Price.Visible = false;
            }
        }

        private void Txt_Amount_TextChanged(object sender, EventArgs e)
        {
            Check_Total_Time();
        }
    }
}

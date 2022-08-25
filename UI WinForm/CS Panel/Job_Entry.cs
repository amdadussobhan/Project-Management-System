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
        private Price_Time _priceTime = new Price_Time();
        private Rate _rate = new Rate();
        private Common _common = new Common();
        private SkillContext _db = new SkillContext();

        private int _file = 0;
        private double _priceRate = 0, _time = 0, _price = 0, _taka = 0;
        public string _newJobId = "", _oldJobId = "", _client ="", _category="";
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
            var count = _db.New_Jobs.Count(x => x.Date == today);
            var date = DateTime.Now.ToString("yyMMdd");
            string id;

            if (_isModify)
            {
                id = _oldJobId.Split('_')[1];
            }
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

            _newJobId = _client + "_" + id;
            Txt_Job_ID.Text = _newJobId;
        }

        private void Btn_Submit_Job_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_client))
            {
                MessageBox.Show(@"Invalid Client Name Entered.!!! Please Enter Correct Client Name", @"Invalid Client Name Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_file <= 0)
            {
                MessageBox.Show(@"Invalid Job Amount Entered.!!! Please Enter Correct Job Amount", @"Invalid Job Amount Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loc = Txt_Location.Text;
            if (string.IsNullOrEmpty(loc))
            {
                MessageBox.Show(@"Invalid Folder Location Entered.!!! Please Enter Correct Folder Location", @"Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var folder = Txt_Folder.Text;
            if (string.IsNullOrEmpty(loc))
            {
                MessageBox.Show(@"Invalid Folder Name Entered.!!! Please Enter Correct Folder Location", @"Invalid Folder Name Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var type = Cmb_Job_Type.Text;
            if (string.IsNullOrEmpty(type) | (type != "Regular" & type != "Test" & type != "Feedback"))
            {
                MessageBox.Show(@"Invalid Job Type Selection.!!! Please Only select within existing Option", @"Invalid Job Type Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var service = Cmb_Service.Text;
            if (string.IsNullOrEmpty(service) | (service != "Advance" & service != "Basic"))
            {
                MessageBox.Show(@"Invalid Job Service Selection.!!! Please Only select within existing Option", @"Invalid Job Service Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            //--Update Price Time Table
            
            if (Chk_Remember.Checked){
                _priceTime.Client = _client;
                _priceTime.Type = service;
                _priceTime.Category = _category;
                _priceTime.Rate_ID = _rate.ID;
                _priceTime.Lock_Time = _time;
                _priceTime.Price = _price;
                _db.Price_Times.AddOrUpdate(_priceTime);
                _db.SaveChanges();
            }
            //--End Update Price Time Table

            var shift = _common.Current_Shift();
            
            //--update job table
            Create_Job_ID();
            _newJob.JobId = _newJobId;
            _newJob.Client = _client;
            _newJob.Category = _category;
            _newJob.Type = type;
            _newJob.Folder = folder;
            _newJob.InputAmount = _file;
            _newJob.InputLocation = loc;
            _newJob.Price = _price;
            _newJob.Taka = _taka;
            _newJob.ActualTime = _newJob.TargetTime = _time;
            _newJob.Delivery = Dtp_Delivery.Value;
            _newJob.Receiver = User.Short_Name;
            _newJob.Updator = User.Short_Name;
            _newJob.Updated = DateTime.Now;
            _newJob.Shift = shift;
            _newJob.Team = service;
            _newJob.Up = 0;

            _priceTime.Up = 0;
            if (_priceTime != null)
                _newJob.Price_Times_ID = _priceTime.ID;

            if (!_isModify)
            {
                _newJob.Status = "New";
                _newJob.Date = DateTime.Now.Date;
                _newJob.Incoming = DateTime.Now;
                _newJob.Created = DateTime.Now;
                _newJob.ProStart = DateTime.Now;
                _newJob.ProEnd = DateTime.Now;
                _db.New_Jobs.Add(_newJob);
            }
            //--End update job table

            _db.SaveChanges();
            this.Close();
        }

        private void Cmb_Client_TextChanged(object sender, EventArgs e)
        {
            _client = Cmb_Client.Text.ToUpper();
            Check_Category();
            Create_Job_ID();
        }

        private void Cmb_Category_TextChanged(object sender, EventArgs e)
        {
            _category = Cmb_Catagory.Text;
            Check_Category();
        }

        private void Check_Category()
        {
            var categories = _db.Price_Times
                .Where(x => x.Client == Cmb_Client.Text)
                .Select(x => x.Category)
                .Distinct();

            foreach (var category in categories)
                Cmb_Catagory.Items.Add(category);

            var priceTimes = _db.Price_Times
                .FirstOrDefault(x => x.Client == Cmb_Client.Text & x.Category == _category);

            if (priceTimes != null)
            {
                _priceTime = priceTimes;
                Txt_Price.Text = _priceTime.Price + "";
                Txt_Job_Time.Text = _priceTime.Lock_Time + "";
                Cmb_Service.Text = _priceTime.Type + "";

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
                Txt_Job_Time.Text = "";
                Cmb_Service.Text = "";
                Cmb_Currency.Text = "";
            }
        }

        private void Cmb_Currency_TextChanged(object sender, EventArgs e)
        {
            _rate = _db.Rates.FirstOrDefault(x => x.Currency == Cmb_Currency.Text);

            if (_rate == null) return;

            _priceTime.Rate_ID = _rate.ID;
            _priceRate = _rate.Amount;
            Price_Calculate();
        }

        private void Txt_Price_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_Price.Text))
                _price = Convert.ToDouble(Txt_Price.Text);

            Price_Calculate();
        }

        private void Price_Calculate()
        {
            _taka = Convert.ToDouble(Txt_Price.Text) * _priceRate;
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

        private void Txt_Amount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_Amount.Text))
                _file = Convert.ToInt32(Txt_Amount.Text);

            Time_Calculate();
        }

        private void Txt_Job_Time_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_Job_Time.Text))
                _time = Convert.ToDouble(Txt_Job_Time.Text);

            Time_Calculate();
        }

        private void Time_Calculate()
        {
            Lbl_Total_Time.Text = (_time * _file) + "";
        }
    }
}

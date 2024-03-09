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

namespace Skill_PMS.UI_WinForm.CS_Panel
{
    public partial class Edit_Job : Form
    {
        private Common _common = new Common();
        private SkillContext _db = new SkillContext();
        private Rate _rate = new Rate();
        public bool _isRedo = false;
        public NewJob _newJob = new NewJob();
        private Price_Time _priceTime = new Price_Time();

        private int _file = 0;
        private double _priceRate = 0, _time = 0, _price = 0, _taka = 0;
        public string _newJobId = "", _oldJobId = "", _client = "", _category = "";

        public User User { get; set; }

        private static Edit_Job _instance;

        public static Edit_Job GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Edit_Job();
            else
                _instance.BringToFront();
            return _instance;
        }
        public Edit_Job()
        {
            InitializeComponent();
        }

        private void Edit_Job_Load(object sender, EventArgs e)
        {
            this.Text = @"Edit Job - " + User.Full_Name;

            var clients = _db.New_Jobs.OrderBy(x => x.Client).Select(x => x.Client).Where(x => x.StartsWith("SG")).ToArray();
            foreach (var client in clients.Distinct())
                Cmb_Client.Items.Add(client);

            var rates = _db.Rates.Select(x => x.Currency).Distinct();
            foreach (var rate in rates)
                Cmb_Currency.Items.Add(rate);

            _newJob = _db.New_Jobs.FirstOrDefault(x => x.JobId == _newJob.JobId);

            Cmb_Client.Text = _newJob.Client;
            Cmb_Catagory.Text = _newJob.Category;

            Cmb_Job_Type.Text = _newJob.Type + "";
            Txt_Job_Time.Text = _newJob.ActualTime + "";
            Txt_Amount.Text = _newJob.InputAmount + "";
            Dtp_Delivery.Value = _newJob.Delivery;
            Txt_Location.Text = _newJob.InputLocation;
            Txt_Job_ID.Text = _newJob.JobId;

            if (_isRedo)
            {
                Txt_Job_Time.Text = "";
                Cmb_Job_Type.Text = "Feedback";
            }
        }

        private void Price_Calculate()
        {
            _taka = Convert.ToDouble(Txt_Price.Text) * _priceRate;
        }

        private void Time_Calculate()
        {
            Lbl_Total_Time.Text = (_time * _file) + "";
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
    }
}

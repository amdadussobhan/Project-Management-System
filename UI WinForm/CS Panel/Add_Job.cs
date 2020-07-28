using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.CS_Panel;
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

namespace Skill_PMS
{
    public partial class Add_Job : Form
    {
        Job job = new Job();
        Actual_Price_Time actual_price_time = new Actual_Price_Time();
        Rate rate = new Rate();
        SkillContext DB = new SkillContext();

        double Price_Rate = 0;
        string ID = "", Job_ID = "";
        string Date = DateTime.Now.ToString("yyMMdd");

        public User User { get; set; }

        public Add_Job()
        {
            InitializeComponent();
        }

        private void Add_Job_Load(object sender, EventArgs e)
        {
            var Clients = DB.Jobs.Select(x => x.Client).Distinct();
            foreach (var Client in Clients)
                Cmb_Client.Items.Add(Client);

            var Rates = DB.Rates.Select(x => x.Currency).Distinct();
            foreach (var Rate in Rates)
                Cmb_Currency.Items.Add(Rate);

            Dtp_Delivery.Value = DateTime.Now.AddHours(1);
            Create_Job_ID();
        }

        void Create_Job_ID()
        {
            Check_Todays_Max_ID();
            Job_ID = Date + ID + "_" + Cmb_Client.Text;
            Txt_Job_ID.Text = Job_ID;
        }

        void Check_Todays_Max_ID()
        {
            int Count = DB.Jobs
                .SqlQuery("Select * From Jobs where Date = ' " + DateTime.Now.Date + " ' ")
                .Count();

            ID = ++Count + "";
            if (Count < 10)
                ID = "0" + Count;
        }

        void Check_Catagory()
        {
            var Categories = DB.Actual_Price_Times
                .Where(x => x.Client == Cmb_Client.Text)
                .Select(x => x.Category).Distinct();
            foreach (var Category in Categories)
            {
                Cmb_Catagory.Items.Add(Category);
            }
        }

        bool Job_Validate()
        {
            if (string.IsNullOrEmpty(Cmb_Client.Text))
            {
                MessageBox.Show("Invalid Client Name Entered.!!! Please Enter Correct Client Name", "Invalid Client Name Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(Txt_Amount.Text))
            {
                MessageBox.Show("Invalid Job Amount Entered.!!! Please Enter Correct Job Amount", "Invalid Job Amount Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(Txt_Location.Text))
            {
                MessageBox.Show("Invalid Folder Location Entered.!!! Please Enter Correct Folder Location", "Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Btn_Submit_Job_Click(object sender, EventArgs e)
        {
            if (Job_Validate()) { 
                rate.Currency = Cmb_Currency.Text;
                DB.Rates.AddOrUpdate(rate);

                string Client = Cmb_Client.Text;
                string Catagory = Cmb_Catagory.Text;
                double Time = Convert.ToDouble(Txt_Job_Time.Text);
                double Price = Convert.ToDouble(Txt_Price.Text);
                double Taka = Convert.ToDouble(Txt_Price.Text) * Price_Rate;

                actual_price_time.Client = Client;
                actual_price_time.Category = Catagory;
                actual_price_time.Rate = rate;
                actual_price_time.Time = Time;
                actual_price_time.Price = Price;
                actual_price_time.Taka = Taka;
                DB.Actual_Price_Times.AddOrUpdate(actual_price_time);
            
                Check_Todays_Max_ID();
                job.JobID = Job_ID;
                job.Client = Client;
                job.Category = Catagory;
                job.Type = Cmb_Job_Type.Text;
                job.Folder = Txt_Folder.Text;
                job.Status = "New";
                job.InputAmount = Convert.ToDouble(Txt_Amount.Text);
                job.InputLocation = Txt_Location.Text;
                job.Price = Price;
                job.Taka= Taka;
                job.Actual_Time = Time;
                job.Date = DateTime.Now.Date;
                job.Incoming = DateTime.Now;
                job.Delivery = Dtp_Delivery.Value;
                job.Receiver = User;
                job.Actual_Price_Times = actual_price_time;
                DB.Jobs.Add(job);

                DB.SaveChanges();
                this.Hide();
            }
        }

        private void Cmb_Client_TextChanged(object sender, EventArgs e)
        {
            Check_Catagory();
            Create_Job_ID();
        }

        private void Cmb_Catagory_TextChanged(object sender, EventArgs e)
        {
            var Actual_Price_Times = DB.Actual_Price_Times
                .Where(x => x.Client == Cmb_Client.Text & x.Category == Cmb_Catagory.Text)
                .Include(c => c.Rate)
                .FirstOrDefault<Actual_Price_Time>();

            if(Actual_Price_Times != null) { 
                actual_price_time = Actual_Price_Times;
                Txt_Price.Text = Actual_Price_Times.Price + "";
                Txt_Job_Time.Text = Actual_Price_Times.Time + "";

                if (Actual_Price_Times.Rate != null)
                {
                    rate = Actual_Price_Times.Rate;
                    Price_Rate = rate.Amount;
                    Cmb_Currency.Text = Actual_Price_Times.Rate.Currency + "";
                }
            }
        }

        private void Txt_Job_Location_TextChanged(object sender, EventArgs e)
        {
            string location = Txt_Location.Text;
            if (Directory.Exists(location))
                Txt_Folder.Text = Path.GetFileName(location);
            else
                MessageBox.Show("Invalid Location Entered.!!! Please Enter Correct Folder Location", "Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Btn_Open_Folder_Click(object sender, EventArgs e)
        {
            string location = Txt_Location.Text;
            if (Directory.Exists(location))
                Process.Start(location);
            else
                MessageBox.Show("Folder doesn't Exist. Please Enter Correct Location...", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Cmb_Currency_TextChanged(object sender, EventArgs e)
        {
            var Rates = DB.Rates
                .Where(x => x.Currency == Cmb_Currency.Text)
                .FirstOrDefault<Rate>();

            if (Rates != null)
            {
                rate = Rates;
                actual_price_time.Rate = Rates;
                Price_Rate = rate.Amount;
            }
        }

        void Check_Total_Time()
        {
            string Time = Txt_Job_Time.Text;
            string Amount = Txt_Amount.Text;
            if(!string.IsNullOrEmpty(Time) & !string.IsNullOrEmpty(Amount))
            {
                Lbl_Total_Time.Text = Convert.ToDouble(Time) * Convert.ToDouble(Amount) +"";
            }
        }

        private void Txt_Job_Time_TextChanged(object sender, EventArgs e)
        {
            Check_Total_Time();
        }

        private void Txt_Amount_TextChanged(object sender, EventArgs e)
        {
            Check_Total_Time();
        }
    }
}

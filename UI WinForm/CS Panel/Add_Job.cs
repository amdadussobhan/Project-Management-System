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
        Price_Time price_time = new Price_Time();
        Rate rate = new Rate();
        SkillContext DB = new SkillContext();

        double Price_Rate = 0;
        string ID = "", Job_ID = "";
        string Date = DateTime.Now.ToString("yyMMdd");

        public User user { get; set; }

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
            Job_ID = Date + ID + "_" + Cmb_Client.Text.ToUpper();
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
            var Categories = DB.Price_Times
                .Where(x => x.Client == Cmb_Client.Text)
                .Select(x => x.Category).Distinct();
            foreach (var Category in Categories)
            {
                Cmb_Catagory.Items.Add(Category);
            }
        }

        bool Job_Validated()
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
            if (Job_Validated()) {
                if (rate == null)
                {
                    if (!string.IsNullOrEmpty(Cmb_Currency.Text))
                    {
                        rate.Currency = Cmb_Currency.Text;
                        DB.Rates.AddOrUpdate(rate);
                        DB.SaveChanges();
                    }
                }

                double Time = 0, Price = 0, Taka = 0;

                string Client = Cmb_Client.Text.ToUpper();
                string Catagory = Cmb_Catagory.Text;

                if(!string.IsNullOrEmpty(Txt_Job_Time.Text))
                    Time = Convert.ToDouble(Txt_Job_Time.Text);

                if (!string.IsNullOrEmpty(Txt_Price.Text)) {
                    Price = Convert.ToDouble(Txt_Price.Text);
                    Taka = Convert.ToDouble(Txt_Price.Text) * Price_Rate;
                }

                if (Chk_Remember.Checked){
                    price_time.Client = Client;
                    price_time.Category = Catagory;
                    price_time.Rate_ID = rate.ID;
                    price_time.Actual_Time = Time;
                    price_time.Price = Price;
                    price_time.Taka = Taka;
                    DB.Price_Times.AddOrUpdate(price_time);
                    DB.SaveChanges();
                }

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
                job.Receiver_ID = user.ID;

                if(price_time != null)
                    job.Price_Times_ID = price_time.ID;

                DB.Jobs.AddOrUpdate(job);
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
            var Price_Times = DB.Price_Times
                .Where(x => x.Client == Cmb_Client.Text & x.Category == Cmb_Catagory.Text)
                .FirstOrDefault<Price_Time>();

            if(Price_Times != null) { 
                price_time = Price_Times;
                Txt_Price.Text = price_time.Price + "";
                Txt_Job_Time.Text = price_time.Actual_Time + "";

                if (price_time.Rate_ID != 0)
                {
                    rate = DB.Rates.Where(x => x.ID == price_time.Rate_ID).FirstOrDefault<Rate>();
                    Price_Rate = rate.Amount;
                    Cmb_Currency.Text = rate.Currency + "";
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
                price_time.Rate_ID = rate.ID;
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

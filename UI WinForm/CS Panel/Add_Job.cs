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
        Job Job = new Job();
        Actual_Time_Price Actual_Time_Price = new Actual_Time_Price();
        Rate Rate = new Rate();
        SkillContext DB = new SkillContext();

        double Price_Rate = 1;

        public User User { get; set; }

        public Add_Job()
        {
            InitializeComponent();
        }

        private void Add_Job_Load(object sender, EventArgs e)
        {
            Rate.Currency = "BDT";
            //DB.Rates.Add(Rate);

            Actual_Time_Price.Time= 5;
            Actual_Time_Price.Price = 0.6;
            Actual_Time_Price.Client = "CL";
            Actual_Time_Price.Category = "Mango";
            Actual_Time_Price.Rate = Rate;
            //DB.Actual_Time_Prices.Add(Actual_Time_Price);

            Job.Client = "CL";
            Job.Category = "Mango";
            Job.Incoming = DateTime.Now;
            Job.Delivery = DateTime.Now;
            //DB.Jobs.Add(Job);

            //DB.SaveChanges();

            var Clients = DB.Jobs.Select(x => x.Client).Distinct();
            foreach (var Client in Clients)
                Cmb_Client.Items.Add(Client);

            var Rates = DB.Rates.Select(x => x.Currency).Distinct();
            foreach (var Rate in Rates)
                Cmb_Currency.Items.Add(Rate);

            Txt_Folder.Text = Job.Folder;
        }

        void Check_Catagory()
        {
            var Categories = DB.Actual_Time_Prices
                .Where(x => x.Client == Cmb_Client.Text)
                .Select(x => x.Category).Distinct();
            foreach (var Category in Categories)
            {
                Cmb_Catagory.Items.Add(Category);
            }
        }

        private void Btn_Submit_Job_Click(object sender, EventArgs e)
        {
            Rate.Currency = Cmb_Currency.Text;
            DB.Rates.AddOrUpdate(Rate);

            Actual_Time_Price.Client = Cmb_Client.Text;
            Actual_Time_Price.Category = Cmb_Catagory.Text;
            Actual_Time_Price.Rate = Rate;
            Actual_Time_Price.Time = Convert.ToDouble(Txt_Job_Time.Text);
            Actual_Time_Price.Price = Convert.ToDouble(Txt_Price.Text);
            Actual_Time_Price.Taka = Convert.ToDouble(Txt_Price.Text) * Price_Rate;
            DB.Actual_Time_Prices.AddOrUpdate(Actual_Time_Price);

            Job.JobID = Txt_Job_ID.Text;
            Job.Client = Cmb_Client.Text;
            Job.Category = Cmb_Catagory.Text;
            Job.Type = Cmb_Job_Type.Text;
            Job.Folder = Txt_Folder.Text;
            Job.Status = "New";
            Job.InputAmount = Convert.ToDouble(Txt_Amount.Text);
            Job.InputLocation = Txt_Job_Location.Text;
            Job.Actual_Time_Price = Actual_Time_Price;
            Job.Incoming = DateTime.Now;
            Job.Delivery = Dtp_Delivery.Value;
            Job.Receiver = User;
            DB.Jobs.Add(Job);

            DB.SaveChanges();

            this.Hide();
        }

        private void Cmb_Client_TextChanged(object sender, EventArgs e)
        {
            Check_Catagory();
        }

        private void Cmb_Catagory_TextChanged(object sender, EventArgs e)
        {
            var Actual_Time_Prices = DB.Actual_Time_Prices
                .Where(x => x.Client == Cmb_Client.Text & x.Category == Cmb_Catagory.Text)
                .Include(c => c.Rate)
                .FirstOrDefault<Actual_Time_Price>();

            if(Actual_Time_Prices != null) { 
                Actual_Time_Price = Actual_Time_Prices;
                Txt_Price.Text = Actual_Time_Prices.Price + "";
                Txt_Job_Time.Text = Actual_Time_Prices.Time + "";

                if (Actual_Time_Prices.Rate != null)
                {
                    Rate = Actual_Time_Prices.Rate;
                    Price_Rate = Rate.Amount;
                    Cmb_Currency.Text = Actual_Time_Prices.Rate.Currency + "";
                }
            }
        }

        private void Txt_Job_Location_TextChanged(object sender, EventArgs e)
        {
            string location = Txt_Job_Location.Text;
            if (Directory.Exists(location))
                Txt_Folder.Text = Path.GetFileName(location);
            else
                MessageBox.Show("Invalid Location Entered.!!! Please Enter Correct Folder Location", "Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Btn_Open_Folder_Click(object sender, EventArgs e)
        {
            string location = Txt_Job_Location.Text;
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
                Rate = Rates;
                Actual_Time_Price.Rate = Rates;
                Price_Rate = Rate.Amount;
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

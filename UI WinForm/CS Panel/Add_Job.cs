using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.CS_Panel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS
{
    public partial class Add_Job : Form
    {
        Job Job = new Job();
        Price Price = new Price();
        Time Time = new Time();
        Rate Rate = new Rate();
        SkillContext DB = new SkillContext();

        public User User { get; set; }
        public Add_Job()
        {
            InitializeComponent();
        }

        private void Add_Job_Load(object sender, EventArgs e)
        {
            Rate.Currency= "EURO";
            Rate.Amount= 94;


            var Clients = DB.Jobs.Select(x => x.Client).Distinct();
            foreach (var Client in Clients)
            {
                Cmb_Client.Items.Add(Client);
            }

            Txt_Folder.Text = Job.Folder;
        }

        void Check_Catagory()
        {
            var Categories = DB.Prices
                .Where(x => x.Client == Cmb_Client.Text)
                .Select(x => x.Category).Distinct();
            foreach (var Category in Categories)
            {
                Cmb_Catagory.Items.Add(Category);
            }
        }

        private void Btn_Submit_Job_Click(object sender, EventArgs e)
        {
            Job.JobID = Txt_Job_ID.Text;
            Job.Client = Cmb_Client.Text;
            Job.Category = Cmb_Catagory.Text;
            Job.Type = Cmb_Job_Type.Text;
            Job.Folder = Txt_Folder.Text;
            Job.Status = "New";
            Job.InputLocation = Txt_Job_Location.Text;
            Job.JobTime = Convert.ToDouble(Txt_Job_Time.Text);
            Job.Incoming = DateTime.Now;
            Job.Delivery = DateTime.Now;



            Price.ID = Job.ID;
            Time.Amount = Convert.ToDouble(Txt_Job_Time.Text);
            Price.Amount= Convert.ToDouble(Txt_Price.Text);
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
            var Prices = DB.Prices
                .Where(x => x.Category == Cmb_Catagory.Text)
                .FirstOrDefault<Price>();
            Txt_Price.Text = Prices.Amount + "";
        }
    }
}

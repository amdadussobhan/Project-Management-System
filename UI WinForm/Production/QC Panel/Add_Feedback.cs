using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    public partial class Add_Feedback : Form
    {
        public User User { get; set; }
        public string _client = "", _newJobId = "", _location = "", _folder = "";
        private Common _common = new Common();
        public NewJob _newJob = new NewJob();
        private SkillContext _db = new SkillContext();

        DateTime _delivery = DateTime.Now.AddHours(1);
        private double _time = 0;
        private static Add_Feedback _instance;

        public static Add_Feedback GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Add_Feedback();
            else
                _instance.BringToFront();
            return _instance;
        }

        public Add_Feedback()
        {
            InitializeComponent();
        }

        private void Add_Feedback_Load(object sender, EventArgs e)
        {
            this.Text = @"New Feedback - " + User.Full_Name;

            var clients = _db.New_Jobs.OrderBy(x => x.Client).Select(x => x.Client).Where(x => x.StartsWith("SG")).ToArray();
            foreach (var client in clients.Distinct())
                Cmb_Client.Items.Add(client);

            Create_Job_ID();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_client))
            {
                MessageBox.Show(@"Invalid Client Name Entered.!!! Please Enter Correct Client Name", @"Invalid Client Name Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int file = Convert.ToInt32(Txt_Amount.Text);
            if (file <= 0)
            {
                MessageBox.Show(@"Invalid Job Amount Entered.!!! Please Enter Correct Job Amount", @"Invalid Job Amount Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_location))
            {
                MessageBox.Show(@"Invalid Folder Location Entered.!!! Please Enter Correct Folder Location", @"Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_folder))
            {
                MessageBox.Show(@"Invalid Folder Name Entered.!!! Please Enter Correct Folder Location", @"Invalid Folder Name Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var shift = _common.Current_Shift();
            
            Create_Job_ID();
            _newJob.JobId = _newJobId;
            _newJob.Client = _client;
            _newJob.Type = "Feedback";
            _newJob.Folder = _folder;
            _newJob.InputAmount = file;
            _newJob.InputLocation = _newJob.WorkingLocation = _location;
            _newJob.ActualTime = _newJob.TargetTime = _newJob.QcTime = _time;
            _newJob.Delivery = _delivery;
            _newJob.Receiver = User.Short_Name;
            _newJob.Updator = User.Short_Name;
            _newJob.SiName = User.Short_Name;
            _newJob.Updated = DateTime.Now;
            _newJob.ProStart = DateTime.Now;
            _newJob.ProEnd = DateTime.Now;
            _newJob.Shift = shift;
            _newJob.Team = "Advance";
            _newJob.Loc = "Dhaka";
            _newJob.Status = "Pro";
            _newJob.Date = DateTime.Now.Date;
            _newJob.Incoming = DateTime.Now;
            _newJob.Created = DateTime.Now;
            _newJob.Up = 0;

            _db.New_Jobs.Add(_newJob);
            _db.SaveChanges();
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cmb_Client_SelectedValueChanged(object sender, EventArgs e)
        {
            _client = Cmb_Client.Text.ToUpper();
            Create_Job_ID();
        }

        private void Txt_Loc_TextChanged(object sender, EventArgs e)
        {
            _location = Txt_Loc.Text;
            _folder = Txt_Folder.Text = Path.GetFileName(_location);

            if (!Directory.Exists(_location))
                MessageBox.Show(@"Invalid Location Entered.!!! Please Enter Correct Folder Location", @"Invalid Location Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Create_Job_ID()
        {
            var today = DateTime.Now.Date;
            var count = _db.New_Jobs.Count(x => x.Date == today);
            var date = DateTime.Now.ToString("yyMMdd");
            string id;

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

            _newJobId = _client + "_" + id;
            Txt_Job_ID.Text = _newJobId;
        }
    }
}

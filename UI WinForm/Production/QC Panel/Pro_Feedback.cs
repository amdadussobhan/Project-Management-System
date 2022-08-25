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
    public partial class Pro_Feedback : Form
    {
        public User User { get; set; }
        SkillContext _db = new SkillContext();
        public NewJob _job = new NewJob();
        public string _name, _image, _remarks, _location;

        public Pro_Feedback()
        {
            InitializeComponent();
        }

        private static Pro_Feedback _instance;

        public static Pro_Feedback GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Pro_Feedback();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Btn_Open_Folder_Click(object sender, EventArgs e)
        {
            _location = Txt_Location.Text;
            if(!Directory.Exists(_location))
                Directory.CreateDirectory(_location);

            Process.Start(_location);
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            _location = Txt_Location.Text;
            _remarks = Txt_Remarks.Text.Replace("'", "");
            if (!string.IsNullOrEmpty(_remarks) & !string.IsNullOrEmpty(_location))
            {
                var feedback = _db.Feedback.FirstOrDefault(x => x.JobId == _job.JobId + "" & x.Name == _name & x.Image == _image & x.Reporter == User.Short_Name);

                if (feedback == null)
                {
                    feedback = new Feedback
                    {
                        Name = _name,
                        Image = _image,
                        JobId = _job.JobId + "",
                        Folder = _job.Folder,
                        Location = _location,
                        Reporter = User.Short_Name,
                    };
                    _db.Feedback.Add(feedback);

                    feedback.Up = 0;
                }
                feedback.Remarks += _remarks +", ";
                feedback.ReportTime = DateTime.Now;
                _db.SaveChanges();

                Directory.CreateDirectory(_location);
                Process.Start(_location);

                this.Close();
            }
            else
                MessageBox.Show(@"Description is empty. Please write something to describe...", @"Description is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            _location = Txt_Location.Text = @"\\192.168.1.147\Skill_Server\6.Feedback\Designers\" + DateTime.Now.ToString("dd_MMM_yy") + "\\" + _job.JobId + "\\" + _name;
            Txt_Name.Text = _name;
            Txt_JobID.Text = _job.JobId + "";
            Txt_Image.Text = _image;
        }
    }
}

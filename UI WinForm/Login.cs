using System;
using System.Linq;
using System.Windows.Forms;
using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.admin_Panel;
using Skill_PMS.UI_WinForm.CS_Panel;
using Skill_PMS.UI_WinForm.HR_Panel;
using Skill_PMS.UI_WinForm.Production.Designer;
using Skill_PMS.UI_WinForm.Production.QC_Panel;
using Skill_PMS.UI_WinForm.Production.SI_Panel;

namespace Skill_PMS.UI_WinForm
{
    public partial class Login : Form
    {
        private User _user;
        private readonly Common _common = new Common();
        private readonly SkillContext _db = new SkillContext();
        private string _shift;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Check_user();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            _shift = Cmb_Shift.Text;
            var date = _common.Shift_Date(DateTime.Now, _shift);
            if (_user == null) 
            {
                MessageBox.Show(@"Please Enter Proper User ID and Try again", @"User doesn't Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_shift))
            {
                MessageBox.Show(@"Please select Your Working Shift", @"Shift is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_user.Password != Txt_Pss.Text)
            {
                MessageBox.Show(@"Please try again with correct password", @"Password Don't Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var login = _db.Performances
                .Where(x => x.Name == _user.Short_Name & x.Date == date & x.Status == "Running").Count();

            if (login > 0 & _user.Role == "")
            {
                MessageBox.Show(@"You are already loged in. Please close that then try again", @"Already Loged in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            var performance = _db.Performances
                .FirstOrDefault(x => x.Name == _user.Short_Name & x.Date ==  date & x.Shift == _shift);

            if (performance == null)
            {
                performance = new Performance
                {
                    Name = _user.Short_Name, 
                    Shift = _shift, 
                    Date = date, 
                    Login = DateTime.Now
                };
                _db.Performances.Add(performance);
            }

            performance.Logout = DateTime.Now;
            _user.Shift = _shift;
            performance.Status = "Running";

            var shiftReport = _db.Shift_Reports
                .FirstOrDefault(x => x.Date == date & x.Shift == _shift);

            if (shiftReport == null)
                shiftReport = _common.Add_New_Shift_Report(date, _shift);

            shiftReport.Capacity = _common.Current_Designers().Count * 420;
            shiftReport.Up = 0;
            _db.SaveChanges();
            _common.Change_Shift();

            if (shiftReport.TotalLoad == 0)
                _common.Check_Workload(_shift);

            switch (_user.Role)
            {
                case "CS":
                {
                    var csDashboard = CsDashboard.GetInstance();
                    CsDashboard.User = _user;
                    csDashboard.Performance = performance;
                    csDashboard.Show();
                    break;
                }
                case "SI":
                {
                    var siDashboard = SiDashboard.GetInstance();
                    SiDashboard._user = _user;
                    siDashboard._performance = performance;
                    siDashboard.Show();
                    break;
                }
                case "HR":
                {
                    var hrDashboard = HrDashboard.GetInstance();
                    HrDashboard.User = _user;
                    hrDashboard.Performance = performance;
                    hrDashboard.Show();
                    break;
                }
                case "QC":
                {
                    var qcDashboard = QcDashboard.GetInstance();
                    QcDashboard._user = _user;
                    qcDashboard._performance = performance;
                    qcDashboard.Show();
                    break;
                }
                default:
                {
                    var dashboard = Dashboard.GetInstance();
                    Dashboard.User = _user;
                    dashboard.Performance = performance;
                    dashboard.Show();
                    break;
                }
            }
            this.Hide();
        }

        private void Check_user()
        {
            _user = _db.Users
                .FirstOrDefault(x => x.Employee_ID == Txt_Usr.Text);

            if (_user != null)
            {
                Txt_Name.Text = _user.Full_Name;
                Txt_Designation.Text = _user.Designation;
                if (_user.Role == "admin" | _user.Role == "HR")
                    Cmb_Shift.Text = _common.Current_Shift();
            }
            else
            {
                Txt_Name.Text = "";
                Txt_Designation.Text = "";
                Cmb_Shift.Text = "";
            }
        }

        private void Txt_Usr_TextChanged(object sender, EventArgs e)
        {
            Check_user();
        }

        private void Lnk_Sync_Click(object sender, EventArgs e)
        {
            var adminPanel = AdminPanel.GetInstance();
            adminPanel.Show();
            this.Hide();
        }
    }
}

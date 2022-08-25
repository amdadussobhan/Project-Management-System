using Skill_PMS.Controller;
using Skill_PMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    public partial class Double_Login : Form
    {
        private readonly SkillContext _db = new SkillContext();
        private readonly Common _common = new Common();
        public string _name;

        public Double_Login()
        {
            InitializeComponent();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_allow_Click(object sender, EventArgs e)
        {
            var shift = _common.Current_Shift();
            var date = _common.Shift_Date(DateTime.Now, shift);
            var reason = Txt_Reason.Text;
            if (reason.Length > 5)
            {
                var performance = _db.Performances
                    .FirstOrDefault(x => x.Name == _name & x.Date == date & x.Shift == shift);

                performance.Status = "";
                _db.SaveChanges();

                MessageBox.Show(@"Double login allowed successfully. Please try again now", @"Successfully allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }else
                MessageBox.Show(@"Invlid Reason entered. Please explain properly then try again", @"Invlid Reason", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

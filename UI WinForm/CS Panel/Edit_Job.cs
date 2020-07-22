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
        public Edit_Job()
        {
            InitializeComponent();
            this.user = user;
        }

        public User user { get; set; }

        private void Edit_Job_Load(object sender, EventArgs e)
        {

        }
    }
}

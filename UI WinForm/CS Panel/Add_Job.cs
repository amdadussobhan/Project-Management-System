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

namespace Skill_PMS
{
    public partial class Add_Job : Form
    {
        public Add_Job(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        public User user { get; set; }

        private void Add_Job_Load(object sender, EventArgs e)
        {
            label1.Text = user.Short_Name;
        }
    }
}

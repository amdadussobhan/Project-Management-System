using Skill_PMS.UI_WinForm.Production.QC_Panel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class Counter : Form
    {
        public static bool Minimized;
        public static double TotalTime;
        public static string Status;

        public Counter()
        {
            InitializeComponent();
        }

        private void Tmr_Count_m_Tick(object sender, EventArgs e)
        {
            if (Status == "QC")
            {
                var timespan = TimeSpan.FromSeconds(++TotalTime);
                Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");
            }
            else
            {
                var timespan = TimeSpan.FromSeconds(--TotalTime);
                Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");
            }

            if (TotalTime < 0)
            {
                this.BackColor = this.BackColor == Color.FromArgb(255, 90, 100) ? Color.FromArgb(255, 195, 195) : Color.FromArgb(255, 90, 100);
            }

            if (!Minimized)
                this.Close();

            if(Status == "QC")
            {
                if (QC_Process._total_Time == 0)
                    this.Close();
            }
            else
            {
                if (Processing._proTime == 0)
                    this.Close();
            }
        }

        private void Counter_Load(object sender, EventArgs e)
        {
            Tmr_Count_m.Start();
        }
    }
}

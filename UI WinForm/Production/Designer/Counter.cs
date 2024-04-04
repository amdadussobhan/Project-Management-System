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

        private static Counter _instance;
        public static Counter GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Counter();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Tmr_Count_m_Tick(object sender, EventArgs e)
        {
            Check_Time();

            if (!Minimized)
                this.Close();

            if (Status == "QC")
            {
                //if (QC_Process._total_Time == 0)
                //    this.Close();
            }
            else
            {
                var processing = Processing.GetInstance();
                if (processing._proTime == 0)
                    this.Close();
            }
        }

        private void Counter_Load(object sender, EventArgs e)
        {
            Check_Time();
            Tmr_Count_m.Start();
        }

        private void Check_Time()
        {
            if (Status == "QC")
            {
                //var timespan = TimeSpan.FromSeconds(++TotalTime);
                //Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");
            }
            else
            {
                var timespan = TimeSpan.FromSeconds(Processing.TotalTime);
                Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");
            }

            if (TotalTime < 0)
            {
                this.BackColor = this.BackColor == Color.FromArgb(255, 90, 100) ? Color.FromArgb(255, 195, 195) : Color.FromArgb(255, 90, 100);
            }
        }
    }
}

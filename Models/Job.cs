using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string JobID { get; set; }
        public string Client { get; set; }
        public string Folder { get; set; }
        public string Category { get; set; }
        public string Service { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        public DateTime Date { get; set; }
        public DateTime Incoming { get; set; }
        public DateTime Delivery { get; set; }

        public double InputAmount { get; set; }
        public double Pro_Done { get; set; }
        public double OutputAmount { get; set; }

        public string InputLocation { get; set; }
        public string WorkingLocation { get; set; }
        public string OutputLocation { get; set; }

        public double Price { get; set; }
        public double Taka { get; set; }

        public double Actual_Time { get; set; }
        public double Target_Time { get; set; }
        public double Pro_Time { get; set; }

        public User Receiver { get; set; }
        public User Sender { get; set; }
        public User Shift_Incharge { get; set; }
        public User Quality_Control { get; set; }

        public double CP_Time { get; set; }
        public double RET_Time { get; set; }
        public double SHA_Time { get; set; }
        public double MSK_Time { get; set; }
        public double CC_Time { get; set; }
        public double NJ_Time { get; set; }
        public double LIQ_Time { get; set; }
        public double AI_Time { get; set; }

        public double CP_Price { get; set; }
        public double RET_Price { get; set; }
        public double SHA_Price { get; set; }
        public double MSK_Price { get; set; }
        public double CC_Price { get; set; }
        public double NJ_Price { get; set; }
        public double LIQ_Price { get; set; }
        public double AI_Price { get; set; }

        public Actual_Price_Time Actual_Price_Times { get; set; }
        public Target_Pro_Time Target_Pro_Times { get; set; }
    }
}

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
        public DateTime Incoming { get; set; }
        public DateTime Delivery { get; set; }
        public double InputAmount { get; set; }
        public double OutputAmount { get; set; }
        public string InputLocation { get; set; }
        public string WorkingLocation { get; set; }
        public string OutputLocation { get; set; }
        public string Service { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public double ProTime { get; set; }
        public Actual_Time_Price Actual_Time_Price { get; set; }
        public Pro_Time_Price Pro_Time_Price { get; set; }
        public User Receiver { get; set; }
        public User Sender { get; set; }
    }
}

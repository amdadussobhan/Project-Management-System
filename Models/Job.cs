using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class Job
    {
        public int ID { get; set; }
        public string Client { get; set; }
        public string Category { get; set; }
        public string Folder { get; set; }
        public DateTime Incoming { get; set; }
        public DateTime Delivery { get; set; }
        public string InputLocation { get; set; }
        public string WorkingLocation { get; set; }
        public string OutputLocation { get; set; }
        public string Service { get; set; }
        public string Status { get; set; }
        public float JobTime { get; set; }
        public float ProTime { get; set; }
        public float InputAmount { get; set; }
        public float OutputAmount { get; set; }
        public PriceTime PriceTime { get; set; }
        public User Receiver { get; set; }
        public User Sender { get; set; }
    }
}

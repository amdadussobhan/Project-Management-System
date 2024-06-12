using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    internal class Misc_Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public double Time { get; set; }
        public DateTime Apply_Time { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public bool SI_Status { get; set; }
        public bool Up { get; set; }
    }
}

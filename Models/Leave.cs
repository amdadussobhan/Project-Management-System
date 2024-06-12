using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    internal class Leave
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime Apply_Date { get; set; }
        public DateTime Leave_Date { get; set; }
        public bool SI_Status { get; set; }
        public bool PM_Status { get; set; }
        public bool HR_Status { get; set; }
        public bool Up { get; set; }
    }
}

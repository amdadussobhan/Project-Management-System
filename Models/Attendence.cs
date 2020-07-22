using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class Attendence
    {
        public int ID { get; set; }
        public int User { get; set; }
        public DateTime Date { get; set; }
        public DateTime Login { get; set; }
        public DateTime Logout { get; set; }
        public string Status { get; set; }
        public int Workingtime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    public class Attend
    {
        public int ID { get; set; }
        public User User { get; set; }
        public DateTime Attend_Date { get; set; }
        public DateTime Login { get; set; }
        public DateTime Logout { get; set; }
        public string Status { get; set; }
        public int Workingtime { get; set; }
    }
}

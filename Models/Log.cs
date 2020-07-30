using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    public class Log
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Job_ID { get; set; }
        public string Status { get; set; }
        public DateTime Start_Job { get; set; }
        public DateTime Finish_Job { get; set; }
        public double Job_Time { get; set; }
        public double Pro_Time { get; set; }
        public int Efficiency { get; set; }
        public string Service { get; set; }
        public string Image { get; set; }
    }
}

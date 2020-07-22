using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class Production_Log
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Job Job { get; set; }
        public string Status { get; set; }
        public DateTime Start_Job { get; set; }
        public DateTime Finish_Job { get; set; }
        public float Job_Time { get; set; }
        public float Pro_Time { get; set; }
        public string Service { get; set; }
    }
}

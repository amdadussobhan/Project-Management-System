using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class Production
    {
        public int ID { get; set; }
        public int Job_ID { get; set; }
        public int Amount { get; set; }
        public string Service { get; set; }
        public double Job_Time { get; set; }
        public double Pro_Time { get; set; }
        public int Efficiency { get; set; }
        public int Quality { get; set; }
    }
}

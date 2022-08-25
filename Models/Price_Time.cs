using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    public class Price_Time
    {
        public int ID { get; set; }
        public int Rate_ID { get; set; }
        public string Client { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public double Lock_Time { get; set; }
        public double Price { get; set; }
        public int Up { get; set; }
    }
}

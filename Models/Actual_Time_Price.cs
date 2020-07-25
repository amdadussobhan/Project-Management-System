using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    public class Actual_Time_Price
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public double Time { get; set; }
        public double Taka { get; set; }
        public Rate Rate { get; set; }
        public string Client { get; set; }
        public string Category { get; set; }
    }
}

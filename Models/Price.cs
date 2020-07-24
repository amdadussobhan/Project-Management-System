using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class Price
    {
        public int ID { get; set; }
        public double Amount { get; set; }
        public double Taka { get; set; }
        public Rate Rate { get; set; }
        public string Client { get; set; }
        public string Category { get; set; }
        public double CP_Price { get; set; }
        public double RET_Price { get; set; }
        public double SHA_Price { get; set; }
        public double MSK_Price { get; set; }
        public double CC_Price { get; set; }
        public double NJ_Price { get; set; }
        public double LIQ_Price { get; set; }
        public double AI_Price { get; set; }
        public double QC_Price { get; set; }
    }
}

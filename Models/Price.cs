using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class PriceTime
    {
        public int ID { get; set; }
        public float Price { get; set; }
        public float Time { get; set; }
        public float CP_Price { get; set; }
        public float RET_Price { get; set; }
        public float SHA_Price { get; set; }
        public float MSK_Price { get; set; }
        public float CC_Price { get; set; }
        public float NJ_Price { get; set; }
        public float LIQ_Price { get; set; }
        public float CP_Time { get; set; }
        public float RET_Time { get; set; }
        public float SHA_Time { get; set; }
        public float MSK_Time { get; set; }
        public float CC_Time { get; set; }
        public float NJ_Time { get; set; }
        public float LIQ_Time { get; set; }
    }
}

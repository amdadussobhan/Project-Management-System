using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    public class ImageTime
    {
        public int ID { get; set; }
        public string JobId { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        public double Actual_Time { get; set; }
        public double Target_Time { get; set; }

        public double CP_Time { get; set; }
        public double RET_Time { get; set; }
        public double SHA_Time { get; set; }
        public double MSK_Time { get; set; }
        public double CC_Time { get; set; }
        public double NJ_Time { get; set; }
        public double LIQ_Time { get; set; }
        public double AI_Time { get; set; }
        public double QC_Time { get; set; }
    }
}

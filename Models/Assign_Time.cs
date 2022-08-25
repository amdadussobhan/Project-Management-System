using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class Assign_Time
    {
        public int ID { get; set; }
        public string Client { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public double Clipping_Time { get; set; }
        public double Basic_Time { get; set; }
        public double Pre_Process { get; set; }
        public double Post_Process { get; set; }
        public int Up { get; set; }
    }
}

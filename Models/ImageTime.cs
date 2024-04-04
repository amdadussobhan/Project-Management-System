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
        public string Job_ID { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public double Total_Time { get; set; }
        public double Clipping_Time { get; set; }
        public double Basic_Time { get; set; }
        public double Pre_Process { get; set; }
        public double Post_Process { get; set; }
        public string Assigner { get; set; }
        public Boolean IsFixed { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}

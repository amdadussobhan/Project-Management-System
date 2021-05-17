using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    public class ShiftReport
    {
        public int Id { get; set; }
        public string Shift { get; set; }
        public DateTime Date { get; set; }
        public double Capacity { get; set; }

        public double AchieveLoad { get; set; }
        public double AchieveProTime { get; set; }
        
        public int PreFile { get; set; }
        public int NewFile { get; set; }
        public double PreLoad { get; set; }

        public int TotalFile { get; set; }
        public double TotalLoad { get; set; }

        public int Last24Input { get; set; }
        public int Last24Output { get; set; }

        public int Revenue { get; set; }

        public int HandFile { get; set; }
        public double HandLoad { get; set; }

        public int ProDone { get; set; }
        public int QcDone { get; set; }

        public int Quality { get; set; }
        public int TargetAchieve { get; set; }
        public int Efficiency { get; set; }
        public int Up { get; set; }
    }
}

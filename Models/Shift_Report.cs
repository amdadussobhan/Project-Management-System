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
        public string Team { get; set; }
        public DateTime Date { get; set; }
        public double Capacity { get; set; }
        public double QC_Capacity { get; set; }
        public double LoadAchieve { get; set; }
        public double ProAchieve { get; set; }
        public int NewFile { get; set; } //received file only within this shift
        public int PreFile { get; set; } //Its Last shift HandFile
        public double PreLoad { get; set; } //Its Last shift HandLoad
        public int HandFile { get; set; } //its will be next shift PreFile
        public double HandLoad { get; set; } //its will be next shift PreLoad
        public int TotalFile { get; set; }
        public int OutputFile { get; set; }
        public double TotalLoad { get; set; }
        public int Last24Input { get; set; }
        public int Last24Output { get; set; }
        public int Revenue { get; set; }
        public int ProDone { get; set; }
        public int QcDone { get; set; }
        public int Quality { get; set; }
        public int TargetAchieve { get; set; }
        public int Efficiency { get; set; }
        public int Up { get; set; }
    }
}

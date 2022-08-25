using System;

namespace Skill_PMS.Models
{
    public class Workload
    {
        public int Id { get; set; }
        public string JobId { get; set; }
        public string Team { get; set; }
        public string Shift { get; set; }
        public string Service { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int Input_File { get; set; }
        public int Output_File { get; set; }
        public double TargetTime { get; set; }
        public double ProTime { get; set; }
        public double Total_Load { get; set; }
        public double Load_Achieve { get; set; }
        public double Pro_Achieve { get; set; }
        public bool IsDone { get; set; }
        public int Up { get; set; }
    }
}

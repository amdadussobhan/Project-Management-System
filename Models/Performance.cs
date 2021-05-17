using System;

namespace Skill_PMS.Models
{
    public class Performance
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public DateTime Login { get; set; }
        public DateTime Logout { get; set; }

        public string Status { get; set; }
        public string Shift { get; set; }
        public string Name { get; set; }
        public int WorkingTime { get; set; }

        public int File { get; set; }
        public double JobTime { get; set; }
        public double ProTime { get; set; }
        
        public int Efficiency { get; set; }
        public int Quality { get; set; }
        public int Up { get; set; }
    }
}

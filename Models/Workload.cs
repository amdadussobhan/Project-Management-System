using System;

namespace Skill_PMS.Models
{
    public class Workload
    {
        public int Id { get; set; }
        public string JobId { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }

        public int File { get; set; }
        public double Time { get; set; }
        public int Up { get; set; }
    }
}

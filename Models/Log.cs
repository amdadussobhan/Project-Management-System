using System;

namespace Skill_PMS.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobId { get; set; }
        public string Status { get; set; }
        public string Shift { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double ActualTime { get; set; }
        public double TargetTime { get; set; }
        public double ProTime { get; set; }
        public double RestTime { get; set; }
        public double PauseTime { get; set; }
        public int Efficiency { get; set; }
        public int Quality { get; set; }
        public string Service { get; set; }
        public string Image { get; set; }
        public string Remarks { get; set; }
        public string InputLocation { get; set; }
        public string WorkingLocation { get; set; }
        public string OutputLocation { get; set; }
        public double Support { get; set; }
        public double Revenue { get; set; }
        public int Up { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    public class MyJob
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobId { get; set; }
        public string Service { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double JobTime { get; set; }
        public double ProTime { get; set; }
        public double TotalJobTime { get; set; }
        public double TotalProTime { get; set; }
        public int Efficiency { get; set; }
        public int Quality { get; set; }
        public int Up { get; set; }
    }
}

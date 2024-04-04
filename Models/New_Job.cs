using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    public class NewJob
    {
        public int Id { get; set; }
        public string JobId { get; set; }
        public string Client { get; set; }
        public string Folder { get; set; }
        public string Category { get; set; }
        public string Service { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Team { get; set; }
        public string Loc { get; set; }
        public string Format { get; set; }
        public string Remarks { get; set; }
        public string Shift { get; set; }
        public DateTime Date { get; set; }
        public DateTime Incoming { get; set; }
        public DateTime Delivery { get; set; }
        public DateTime ProStart { get; set; }
        public DateTime ProEnd { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int InputAmount { get; set; }
        public int ProDone { get; set; }
        public int ScriptAmount { get; set; }
        public int OutputAmount { get; set; }
        public string InputLocation { get; set; }
        public string WorkingLocation { get; set; }
        public string OutputLocation { get; set; }
        public double Price { get; set; }
        public double Taka { get; set; }
        public double ActualTime { get; set; }
        public double TargetTime { get; set; }
        public double ProTime { get; set; }
        public double QcTime { get; set; }
        public int ActualEfficiency { get; set; }
        public int TargetEfficiency { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string Updator { get; set; }
        public string SiName { get; set; }
        public string QcName { get; set; }
        public int Price_Times_ID { get; set; }
        public int Up { get; set; }
    }
}

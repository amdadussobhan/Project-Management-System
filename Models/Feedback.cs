using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reporter { get; set; }
        public string JobId { get; set; }
        public string Folder { get; set; }
        public DateTime ReportTime { get; set; }
        public string Image { get; set; }
        public string Remarks { get; set; }
        public string Location { get; set; }
        public int Up { get; set; }
    }
}

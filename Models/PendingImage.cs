using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class PendingImage
    {
        public int ID { get; set; }
        public string JobId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Models
{
    class Attendence
    {
        public int ID { get; set; }
        public string User_ID { get; set; }
        public string Short_Name { get; set; }
        public string Employee_ID { get; set; }
        public string Phone { get; set; }
        public string Designation { get; set; }
        public string Father_Name { get; set; }
        public string Mother_Name { get; set; }
        public string Guardian_No { get; set; }
        public string Team { get; set; }
        public string Shift { get; set; }
        public Boolean IsActive { get; set; }
    }
}

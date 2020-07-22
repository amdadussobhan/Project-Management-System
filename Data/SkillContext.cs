using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_PMS.Data
{
    class SkillContext : DbContext
    {
        public SkillContext() : base("SkillContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Attendence> Attendences { get; set; }
        public DbSet<PriceTime> PriceTimes { get; set; }
        public DbSet<Production_Log> Production_Logs { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}

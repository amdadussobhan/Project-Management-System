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
        public DbSet<User> Users { get; set; }
        public DbSet<Attend> Attends { get; set; }
        public DbSet<Actual_Price_Time> Actual_Price_Times { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Target_Pro_Time> Target_Pro_Times { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public SkillContext() : base("SkillContext")
        {

        }
    }
}

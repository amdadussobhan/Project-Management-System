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
        public DbSet<Attend> Attends { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}

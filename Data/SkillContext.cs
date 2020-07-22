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
        public DbSet<User> Users { get; set; }
    }
}

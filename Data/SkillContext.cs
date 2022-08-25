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
        public DbSet<Log> Logs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MyJob> My_Jobs { get; set; }
        public DbSet<Price_Time> Price_Times { get; set; }
        public DbSet<Assign_Time> Assign_Time { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Sub_Folder> Sub_Folders { get; set; }
        public DbSet<NewJob> New_Jobs { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<ShiftReport> Shift_Reports { get; set; }
        public DbSet<Workload> Workloads { get; set; }
        public DbSet<ImageTime> ImageTime { get; set; }
        public DbSet<PendingImage> PendingImage { get; set; }
        public DbSet<Feedback> Feedback { get; set; }

        public SkillContext() : base("SkillContext")
        {

        }
    }
}

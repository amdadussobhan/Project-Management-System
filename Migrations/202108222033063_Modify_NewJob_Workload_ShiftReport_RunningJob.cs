namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify_NewJob_Workload_ShiftReport_RunningJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewJobs", "ProStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.NewJobs", "ProEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Running_Jobs", "Location", c => c.String());
            AddColumn("dbo.ShiftReports", "QC_Capacity", c => c.Double(nullable: false));
            AddColumn("dbo.ShiftReports", "ProDone", c => c.Int(nullable: false));
            AddColumn("dbo.Sub_Folder", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sub_Folder", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Workloads", "TargetTime", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "ProTime", c => c.Double(nullable: false));
            DropColumn("dbo.Sub_Folder", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sub_Folder", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.Workloads", "ProTime");
            DropColumn("dbo.Workloads", "TargetTime");
            DropColumn("dbo.Sub_Folder", "Updated");
            DropColumn("dbo.Sub_Folder", "Created");
            DropColumn("dbo.ShiftReports", "ProDone");
            DropColumn("dbo.ShiftReports", "QC_Capacity");
            DropColumn("dbo.Running_Jobs", "Location");
            DropColumn("dbo.NewJobs", "ProEnd");
            DropColumn("dbo.NewJobs", "ProStart");
        }
    }
}

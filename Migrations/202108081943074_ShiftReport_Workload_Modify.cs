namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShiftReport_Workload_Modify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Team", c => c.String());
            AddColumn("dbo.ShiftReports", "LoadAchieve", c => c.Double(nullable: false));
            AddColumn("dbo.ShiftReports", "ProAchieve", c => c.Double(nullable: false));
            AddColumn("dbo.ShiftReports", "OutputFile", c => c.Int(nullable: false));
            AddColumn("dbo.Workloads", "Load_Achieve", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "Pro_Achieve", c => c.Double(nullable: false));
            DropColumn("dbo.ShiftReports", "AchieveLoad");
            DropColumn("dbo.ShiftReports", "AchieveProTime");
            DropColumn("dbo.ShiftReports", "ProDone");
            DropColumn("dbo.Workloads", "Total_Achieve");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workloads", "Total_Achieve", c => c.Double(nullable: false));
            AddColumn("dbo.ShiftReports", "ProDone", c => c.Int(nullable: false));
            AddColumn("dbo.ShiftReports", "AchieveProTime", c => c.Double(nullable: false));
            AddColumn("dbo.ShiftReports", "AchieveLoad", c => c.Double(nullable: false));
            DropColumn("dbo.Workloads", "Pro_Achieve");
            DropColumn("dbo.Workloads", "Load_Achieve");
            DropColumn("dbo.ShiftReports", "OutputFile");
            DropColumn("dbo.ShiftReports", "ProAchieve");
            DropColumn("dbo.ShiftReports", "LoadAchieve");
            DropColumn("dbo.Logs", "Team");
        }
    }
}

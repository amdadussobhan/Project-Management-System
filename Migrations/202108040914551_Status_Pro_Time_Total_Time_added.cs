namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status_Pro_Time_Total_Time_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workloads", "Status", c => c.String());
            AddColumn("dbo.Workloads", "Input_File", c => c.Int(nullable: false));
            AddColumn("dbo.Workloads", "Target_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "Total_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "Pro_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "IsDone", c => c.Boolean(nullable: false));
            DropColumn("dbo.Workloads", "File");
            DropColumn("dbo.Workloads", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workloads", "Time", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "File", c => c.Int(nullable: false));
            DropColumn("dbo.Workloads", "IsDone");
            DropColumn("dbo.Workloads", "Pro_Time");
            DropColumn("dbo.Workloads", "Total_Time");
            DropColumn("dbo.Workloads", "Target_Time");
            DropColumn("dbo.Workloads", "Input_File");
            DropColumn("dbo.Workloads", "Status");
        }
    }
}

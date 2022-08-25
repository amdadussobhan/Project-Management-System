namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RunningJob_Added_Workload_Modified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Running_Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.String(),
                        Team = c.String(),
                        Shift = c.String(),
                        Service = c.String(),
                        Type = c.String(),
                        Date = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Creator = c.String(),
                        Updator = c.String(),
                        Input_File = c.Int(nullable: false),
                        Output_File = c.Int(nullable: false),
                        Target_Time = c.Double(nullable: false),
                        Total_Time = c.Double(nullable: false),
                        Pro_Time = c.Double(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        Up = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ShiftReports", "Team", c => c.String());
            AddColumn("dbo.Workloads", "Total_Load", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "Total_Achieve", c => c.Double(nullable: false));
            DropColumn("dbo.Workloads", "Target_Time");
            DropColumn("dbo.Workloads", "Total_Time");
            DropColumn("dbo.Workloads", "Pro_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workloads", "Pro_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "Total_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "Target_Time", c => c.Double(nullable: false));
            DropColumn("dbo.Workloads", "Total_Achieve");
            DropColumn("dbo.Workloads", "Total_Load");
            DropColumn("dbo.ShiftReports", "Team");
            DropTable("dbo.Running_Jobs");
        }
    }
}

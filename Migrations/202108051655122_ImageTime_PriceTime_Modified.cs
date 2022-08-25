namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageTime_PriceTime_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageTimes", "Job_ID", c => c.String());
            AddColumn("dbo.NewJobs", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.NewJobs", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.NewJobs", "Updator", c => c.String());
            AddColumn("dbo.Price_Time", "Type", c => c.String());
            AddColumn("dbo.Price_Time", "QC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Workloads", "Format", c => c.String());
            AddColumn("dbo.Workloads", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Workloads", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Workloads", "Creator", c => c.String());
            AddColumn("dbo.Workloads", "Updator", c => c.String());
            DropColumn("dbo.ImageTimes", "JobId");
            DropColumn("dbo.ImageTimes", "Category");
            DropColumn("dbo.ImageTimes", "Actual_Time");
            DropColumn("dbo.ImageTimes", "Target_Time");
            DropColumn("dbo.Workloads", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workloads", "Status", c => c.String());
            AddColumn("dbo.ImageTimes", "Target_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "Actual_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "Category", c => c.String());
            AddColumn("dbo.ImageTimes", "JobId", c => c.String());
            DropColumn("dbo.Workloads", "Updator");
            DropColumn("dbo.Workloads", "Creator");
            DropColumn("dbo.Workloads", "Updated");
            DropColumn("dbo.Workloads", "Created");
            DropColumn("dbo.Workloads", "Format");
            DropColumn("dbo.Price_Time", "QC_Time");
            DropColumn("dbo.Price_Time", "Type");
            DropColumn("dbo.NewJobs", "Updator");
            DropColumn("dbo.NewJobs", "Updated");
            DropColumn("dbo.NewJobs", "Created");
            DropColumn("dbo.ImageTimes", "Job_ID");
        }
    }
}

namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify_Log_Job_Price_Time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageTimes", "Type", c => c.String());
            AddColumn("dbo.Logs", "Type", c => c.String());
            AddColumn("dbo.NewJobs", "Shift", c => c.String());
            AddColumn("dbo.Price_Time", "Service", c => c.String());
            AddColumn("dbo.Workloads", "Type", c => c.String());
            DropColumn("dbo.Logs", "Category");
            DropColumn("dbo.Workloads", "Format");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workloads", "Format", c => c.String());
            AddColumn("dbo.Logs", "Category", c => c.String());
            DropColumn("dbo.Workloads", "Type");
            DropColumn("dbo.Price_Time", "Service");
            DropColumn("dbo.NewJobs", "Shift");
            DropColumn("dbo.Logs", "Type");
            DropColumn("dbo.ImageTimes", "Type");
        }
    }
}

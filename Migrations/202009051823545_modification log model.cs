namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationlogmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Actual_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Logs", "Target_Time", c => c.Double(nullable: false));
            DropColumn("dbo.Logs", "Job_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "Job_Time", c => c.Double(nullable: false));
            DropColumn("dbo.Logs", "Target_Time");
            DropColumn("dbo.Logs", "Actual_Time");
        }
    }
}

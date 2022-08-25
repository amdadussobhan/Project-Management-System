namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QCTimeinRunningJobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Running_Jobs", "QC_Time", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Running_Jobs", "QC_Time");
        }
    }
}

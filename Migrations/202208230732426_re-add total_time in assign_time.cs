namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdtotal_timeinassign_time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assign_Time", "Total_Time", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assign_Time", "Total_Time");
        }
    }
}

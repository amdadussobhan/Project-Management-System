namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OTStartfieldaddedinPerformance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Performances", "OT_Start", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Performances", "OT_Start");
        }
    }
}

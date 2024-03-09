namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OTaddedinperformance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Performances", "IsOT", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Performances", "IsOT");
        }
    }
}

namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OTadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "IsOT", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "IsOT");
        }
    }
}

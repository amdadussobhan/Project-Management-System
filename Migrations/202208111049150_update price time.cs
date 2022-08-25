namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepricetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Price_Time", "Lock_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Up", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Price_Time", "Up");
            DropColumn("dbo.Price_Time", "Lock_Time");
        }
    }
}

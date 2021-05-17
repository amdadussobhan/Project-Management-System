namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDatetologmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Date");
        }
    }
}

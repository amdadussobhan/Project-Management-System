namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatetomyjobmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.My_Job", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.My_Job", "Date");
        }
    }
}

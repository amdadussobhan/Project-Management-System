namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfileformateinjobmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.New_Job", "Format", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.New_Job", "Format");
        }
    }
}

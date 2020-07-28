namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateinJobsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Date");
        }
    }
}

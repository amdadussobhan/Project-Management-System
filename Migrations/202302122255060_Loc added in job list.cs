namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Locaddedinjoblist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewJobs", "Loc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewJobs", "Loc");
        }
    }
}

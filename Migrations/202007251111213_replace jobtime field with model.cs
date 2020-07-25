namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replacejobtimefieldwithmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "JobTime");
            DropColumn("dbo.Jobs", "TargetTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "TargetTime", c => c.Double(nullable: false));
            AddColumn("dbo.Jobs", "JobTime", c => c.Double(nullable: false));
        }
    }
}

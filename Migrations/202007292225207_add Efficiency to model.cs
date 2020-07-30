namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEfficiencytomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Actual_Efficiency", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "Target_Efficiency", c => c.Int(nullable: false));
            AddColumn("dbo.Logs", "Efficiency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Efficiency");
            DropColumn("dbo.Jobs", "Target_Efficiency");
            DropColumn("dbo.Jobs", "Actual_Efficiency");
        }
    }
}

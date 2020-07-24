namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTypeinJobModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Type", c => c.String());
            AddColumn("dbo.PriceTimes", "AI_Price", c => c.Single(nullable: false));
            AddColumn("dbo.PriceTimes", "QC_Price", c => c.Single(nullable: false));
            AddColumn("dbo.PriceTimes", "AI_Time", c => c.Single(nullable: false));
            AddColumn("dbo.PriceTimes", "QC_Time", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PriceTimes", "QC_Time");
            DropColumn("dbo.PriceTimes", "AI_Time");
            DropColumn("dbo.PriceTimes", "QC_Price");
            DropColumn("dbo.PriceTimes", "AI_Price");
            DropColumn("dbo.Jobs", "Type");
        }
    }
}

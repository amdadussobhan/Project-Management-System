namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moveratefieldjobs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Price_Rate_ID", "dbo.Rates");
            DropIndex("dbo.Jobs", new[] { "Price_Rate_ID" });
            AddColumn("dbo.Prices", "Taka", c => c.Double(nullable: false));
            AddColumn("dbo.Prices", "Rate_ID", c => c.Int());
            CreateIndex("dbo.Prices", "Rate_ID");
            AddForeignKey("dbo.Prices", "Rate_ID", "dbo.Rates", "ID");
            DropColumn("dbo.Jobs", "Price_Rate_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Price_Rate_ID", c => c.Int());
            DropForeignKey("dbo.Prices", "Rate_ID", "dbo.Rates");
            DropIndex("dbo.Prices", new[] { "Rate_ID" });
            DropColumn("dbo.Prices", "Rate_ID");
            DropColumn("dbo.Prices", "Taka");
            CreateIndex("dbo.Jobs", "Price_Rate_ID");
            AddForeignKey("dbo.Jobs", "Price_Rate_ID", "dbo.Rates", "ID");
        }
    }
}

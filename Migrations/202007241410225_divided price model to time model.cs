namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dividedpricemodeltotimemodel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Attendences", newName: "Attends");
            RenameTable(name: "dbo.Production_Log", newName: "Logs");
            DropForeignKey("dbo.Jobs", "PriceTime_ID", "dbo.PriceTimes");
            DropIndex("dbo.Jobs", new[] { "PriceTime_ID" });
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Client = c.String(),
                        Category = c.String(),
                        CP_Price = c.Double(nullable: false),
                        RET_Price = c.Double(nullable: false),
                        SHA_Price = c.Double(nullable: false),
                        MSK_Price = c.Double(nullable: false),
                        CC_Price = c.Double(nullable: false),
                        NJ_Price = c.Double(nullable: false),
                        LIQ_Price = c.Double(nullable: false),
                        AI_Price = c.Double(nullable: false),
                        QC_Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Currency = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Client = c.String(),
                        Category = c.String(),
                        CP_Time = c.Double(nullable: false),
                        RET_Time = c.Double(nullable: false),
                        SHA_Time = c.Double(nullable: false),
                        MSK_Time = c.Double(nullable: false),
                        CC_Time = c.Double(nullable: false),
                        NJ_Time = c.Double(nullable: false),
                        LIQ_Time = c.Double(nullable: false),
                        AI_Time = c.Double(nullable: false),
                        QC_Time = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Jobs", "Price_ID", c => c.Int());
            AddColumn("dbo.Jobs", "Price_Rate_ID", c => c.Int());
            AddColumn("dbo.Jobs", "Time_ID", c => c.Int());
            CreateIndex("dbo.Jobs", "Price_ID");
            CreateIndex("dbo.Jobs", "Price_Rate_ID");
            CreateIndex("dbo.Jobs", "Time_ID");
            AddForeignKey("dbo.Jobs", "Price_ID", "dbo.Prices", "ID");
            AddForeignKey("dbo.Jobs", "Price_Rate_ID", "dbo.Rates", "ID");
            AddForeignKey("dbo.Jobs", "Time_ID", "dbo.Times", "ID");
            DropColumn("dbo.Jobs", "PriceTime_ID");
            DropTable("dbo.PriceTimes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PriceTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Time = c.Double(nullable: false),
                        CP_Price = c.Double(nullable: false),
                        RET_Price = c.Double(nullable: false),
                        SHA_Price = c.Double(nullable: false),
                        MSK_Price = c.Double(nullable: false),
                        CC_Price = c.Double(nullable: false),
                        NJ_Price = c.Double(nullable: false),
                        LIQ_Price = c.Double(nullable: false),
                        AI_Price = c.Double(nullable: false),
                        QC_Price = c.Double(nullable: false),
                        CP_Time = c.Double(nullable: false),
                        RET_Time = c.Double(nullable: false),
                        SHA_Time = c.Double(nullable: false),
                        MSK_Time = c.Double(nullable: false),
                        CC_Time = c.Double(nullable: false),
                        NJ_Time = c.Double(nullable: false),
                        LIQ_Time = c.Double(nullable: false),
                        AI_Time = c.Double(nullable: false),
                        QC_Time = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Jobs", "PriceTime_ID", c => c.Int());
            DropForeignKey("dbo.Jobs", "Time_ID", "dbo.Times");
            DropForeignKey("dbo.Jobs", "Price_Rate_ID", "dbo.Rates");
            DropForeignKey("dbo.Jobs", "Price_ID", "dbo.Prices");
            DropIndex("dbo.Jobs", new[] { "Time_ID" });
            DropIndex("dbo.Jobs", new[] { "Price_Rate_ID" });
            DropIndex("dbo.Jobs", new[] { "Price_ID" });
            DropColumn("dbo.Jobs", "Time_ID");
            DropColumn("dbo.Jobs", "Price_Rate_ID");
            DropColumn("dbo.Jobs", "Price_ID");
            DropTable("dbo.Times");
            DropTable("dbo.Rates");
            DropTable("dbo.Prices");
            CreateIndex("dbo.Jobs", "PriceTime_ID");
            AddForeignKey("dbo.Jobs", "PriceTime_ID", "dbo.PriceTimes", "ID");
            RenameTable(name: "dbo.Logs", newName: "Production_Log");
            RenameTable(name: "dbo.Attends", newName: "Attendences");
        }
    }
}

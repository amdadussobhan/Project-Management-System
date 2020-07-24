namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changefloattodouble : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobID", c => c.String());
            AlterColumn("dbo.Jobs", "JobTime", c => c.Double(nullable: false));
            AlterColumn("dbo.Jobs", "ProTime", c => c.Double(nullable: false));
            AlterColumn("dbo.Jobs", "InputAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.Jobs", "OutputAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "Time", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "CP_Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "RET_Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "SHA_Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "MSK_Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "CC_Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "NJ_Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "LIQ_Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "AI_Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "QC_Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "CP_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "RET_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "SHA_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "MSK_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "CC_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "NJ_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "LIQ_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "AI_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.PriceTimes", "QC_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.Production_Log", "Job_Time", c => c.Double(nullable: false));
            AlterColumn("dbo.Production_Log", "Pro_Time", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Production_Log", "Pro_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.Production_Log", "Job_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "QC_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "AI_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "LIQ_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "NJ_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "CC_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "MSK_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "SHA_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "RET_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "CP_Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "QC_Price", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "AI_Price", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "LIQ_Price", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "NJ_Price", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "CC_Price", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "MSK_Price", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "SHA_Price", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "RET_Price", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "CP_Price", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "Time", c => c.Single(nullable: false));
            AlterColumn("dbo.PriceTimes", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Jobs", "OutputAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.Jobs", "InputAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.Jobs", "ProTime", c => c.Single(nullable: false));
            AlterColumn("dbo.Jobs", "JobTime", c => c.Single(nullable: false));
            DropColumn("dbo.Jobs", "JobID");
        }
    }
}

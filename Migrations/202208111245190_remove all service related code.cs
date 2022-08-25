namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeallservicerelatedcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageTimes", "Clipping_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "Basic_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "Process1_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "Process2_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "Team", c => c.String());
            DropColumn("dbo.ImageTimes", "CP_Time");
            DropColumn("dbo.ImageTimes", "RET_Time");
            DropColumn("dbo.ImageTimes", "SHA_Time");
            DropColumn("dbo.ImageTimes", "MSK_Time");
            DropColumn("dbo.ImageTimes", "CC_Time");
            DropColumn("dbo.ImageTimes", "NJ_Time");
            DropColumn("dbo.ImageTimes", "LIQ_Time");
            DropColumn("dbo.ImageTimes", "AI_Time");
            DropColumn("dbo.NewJobs", "CP_Time");
            DropColumn("dbo.NewJobs", "RET_Time");
            DropColumn("dbo.NewJobs", "SHA_Time");
            DropColumn("dbo.NewJobs", "MSK_Time");
            DropColumn("dbo.NewJobs", "CC_Time");
            DropColumn("dbo.NewJobs", "NJ_Time");
            DropColumn("dbo.NewJobs", "LIQ_Time");
            DropColumn("dbo.NewJobs", "AI_Time");
            DropColumn("dbo.NewJobs", "QC_Time");
            DropColumn("dbo.NewJobs", "CP_Price");
            DropColumn("dbo.NewJobs", "RET_Price");
            DropColumn("dbo.NewJobs", "SHA_Price");
            DropColumn("dbo.NewJobs", "MSK_Price");
            DropColumn("dbo.NewJobs", "CC_Price");
            DropColumn("dbo.NewJobs", "NJ_Price");
            DropColumn("dbo.NewJobs", "LIQ_Price");
            DropColumn("dbo.NewJobs", "AI_Price");
            DropColumn("dbo.NewJobs", "QC_Price");
            DropColumn("dbo.Price_Time", "Actual_Time");
            DropColumn("dbo.Price_Time", "CP_Time");
            DropColumn("dbo.Price_Time", "RET_Time");
            DropColumn("dbo.Price_Time", "SHA_Time");
            DropColumn("dbo.Price_Time", "MSK_Time");
            DropColumn("dbo.Price_Time", "CC_Time");
            DropColumn("dbo.Price_Time", "NJ_Time");
            DropColumn("dbo.Price_Time", "LIQ_Time");
            DropColumn("dbo.Price_Time", "AI_Time");
            DropColumn("dbo.Price_Time", "QC_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Price_Time", "QC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "AI_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "LIQ_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "NJ_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "CC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "MSK_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "SHA_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "RET_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "CP_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Actual_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "QC_Price", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "AI_Price", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "LIQ_Price", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "NJ_Price", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "CC_Price", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "MSK_Price", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "SHA_Price", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "RET_Price", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "CP_Price", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "QC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "AI_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "LIQ_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "NJ_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "CC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "MSK_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "SHA_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "RET_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "CP_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "AI_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "LIQ_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "NJ_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "CC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "MSK_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "SHA_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "RET_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "CP_Time", c => c.Double(nullable: false));
            DropColumn("dbo.NewJobs", "Team");
            DropColumn("dbo.ImageTimes", "Process2_Time");
            DropColumn("dbo.ImageTimes", "Process1_Time");
            DropColumn("dbo.ImageTimes", "Basic_Time");
            DropColumn("dbo.ImageTimes", "Clipping_Time");
        }
    }
}

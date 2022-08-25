namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productivitycalculationwithprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageTimes", "Pre_Process", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "Post_Process", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Clipping_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Basic_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Pre_Process", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Post_Process", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "QC_Time", c => c.Double(nullable: false));
            DropColumn("dbo.ImageTimes", "Process1_Time");
            DropColumn("dbo.ImageTimes", "Process2_Time");
            DropColumn("dbo.NewJobs", "Currency");
            DropColumn("dbo.Price_Time", "Taka");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Price_Time", "Taka", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "Currency", c => c.String());
            AddColumn("dbo.ImageTimes", "Process2_Time", c => c.Double(nullable: false));
            AddColumn("dbo.ImageTimes", "Process1_Time", c => c.Double(nullable: false));
            DropColumn("dbo.Price_Time", "QC_Time");
            DropColumn("dbo.Price_Time", "Post_Process");
            DropColumn("dbo.Price_Time", "Pre_Process");
            DropColumn("dbo.Price_Time", "Basic_Time");
            DropColumn("dbo.Price_Time", "Clipping_Time");
            DropColumn("dbo.ImageTimes", "Post_Process");
            DropColumn("dbo.ImageTimes", "Pre_Process");
        }
    }
}

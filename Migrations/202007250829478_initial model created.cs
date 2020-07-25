namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmodelcreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actual_Time_Price",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Time = c.Double(nullable: false),
                        Taka = c.Double(nullable: false),
                        Client = c.String(),
                        Category = c.String(),
                        Rate_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rates", t => t.Rate_ID)
                .Index(t => t.Rate_ID);
            
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
                "dbo.Attends",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Attend_Date = c.DateTime(nullable: false),
                        Login = c.DateTime(nullable: false),
                        Logout = c.DateTime(nullable: false),
                        Status = c.String(),
                        Workingtime = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Full_Name = c.String(),
                        Short_Name = c.String(),
                        Employee_ID = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        Designation = c.String(),
                        Role = c.String(),
                        Father_Name = c.String(),
                        Mother_Name = c.String(),
                        Guardian_No = c.String(),
                        Team = c.String(),
                        Shift = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobID = c.String(),
                        Client = c.String(),
                        Category = c.String(),
                        Folder = c.String(),
                        Incoming = c.DateTime(nullable: false),
                        Delivery = c.DateTime(nullable: false),
                        InputLocation = c.String(),
                        WorkingLocation = c.String(),
                        OutputLocation = c.String(),
                        Service = c.String(),
                        Status = c.String(),
                        Type = c.String(),
                        JobTime = c.Double(nullable: false),
                        TargetTime = c.Double(nullable: false),
                        ProTime = c.Double(nullable: false),
                        InputAmount = c.Double(nullable: false),
                        OutputAmount = c.Double(nullable: false),
                        Price_ID = c.Int(),
                        Receiver_ID = c.Int(),
                        Sender_ID = c.Int(),
                        Time_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actual_Time_Price", t => t.Price_ID)
                .ForeignKey("dbo.Users", t => t.Receiver_ID)
                .ForeignKey("dbo.Users", t => t.Sender_ID)
                .ForeignKey("dbo.Pro_Time_Price", t => t.Time_ID)
                .Index(t => t.Price_ID)
                .Index(t => t.Receiver_ID)
                .Index(t => t.Sender_ID)
                .Index(t => t.Time_ID);
            
            CreateTable(
                "dbo.Pro_Time_Price",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.Double(nullable: false),
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
                "dbo.Logs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Start_Job = c.DateTime(nullable: false),
                        Finish_Job = c.DateTime(nullable: false),
                        Job_Time = c.Double(nullable: false),
                        Pro_Time = c.Double(nullable: false),
                        Service = c.String(),
                        Job_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.Job_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Job_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Logs", "Job_ID", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "Time_ID", "dbo.Pro_Time_Price");
            DropForeignKey("dbo.Jobs", "Sender_ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "Receiver_ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "Price_ID", "dbo.Actual_Time_Price");
            DropForeignKey("dbo.Attends", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Actual_Time_Price", "Rate_ID", "dbo.Rates");
            DropIndex("dbo.Logs", new[] { "User_ID" });
            DropIndex("dbo.Logs", new[] { "Job_ID" });
            DropIndex("dbo.Jobs", new[] { "Time_ID" });
            DropIndex("dbo.Jobs", new[] { "Sender_ID" });
            DropIndex("dbo.Jobs", new[] { "Receiver_ID" });
            DropIndex("dbo.Jobs", new[] { "Price_ID" });
            DropIndex("dbo.Attends", new[] { "User_ID" });
            DropIndex("dbo.Actual_Time_Price", new[] { "Rate_ID" });
            DropTable("dbo.Logs");
            DropTable("dbo.Pro_Time_Price");
            DropTable("dbo.Jobs");
            DropTable("dbo.Users");
            DropTable("dbo.Attends");
            DropTable("dbo.Rates");
            DropTable("dbo.Actual_Time_Price");
        }
    }
}

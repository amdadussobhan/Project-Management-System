namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actual_Price_Time",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.Double(nullable: false),
                        Client = c.String(),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                        Taka = c.Double(nullable: false),
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
                        Folder = c.String(),
                        Category = c.String(),
                        Service = c.String(),
                        Status = c.String(),
                        Type = c.String(),
                        Incoming = c.DateTime(nullable: false),
                        Delivery = c.DateTime(nullable: false),
                        InputAmount = c.Double(nullable: false),
                        Pro_Done = c.Double(nullable: false),
                        OutputAmount = c.Double(nullable: false),
                        InputLocation = c.String(),
                        WorkingLocation = c.String(),
                        OutputLocation = c.String(),
                        Price = c.Double(nullable: false),
                        Taka = c.Double(nullable: false),
                        Actual_Time = c.Double(nullable: false),
                        Target_Time = c.Double(nullable: false),
                        Pro_Time = c.Double(nullable: false),
                        CP_Time = c.Double(nullable: false),
                        RET_Time = c.Double(nullable: false),
                        SHA_Time = c.Double(nullable: false),
                        MSK_Time = c.Double(nullable: false),
                        CC_Time = c.Double(nullable: false),
                        NJ_Time = c.Double(nullable: false),
                        LIQ_Time = c.Double(nullable: false),
                        AI_Time = c.Double(nullable: false),
                        CP_Price = c.Double(nullable: false),
                        RET_Price = c.Double(nullable: false),
                        SHA_Price = c.Double(nullable: false),
                        MSK_Price = c.Double(nullable: false),
                        CC_Price = c.Double(nullable: false),
                        NJ_Price = c.Double(nullable: false),
                        LIQ_Price = c.Double(nullable: false),
                        AI_Price = c.Double(nullable: false),
                        Actual_Price_Times_ID = c.Int(),
                        Quality_Control_ID = c.Int(),
                        Receiver_ID = c.Int(),
                        Sender_ID = c.Int(),
                        Shift_Incharge_ID = c.Int(),
                        Target_Pro_Times_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actual_Price_Time", t => t.Actual_Price_Times_ID)
                .ForeignKey("dbo.Users", t => t.Quality_Control_ID)
                .ForeignKey("dbo.Users", t => t.Receiver_ID)
                .ForeignKey("dbo.Users", t => t.Sender_ID)
                .ForeignKey("dbo.Users", t => t.Shift_Incharge_ID)
                .ForeignKey("dbo.Target_Pro_Time", t => t.Target_Pro_Times_ID)
                .Index(t => t.Actual_Price_Times_ID)
                .Index(t => t.Quality_Control_ID)
                .Index(t => t.Receiver_ID)
                .Index(t => t.Sender_ID)
                .Index(t => t.Shift_Incharge_ID)
                .Index(t => t.Target_Pro_Times_ID);
            
            CreateTable(
                "dbo.Target_Pro_Time",
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
                        Image = c.String(),
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
            DropForeignKey("dbo.Jobs", "Target_Pro_Times_ID", "dbo.Target_Pro_Time");
            DropForeignKey("dbo.Jobs", "Shift_Incharge_ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "Sender_ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "Receiver_ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "Quality_Control_ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "Actual_Price_Times_ID", "dbo.Actual_Price_Time");
            DropForeignKey("dbo.Attends", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Actual_Price_Time", "Rate_ID", "dbo.Rates");
            DropIndex("dbo.Logs", new[] { "User_ID" });
            DropIndex("dbo.Logs", new[] { "Job_ID" });
            DropIndex("dbo.Jobs", new[] { "Target_Pro_Times_ID" });
            DropIndex("dbo.Jobs", new[] { "Shift_Incharge_ID" });
            DropIndex("dbo.Jobs", new[] { "Sender_ID" });
            DropIndex("dbo.Jobs", new[] { "Receiver_ID" });
            DropIndex("dbo.Jobs", new[] { "Quality_Control_ID" });
            DropIndex("dbo.Jobs", new[] { "Actual_Price_Times_ID" });
            DropIndex("dbo.Attends", new[] { "User_ID" });
            DropIndex("dbo.Actual_Price_Time", new[] { "Rate_ID" });
            DropTable("dbo.Logs");
            DropTable("dbo.Target_Pro_Time");
            DropTable("dbo.Jobs");
            DropTable("dbo.Users");
            DropTable("dbo.Attends");
            DropTable("dbo.Rates");
            DropTable("dbo.Actual_Price_Time");
        }
    }
}

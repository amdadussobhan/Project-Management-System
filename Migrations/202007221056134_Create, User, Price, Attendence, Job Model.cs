namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserPriceAttendenceJobModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.DateTime(nullable: false),
                        Logout = c.DateTime(nullable: false),
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
                        JobTime = c.Single(nullable: false),
                        ProTime = c.Single(nullable: false),
                        InputAmount = c.Single(nullable: false),
                        OutputAmount = c.Single(nullable: false),
                        PriceTime_ID = c.Int(),
                        Receiver_ID = c.Int(),
                        Sender_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PriceTimes", t => t.PriceTime_ID)
                .ForeignKey("dbo.Users", t => t.Receiver_ID)
                .ForeignKey("dbo.Users", t => t.Sender_ID)
                .Index(t => t.PriceTime_ID)
                .Index(t => t.Receiver_ID)
                .Index(t => t.Sender_ID);
            
            CreateTable(
                "dbo.PriceTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Time = c.Single(nullable: false),
                        CP_Price = c.Single(nullable: false),
                        RET_Price = c.Single(nullable: false),
                        SHA_Price = c.Single(nullable: false),
                        MSK_Price = c.Single(nullable: false),
                        CC_Price = c.Single(nullable: false),
                        NJ_Price = c.Single(nullable: false),
                        LIQ_Price = c.Single(nullable: false),
                        CP_Time = c.Single(nullable: false),
                        RET_Time = c.Single(nullable: false),
                        SHA_Time = c.Single(nullable: false),
                        MSK_Time = c.Single(nullable: false),
                        CC_Time = c.Single(nullable: false),
                        NJ_Time = c.Single(nullable: false),
                        LIQ_Time = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Production_Log",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Start_Job = c.DateTime(nullable: false),
                        Finish_Job = c.DateTime(nullable: false),
                        Job_Time = c.Single(nullable: false),
                        Pro_Time = c.Single(nullable: false),
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
            DropForeignKey("dbo.Production_Log", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Production_Log", "Job_ID", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "Sender_ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "Receiver_ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "PriceTime_ID", "dbo.PriceTimes");
            DropForeignKey("dbo.Attendences", "User_ID", "dbo.Users");
            DropIndex("dbo.Production_Log", new[] { "User_ID" });
            DropIndex("dbo.Production_Log", new[] { "Job_ID" });
            DropIndex("dbo.Jobs", new[] { "Sender_ID" });
            DropIndex("dbo.Jobs", new[] { "Receiver_ID" });
            DropIndex("dbo.Jobs", new[] { "PriceTime_ID" });
            DropIndex("dbo.Attendences", new[] { "User_ID" });
            DropTable("dbo.Production_Log");
            DropTable("dbo.PriceTimes");
            DropTable("dbo.Jobs");
            DropTable("dbo.Users");
            DropTable("dbo.Attendences");
        }
    }
}

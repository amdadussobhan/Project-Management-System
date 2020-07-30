namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDatabasesetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attends",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User_ID = c.Int(nullable: false),
                        Attend_Date = c.DateTime(nullable: false),
                        Login = c.DateTime(nullable: false),
                        Logout = c.DateTime(nullable: false),
                        Status = c.String(),
                        Workingtime = c.Int(nullable: false),
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
                        Date = c.DateTime(nullable: false),
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
                        Receiver_ID = c.Int(nullable: false),
                        Sender_ID = c.Int(nullable: false),
                        SI_ID = c.Int(nullable: false),
                        QC_ID = c.Int(nullable: false),
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
                        Price_Times_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User_ID = c.Int(nullable: false),
                        Job_ID = c.Int(nullable: false),
                        Status = c.String(),
                        Start_Job = c.DateTime(nullable: false),
                        Finish_Job = c.DateTime(nullable: false),
                        Job_Time = c.Double(nullable: false),
                        Pro_Time = c.Double(nullable: false),
                        Service = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Price_Time",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Client = c.String(),
                        Category = c.String(),
                        Actual_Time = c.Double(nullable: false),
                        Target_Time = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Taka = c.Double(nullable: false),
                        Rate_ID = c.Int(nullable: false),
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
                "dbo.Rates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Currency = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Rates");
            DropTable("dbo.Price_Time");
            DropTable("dbo.Logs");
            DropTable("dbo.Jobs");
            DropTable("dbo.Attends");
        }
    }
}

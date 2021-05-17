namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationallModelField : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        JobId = c.String(),
                        Service = c.String(),
                        Amount = c.Int(nullable: false),
                        Status = c.String(),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        JobTime = c.Double(nullable: false),
                        ProTime = c.Double(nullable: false),
                        TotalJobTime = c.Double(nullable: false),
                        TotalProTime = c.Double(nullable: false),
                        Efficiency = c.Int(nullable: false),
                        Quality = c.Int(nullable: false),
                        Up = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.String(),
                        Client = c.String(),
                        Folder = c.String(),
                        Category = c.String(),
                        Service = c.String(),
                        Status = c.String(),
                        Type = c.String(),
                        Format = c.String(),
                        Date = c.DateTime(nullable: false),
                        Incoming = c.DateTime(nullable: false),
                        Delivery = c.DateTime(nullable: false),
                        InputAmount = c.Int(nullable: false),
                        ProDone = c.Int(nullable: false),
                        OutputAmount = c.Int(nullable: false),
                        InputLocation = c.String(),
                        WorkingLocation = c.String(),
                        OutputLocation = c.String(),
                        Price = c.Double(nullable: false),
                        Taka = c.Double(nullable: false),
                        Currency = c.String(),
                        ActualTime = c.Double(nullable: false),
                        TargetTime = c.Double(nullable: false),
                        ProTime = c.Double(nullable: false),
                        QcTime = c.Double(nullable: false),
                        ActualEfficiency = c.Int(nullable: false),
                        TargetEfficiency = c.Int(nullable: false),
                        Receiver = c.String(),
                        Sender = c.String(),
                        SiName = c.String(),
                        QcName = c.String(),
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
                        Up = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Logs", "JobId", c => c.String());
            AddColumn("dbo.Logs", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Logs", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Logs", "ActualTime", c => c.Double(nullable: false));
            AddColumn("dbo.Logs", "TargetTime", c => c.Double(nullable: false));
            AddColumn("dbo.Logs", "ProTime", c => c.Double(nullable: false));
            AddColumn("dbo.Logs", "InputLocation", c => c.String());
            AddColumn("dbo.Logs", "WorkingLocation", c => c.String());
            AddColumn("dbo.Logs", "OutputLocation", c => c.String());
            AddColumn("dbo.Logs", "Up", c => c.Int(nullable: false));
            AddColumn("dbo.Performances", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Performances", "File", c => c.Int(nullable: false));
            AddColumn("dbo.Performances", "JobTime", c => c.Double(nullable: false));
            AddColumn("dbo.Performances", "ProTime", c => c.Double(nullable: false));
            AddColumn("dbo.Performances", "Up", c => c.Int(nullable: false));
            AddColumn("dbo.ShiftReports", "AchieveLoad", c => c.Double(nullable: false));
            AddColumn("dbo.ShiftReports", "AchieveProTime", c => c.Double(nullable: false));
            AddColumn("dbo.ShiftReports", "TargetAchieve", c => c.Int(nullable: false));
            AddColumn("dbo.ShiftReports", "Up", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UP", c => c.Int(nullable: false));
            AddColumn("dbo.Workloads", "JobId", c => c.String());
            AddColumn("dbo.Workloads", "Up", c => c.Int(nullable: false));
            DropColumn("dbo.Logs", "Job_ID");
            DropColumn("dbo.Logs", "Start_Time");
            DropColumn("dbo.Logs", "End_Time");
            DropColumn("dbo.Logs", "Actual_Time");
            DropColumn("dbo.Logs", "Target_Time");
            DropColumn("dbo.Logs", "Pro_Time");
            DropColumn("dbo.Logs", "Input_Location");
            DropColumn("dbo.Logs", "Working_Location");
            DropColumn("dbo.Logs", "Output_Location");
            DropColumn("dbo.Performances", "Attend_Date");
            DropColumn("dbo.Performances", "Amount");
            DropColumn("dbo.Performances", "Job_Time");
            DropColumn("dbo.Performances", "Pro_Time");
            DropColumn("dbo.ShiftReports", "AchiveLoad");
            DropColumn("dbo.ShiftReports", "AchiveProTime");
            DropColumn("dbo.ShiftReports", "TargetAchive");
            DropColumn("dbo.Workloads", "Job_ID");
            DropTable("dbo.My_Job");
            DropTable("dbo.New_Job");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.New_Job",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Job_ID = c.String(),
                        Client = c.String(),
                        Folder = c.String(),
                        Category = c.String(),
                        Service = c.String(),
                        Status = c.String(),
                        Type = c.String(),
                        Format = c.String(),
                        Date = c.DateTime(nullable: false),
                        Incoming = c.DateTime(nullable: false),
                        Delivery = c.DateTime(nullable: false),
                        InputAmount = c.Int(nullable: false),
                        Pro_Done = c.Int(nullable: false),
                        OutputAmount = c.Int(nullable: false),
                        InputLocation = c.String(),
                        WorkingLocation = c.String(),
                        OutputLocation = c.String(),
                        Price = c.Double(nullable: false),
                        Taka = c.Double(nullable: false),
                        Currency = c.String(),
                        Actual_Time = c.Double(nullable: false),
                        Target_Time = c.Double(nullable: false),
                        Pro_Time = c.Double(nullable: false),
                        QC_Time = c.Double(nullable: false),
                        Actual_Efficiency = c.Int(nullable: false),
                        Target_Efficiency = c.Int(nullable: false),
                        Receiver = c.String(),
                        Sender = c.String(),
                        SI_Name = c.String(),
                        QC_Name = c.String(),
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
                "dbo.My_Job",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Job_ID = c.String(),
                        Service = c.String(),
                        Amount = c.Int(nullable: false),
                        Status = c.String(),
                        Date = c.DateTime(nullable: false),
                        Start_Time = c.DateTime(nullable: false),
                        End_Time = c.DateTime(nullable: false),
                        Job_Time = c.Double(nullable: false),
                        Pro_Time = c.Double(nullable: false),
                        Total_Job_Time = c.Double(nullable: false),
                        Total_Pro_Time = c.Double(nullable: false),
                        Efficiency = c.Int(nullable: false),
                        Quality = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Workloads", "Job_ID", c => c.String());
            AddColumn("dbo.ShiftReports", "TargetAchive", c => c.Int(nullable: false));
            AddColumn("dbo.ShiftReports", "AchiveProTime", c => c.Double(nullable: false));
            AddColumn("dbo.ShiftReports", "AchiveLoad", c => c.Double(nullable: false));
            AddColumn("dbo.Performances", "Pro_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Performances", "Job_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Performances", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Performances", "Attend_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Logs", "Output_Location", c => c.String());
            AddColumn("dbo.Logs", "Working_Location", c => c.String());
            AddColumn("dbo.Logs", "Input_Location", c => c.String());
            AddColumn("dbo.Logs", "Pro_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Logs", "Target_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Logs", "Actual_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Logs", "End_Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Logs", "Start_Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Logs", "Job_ID", c => c.String());
            DropColumn("dbo.Workloads", "Up");
            DropColumn("dbo.Workloads", "JobId");
            DropColumn("dbo.Users", "UP");
            DropColumn("dbo.ShiftReports", "Up");
            DropColumn("dbo.ShiftReports", "TargetAchieve");
            DropColumn("dbo.ShiftReports", "AchieveProTime");
            DropColumn("dbo.ShiftReports", "AchieveLoad");
            DropColumn("dbo.Performances", "Up");
            DropColumn("dbo.Performances", "ProTime");
            DropColumn("dbo.Performances", "JobTime");
            DropColumn("dbo.Performances", "File");
            DropColumn("dbo.Performances", "Date");
            DropColumn("dbo.Logs", "Up");
            DropColumn("dbo.Logs", "OutputLocation");
            DropColumn("dbo.Logs", "WorkingLocation");
            DropColumn("dbo.Logs", "InputLocation");
            DropColumn("dbo.Logs", "ProTime");
            DropColumn("dbo.Logs", "TargetTime");
            DropColumn("dbo.Logs", "ActualTime");
            DropColumn("dbo.Logs", "EndTime");
            DropColumn("dbo.Logs", "StartTime");
            DropColumn("dbo.Logs", "JobId");
            DropTable("dbo.NewJobs");
            DropTable("dbo.MyJobs");
        }
    }
}

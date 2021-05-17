namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedworkload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workloads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Job_ID = c.String(),
                        Date = c.DateTime(nullable: false),
                        Shift = c.String(),
                        File = c.Int(nullable: false),
                        Time = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ShiftReports", "TotalLoad", c => c.Double(nullable: false));
            AlterColumn("dbo.New_Job", "InputAmount", c => c.Int(nullable: false));
            AlterColumn("dbo.New_Job", "Pro_Done", c => c.Int(nullable: false));
            AlterColumn("dbo.New_Job", "OutputAmount", c => c.Int(nullable: false));
            DropColumn("dbo.ShiftReports", "WorkLoad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShiftReports", "WorkLoad", c => c.Double(nullable: false));
            AlterColumn("dbo.New_Job", "OutputAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.New_Job", "Pro_Done", c => c.Double(nullable: false));
            AlterColumn("dbo.New_Job", "InputAmount", c => c.Double(nullable: false));
            DropColumn("dbo.ShiftReports", "TotalLoad");
            DropTable("dbo.Workloads");
        }
    }
}

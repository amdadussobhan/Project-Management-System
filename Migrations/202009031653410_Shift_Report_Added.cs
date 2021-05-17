namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shift_Report_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShiftReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Shift = c.String(),
                        Date = c.DateTime(nullable: false),
                        Capacity = c.Double(nullable: false),
                        PreLoad = c.Double(nullable: false),
                        WorkLoad = c.Double(nullable: false),
                        AchiveLoad = c.Double(nullable: false),
                        AchiveProTime = c.Double(nullable: false),
                        HandLoad = c.Double(nullable: false),
                        PreFile = c.Int(nullable: false),
                        TotalFile = c.Int(nullable: false),
                        HandFile = c.Int(nullable: false),
                        ProDone = c.Int(nullable: false),
                        QcDone = c.Int(nullable: false),
                        Quality = c.Int(nullable: false),
                        TargetAchive = c.Int(nullable: false),
                        Efficiency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShiftReports");
        }
    }
}

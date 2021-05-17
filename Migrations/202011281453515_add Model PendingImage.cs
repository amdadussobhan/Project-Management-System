namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModelPendingImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobId = c.String(),
                        Category = c.String(),
                        Image = c.String(),
                        Actual_Time = c.Double(nullable: false),
                        Target_Time = c.Double(nullable: false),
                        CP_Time = c.Double(nullable: false),
                        RET_Time = c.Double(nullable: false),
                        SHA_Time = c.Double(nullable: false),
                        MSK_Time = c.Double(nullable: false),
                        CC_Time = c.Double(nullable: false),
                        NJ_Time = c.Double(nullable: false),
                        LIQ_Time = c.Double(nullable: false),
                        AI_Time = c.Double(nullable: false),
                        QC_Time = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PendingImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobId = c.String(),
                        Image = c.String(),
                        Name = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Logs", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Category");
            DropTable("dbo.PendingImages");
            DropTable("dbo.ImageTimes");
        }
    }
}

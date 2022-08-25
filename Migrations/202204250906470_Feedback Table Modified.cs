namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackTableModified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Reporter = c.String(),
                        JobId = c.String(),
                        Folder = c.String(),
                        ReportTime = c.DateTime(nullable: false),
                        Image = c.String(),
                        Remarks = c.String(),
                        Location = c.String(),
                        Up = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}

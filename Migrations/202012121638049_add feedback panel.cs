namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfeedbackpanel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Redo_Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.String(),
                        RedoJobId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Logs", "Shift", c => c.String());
            AddColumn("dbo.NewJobs", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewJobs", "Remarks");
            DropColumn("dbo.Logs", "Shift");
            DropTable("dbo.Redo_Job");
        }
    }
}

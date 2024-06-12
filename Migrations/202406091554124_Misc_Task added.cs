namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Misc_Taskadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Misc_Task",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Reason = c.String(),
                        Type = c.String(),
                        Status = c.String(),
                        Time = c.Double(nullable: false),
                        Apply_Time = c.DateTime(nullable: false),
                        Start_Time = c.DateTime(nullable: false),
                        End_Time = c.DateTime(nullable: false),
                        SI_Status = c.Boolean(nullable: false),
                        Up = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Misc_Task");
        }
    }
}

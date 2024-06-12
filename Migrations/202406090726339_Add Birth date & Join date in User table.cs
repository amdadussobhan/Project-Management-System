namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateJoindateinUsertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Reason = c.String(),
                        Type = c.String(),
                        Status = c.String(),
                        Apply_Date = c.DateTime(nullable: false),
                        Leave_Date = c.DateTime(nullable: false),
                        SI_Status = c.Boolean(nullable: false),
                        PM_Status = c.Boolean(nullable: false),
                        HR_Status = c.Boolean(nullable: false),
                        Up = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Leaves");
        }
    }
}

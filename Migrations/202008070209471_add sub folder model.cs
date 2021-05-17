namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsubfoldermodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sub_Folder",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Job_ID = c.String(),
                        Path = c.String(),
                        New_Name = c.String(),
                        Old_Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sub_Folder");
        }
    }
}

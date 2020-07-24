namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerelationofattendenceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendences", "User_ID", c => c.Int());
            CreateIndex("dbo.Attendences", "User_ID");
            AddForeignKey("dbo.Attendences", "User_ID", "dbo.Users", "ID");
            DropColumn("dbo.Attendences", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendences", "User", c => c.Int(nullable: false));
            DropForeignKey("dbo.Attendences", "User_ID", "dbo.Users");
            DropIndex("dbo.Attendences", new[] { "User_ID" });
            DropColumn("dbo.Attendences", "User_ID");
        }
    }
}

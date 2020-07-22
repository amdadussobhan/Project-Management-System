namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDatetoattendenceModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendences", "User_ID", "dbo.Users");
            DropIndex("dbo.Attendences", new[] { "User_ID" });
            AddColumn("dbo.Attendences", "User", c => c.Int(nullable: false));
            AddColumn("dbo.Attendences", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Attendences", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendences", "User_ID", c => c.Int());
            DropColumn("dbo.Attendences", "Date");
            DropColumn("dbo.Attendences", "User");
            CreateIndex("dbo.Attendences", "User_ID");
            AddForeignKey("dbo.Attendences", "User_ID", "dbo.Users", "ID");
        }
    }
}

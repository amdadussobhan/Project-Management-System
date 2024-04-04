namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedautotimeassign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageTimes", "IsFixed", c => c.Boolean(nullable: false));
            AddColumn("dbo.ImageTimes", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.ImageTimes", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.NewJobs", "ScriptAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewJobs", "ScriptAmount");
            DropColumn("dbo.ImageTimes", "Updated");
            DropColumn("dbo.ImageTimes", "Created");
            DropColumn("dbo.ImageTimes", "IsFixed");
        }
    }
}

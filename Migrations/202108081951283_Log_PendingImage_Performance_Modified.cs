namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Log_PendingImage_Performance_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "RestTime", c => c.Double(nullable: false));
            AddColumn("dbo.Logs", "PauseTime", c => c.Double(nullable: false));
            AddColumn("dbo.PendingImages", "Status", c => c.String());
            AddColumn("dbo.Performances", "PC_Name", c => c.String());
            AddColumn("dbo.Sub_Folder", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sub_Folder", "Time");
            DropColumn("dbo.Performances", "PC_Name");
            DropColumn("dbo.PendingImages", "Status");
            DropColumn("dbo.Logs", "PauseTime");
            DropColumn("dbo.Logs", "RestTime");
        }
    }
}

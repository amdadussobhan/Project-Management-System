namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageTime_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageTimes", "Team", c => c.String());
            AddColumn("dbo.ImageTimes", "Total_Time", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImageTimes", "Total_Time");
            DropColumn("dbo.ImageTimes", "Team");
        }
    }
}

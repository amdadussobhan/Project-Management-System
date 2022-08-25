namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeteamfromimageTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Assign_Time", "Category");
            DropColumn("dbo.ImageTimes", "Team");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageTimes", "Team", c => c.String());
            AddColumn("dbo.Assign_Time", "Category", c => c.String());
        }
    }
}

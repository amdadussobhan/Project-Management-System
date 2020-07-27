namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytimefiledinjobsmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Pro_Done", c => c.Double(nullable: false));
            AddColumn("dbo.Pro_Time_Price", "Target_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Pro_Time_Price", "Pro_Time", c => c.Double(nullable: false));
            DropColumn("dbo.Pro_Time_Price", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pro_Time_Price", "Time", c => c.Double(nullable: false));
            DropColumn("dbo.Pro_Time_Price", "Pro_Time");
            DropColumn("dbo.Pro_Time_Price", "Target_Time");
            DropColumn("dbo.Jobs", "Pro_Done");
        }
    }
}

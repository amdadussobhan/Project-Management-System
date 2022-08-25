namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removetotaltime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Assign_Time", "Total_Time");
            DropColumn("dbo.Assign_Time", "QC_Time");
            DropColumn("dbo.ImageTimes", "QC_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageTimes", "QC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Assign_Time", "QC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Assign_Time", "Total_Time", c => c.Double(nullable: false));
        }
    }
}

namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctionperfomane : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.My_Job", "Total_Job_Time", c => c.Double(nullable: false));
            AddColumn("dbo.My_Job", "Total_Pro_Time", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.My_Job", "Total_Pro_Time");
            DropColumn("dbo.My_Job", "Total_Job_Time");
        }
    }
}

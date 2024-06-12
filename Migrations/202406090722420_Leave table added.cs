namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Leavetableadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewJobs", "Medean", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "Mode", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "Max", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "Min", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "Blood", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "Grade", c => c.String());
            AddColumn("dbo.Users", "Birth_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Join_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Join_Date");
            DropColumn("dbo.Users", "Birth_Date");
            DropColumn("dbo.Users", "Grade");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Blood");
            DropColumn("dbo.NewJobs", "Min");
            DropColumn("dbo.NewJobs", "Max");
            DropColumn("dbo.NewJobs", "Mode");
            DropColumn("dbo.NewJobs", "Medean");
        }
    }
}

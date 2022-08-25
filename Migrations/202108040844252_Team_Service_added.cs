namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Team_Service_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workloads", "Team", c => c.String());
            AddColumn("dbo.Workloads", "Service", c => c.String());
            AddColumn("dbo.Workloads", "Output", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workloads", "Output");
            DropColumn("dbo.Workloads", "Service");
            DropColumn("dbo.Workloads", "Team");
        }
    }
}

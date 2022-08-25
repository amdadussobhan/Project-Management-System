namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modified_Workload : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Workloads", "Created");
            DropColumn("dbo.Workloads", "Updated");
            DropColumn("dbo.Workloads", "Creator");
            DropColumn("dbo.Workloads", "Updator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workloads", "Updator", c => c.String());
            AddColumn("dbo.Workloads", "Creator", c => c.String());
            AddColumn("dbo.Workloads", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Workloads", "Created", c => c.DateTime(nullable: false));
        }
    }
}

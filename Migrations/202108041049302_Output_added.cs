namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Output_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workloads", "Output_File", c => c.Int(nullable: false));
            DropColumn("dbo.Workloads", "Output");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workloads", "Output", c => c.Int(nullable: false));
            DropColumn("dbo.Workloads", "Output_File");
        }
    }
}

namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_QC_in_NewJobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewJobs", "QC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.NewJobs", "QC_Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewJobs", "QC_Price");
            DropColumn("dbo.NewJobs", "QC_Time");
        }
    }
}

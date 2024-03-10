namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceaddedinAssignTimeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assign_Time", "Service", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assign_Time", "Service");
        }
    }
}

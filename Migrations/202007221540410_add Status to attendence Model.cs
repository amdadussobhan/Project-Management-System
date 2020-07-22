namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatustoattendenceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendences", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendences", "Status");
        }
    }
}

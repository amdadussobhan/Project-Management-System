namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDatefieldattendencejobModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendences", "Attend_Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Attendences", "Date");
            DropColumn("dbo.Jobs", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attendences", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Attendences", "Attend_Date");
        }
    }
}

namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlocationandremarksfieldinlogmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Remarks", c => c.String());
            AddColumn("dbo.Logs", "Input_Location", c => c.String());
            AddColumn("dbo.Logs", "Working_Location", c => c.String());
            AddColumn("dbo.Logs", "Output_Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Output_Location");
            DropColumn("dbo.Logs", "Working_Location");
            DropColumn("dbo.Logs", "Input_Location");
            DropColumn("dbo.Logs", "Remarks");
        }
    }
}

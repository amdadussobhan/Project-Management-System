namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsupportandrevenue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Support", c => c.Double(nullable: false));
            AddColumn("dbo.Logs", "Revenue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Revenue");
            DropColumn("dbo.Logs", "Support");
        }
    }
}

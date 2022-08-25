namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrevenueandsupport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Performances", "Support", c => c.Double(nullable: false));
            AddColumn("dbo.Performances", "Revenue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Performances", "Revenue");
            DropColumn("dbo.Performances", "Support");
        }
    }
}

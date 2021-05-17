namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addformatinpricemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Price_Time", "Format", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Price_Time", "Format");
        }
    }
}

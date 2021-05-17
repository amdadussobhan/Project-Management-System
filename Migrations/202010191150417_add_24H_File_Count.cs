namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_24H_File_Count : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShiftReports", "NewFile", c => c.Int(nullable: false));
            AddColumn("dbo.ShiftReports", "Last24Input", c => c.Int(nullable: false));
            AddColumn("dbo.ShiftReports", "Last24Output", c => c.Int(nullable: false));
            AddColumn("dbo.ShiftReports", "Revenue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShiftReports", "Revenue");
            DropColumn("dbo.ShiftReports", "Last24Output");
            DropColumn("dbo.ShiftReports", "Last24Input");
            DropColumn("dbo.ShiftReports", "NewFile");
        }
    }
}

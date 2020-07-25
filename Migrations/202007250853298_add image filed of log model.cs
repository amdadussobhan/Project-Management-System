namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimagefiledoflogmodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Jobs", name: "Price_ID", newName: "Actual_Time_Price_ID");
            RenameColumn(table: "dbo.Jobs", name: "Time_ID", newName: "Pro_Time_Price_ID");
            RenameIndex(table: "dbo.Jobs", name: "IX_Price_ID", newName: "IX_Actual_Time_Price_ID");
            RenameIndex(table: "dbo.Jobs", name: "IX_Time_ID", newName: "IX_Pro_Time_Price_ID");
            AddColumn("dbo.Logs", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Image");
            RenameIndex(table: "dbo.Jobs", name: "IX_Pro_Time_Price_ID", newName: "IX_Time_ID");
            RenameIndex(table: "dbo.Jobs", name: "IX_Actual_Time_Price_ID", newName: "IX_Price_ID");
            RenameColumn(table: "dbo.Jobs", name: "Pro_Time_Price_ID", newName: "Time_ID");
            RenameColumn(table: "dbo.Jobs", name: "Actual_Time_Price_ID", newName: "Price_ID");
        }
    }
}

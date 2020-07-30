namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHRPanelandProductionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Job_ID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Service = c.String(),
                        Job_Time = c.Double(nullable: false),
                        Pro_Time = c.Double(nullable: false),
                        Efficiency = c.Int(nullable: false),
                        Quality = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Attends", "Shift", c => c.String());
            AddColumn("dbo.Attends", "Name", c => c.String());
            AddColumn("dbo.Attends", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Attends", "Job_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Attends", "Pro_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Attends", "Efficiency", c => c.Int(nullable: false));
            AddColumn("dbo.Attends", "Quality", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attends", "Quality");
            DropColumn("dbo.Attends", "Efficiency");
            DropColumn("dbo.Attends", "Pro_Time");
            DropColumn("dbo.Attends", "Job_Time");
            DropColumn("dbo.Attends", "Amount");
            DropColumn("dbo.Attends", "Name");
            DropColumn("dbo.Attends", "Shift");
            DropTable("dbo.Productions");
        }
    }
}

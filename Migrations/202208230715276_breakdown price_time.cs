namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class breakdownprice_time : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assign_Time",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Client = c.String(),
                        Category = c.String(),
                        Type = c.String(),
                        Format = c.String(),
                        Clipping_Time = c.Double(nullable: false),
                        Basic_Time = c.Double(nullable: false),
                        Pre_Process = c.Double(nullable: false),
                        Post_Process = c.Double(nullable: false),
                        QC_Time = c.Double(nullable: false),
                        Up = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ImageTimes", "Assigner", c => c.String());
            DropColumn("dbo.Logs", "Team");
            DropColumn("dbo.Price_Time", "Service");
            DropColumn("dbo.Price_Time", "Format");
            DropColumn("dbo.Price_Time", "Target_Time");
            DropColumn("dbo.Price_Time", "Clipping_Time");
            DropColumn("dbo.Price_Time", "Basic_Time");
            DropColumn("dbo.Price_Time", "Pre_Process");
            DropColumn("dbo.Price_Time", "Post_Process");
            DropColumn("dbo.Price_Time", "QC_Time");
            DropTable("dbo.Redo_Job");
            DropTable("dbo.Running_Jobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Running_Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.String(),
                        Team = c.String(),
                        Shift = c.String(),
                        Service = c.String(),
                        Location = c.String(),
                        Type = c.String(),
                        Date = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Creator = c.String(),
                        Updator = c.String(),
                        Input_File = c.Int(nullable: false),
                        Output_File = c.Int(nullable: false),
                        Target_Time = c.Double(nullable: false),
                        Total_Time = c.Double(nullable: false),
                        Pro_Time = c.Double(nullable: false),
                        QC_Time = c.Double(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        Up = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Redo_Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.String(),
                        RedoJobId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Price_Time", "QC_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Post_Process", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Pre_Process", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Basic_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Clipping_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Target_Time", c => c.Double(nullable: false));
            AddColumn("dbo.Price_Time", "Format", c => c.String());
            AddColumn("dbo.Price_Time", "Service", c => c.String());
            AddColumn("dbo.Logs", "Team", c => c.String());
            DropColumn("dbo.ImageTimes", "Assigner");
            DropTable("dbo.Assign_Time");
        }
    }
}

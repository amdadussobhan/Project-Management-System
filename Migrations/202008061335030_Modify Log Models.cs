namespace Skill_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyLogModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Name", c => c.String());
            AddColumn("dbo.My_Job", "Name", c => c.String());
            AddColumn("dbo.New_Job", "Job_ID", c => c.String());
            AddColumn("dbo.New_Job", "Receiver", c => c.String());
            AddColumn("dbo.New_Job", "Sender", c => c.String());
            AddColumn("dbo.New_Job", "SI_Name", c => c.String());
            AddColumn("dbo.New_Job", "QC_Name", c => c.String());
            AlterColumn("dbo.Logs", "Job_ID", c => c.String());
            AlterColumn("dbo.My_Job", "Job_ID", c => c.String());
            DropColumn("dbo.Logs", "User_ID");
            DropColumn("dbo.My_Job", "User_ID");
            DropColumn("dbo.New_Job", "JobID");
            DropColumn("dbo.New_Job", "Receiver_ID");
            DropColumn("dbo.New_Job", "Sender_ID");
            DropColumn("dbo.New_Job", "SI_ID");
            DropColumn("dbo.New_Job", "QC_ID");
            DropColumn("dbo.Performances", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Performances", "User_ID", c => c.Int(nullable: false));
            AddColumn("dbo.New_Job", "QC_ID", c => c.Int(nullable: false));
            AddColumn("dbo.New_Job", "SI_ID", c => c.Int(nullable: false));
            AddColumn("dbo.New_Job", "Sender_ID", c => c.Int(nullable: false));
            AddColumn("dbo.New_Job", "Receiver_ID", c => c.Int(nullable: false));
            AddColumn("dbo.New_Job", "JobID", c => c.String());
            AddColumn("dbo.My_Job", "User_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Logs", "User_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.My_Job", "Job_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Logs", "Job_ID", c => c.Int(nullable: false));
            DropColumn("dbo.New_Job", "QC_Name");
            DropColumn("dbo.New_Job", "SI_Name");
            DropColumn("dbo.New_Job", "Sender");
            DropColumn("dbo.New_Job", "Receiver");
            DropColumn("dbo.New_Job", "Job_ID");
            DropColumn("dbo.My_Job", "Name");
            DropColumn("dbo.Logs", "Name");
        }
    }
}

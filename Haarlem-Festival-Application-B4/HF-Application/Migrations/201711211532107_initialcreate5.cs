namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PagePassPartouts", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.PagePassPartouts", "EventId");
            AddForeignKey("dbo.PagePassPartouts", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PagePassPartouts", "EventId", "dbo.Events");
            DropIndex("dbo.PagePassPartouts", new[] { "EventId" });
            DropColumn("dbo.PagePassPartouts", "EventId");
        }
    }
}

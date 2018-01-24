namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FestivalEvents", "Seats", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FestivalEvents", "Seats");
        }
    }
}

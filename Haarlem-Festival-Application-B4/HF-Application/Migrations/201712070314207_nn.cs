namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FestivalEvents", "TicketPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Locations", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.FestivalEvents", "TicketPrice");
        }
    }
}

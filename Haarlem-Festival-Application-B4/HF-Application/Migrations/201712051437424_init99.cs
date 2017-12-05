namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init99 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FestivalEvents", "Price");
            DropColumn("dbo.FestivalEvents", "Seats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FestivalEvents", "Seats", c => c.Int(nullable: false));
            AddColumn("dbo.FestivalEvents", "Price", c => c.Double(nullable: false));
        }
    }
}

namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bla : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Historic", "TourLanguage", c => c.String());
            AddColumn("dbo.Locations", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.FestivalEvents", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FestivalEvents", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Locations", "Price");
            DropColumn("dbo.Historic", "TourLanguage");
        }
    }
}

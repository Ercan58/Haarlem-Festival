namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini00 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FestivalEvents", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FestivalEvents", "LocationId", c => c.Int(nullable: false));
        }
    }
}

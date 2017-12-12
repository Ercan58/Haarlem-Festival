namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FestivalEvents", "LocationId", "dbo.Locations");
            DropIndex("dbo.FestivalEvents", new[] { "LocationId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.FestivalEvents", "LocationId");
            AddForeignKey("dbo.FestivalEvents", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}

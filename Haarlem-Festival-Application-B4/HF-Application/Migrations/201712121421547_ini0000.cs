namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini0000 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Historic", "Location_Id", c => c.Int());
            AddColumn("dbo.Jazz", "Location_Id", c => c.Int());
            AddColumn("dbo.Restaurants", "Location_Id", c => c.Int());
            CreateIndex("dbo.Restaurants", "Location_Id");
            CreateIndex("dbo.Historic", "Location_Id");
            CreateIndex("dbo.Jazz", "Location_Id");
            AddForeignKey("dbo.Restaurants", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.Historic", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.Jazz", "Location_Id", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jazz", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Historic", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Restaurants", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Jazz", new[] { "Location_Id" });
            DropIndex("dbo.Historic", new[] { "Location_Id" });
            DropIndex("dbo.Restaurants", new[] { "Location_Id" });
            DropColumn("dbo.Restaurants", "Location_Id");
            DropColumn("dbo.Jazz", "Location_Id");
            DropColumn("dbo.Historic", "Location_Id");
        }
    }
}

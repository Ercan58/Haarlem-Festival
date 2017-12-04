namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diner", "RestaurantId", c => c.Int(nullable: false));
            CreateIndex("dbo.Diner", "RestaurantId");
            AddForeignKey("dbo.Diner", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diner", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Diner", new[] { "RestaurantId" });
            DropColumn("dbo.Diner", "RestaurantId");
        }
    }
}

namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodTypes", "restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.FoodTypes", new[] { "restaurant_Id" });
            DropColumn("dbo.FoodTypes", "restaurant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodTypes", "restaurant_Id", c => c.Int());
            CreateIndex("dbo.FoodTypes", "restaurant_Id");
            AddForeignKey("dbo.FoodTypes", "restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}

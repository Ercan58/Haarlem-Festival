namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantFoodtypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestauranttId = c.Int(nullable: false),
                        FoodtypeId = c.Int(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodTypes", t => t.FoodtypeId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.FoodtypeId)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.FoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantFoodtypes", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantFoodtypes", "FoodtypeId", "dbo.FoodTypes");
            DropIndex("dbo.RestaurantFoodtypes", new[] { "Restaurant_Id" });
            DropIndex("dbo.RestaurantFoodtypes", new[] { "FoodtypeId" });
            DropTable("dbo.FoodTypes");
            DropTable("dbo.RestaurantFoodtypes");
        }
    }
}

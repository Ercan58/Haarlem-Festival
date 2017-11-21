namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        CartDescription = c.String(),
                        CartTitle = c.String(),
                        Price = c.Int(nullable: false),
                        Seats = c.Int(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FamilyPrice = c.Int(),
                        ReservationInfo = c.String(),
                        Band = c.String(),
                        Session = c.Int(),
                        RestaurantName = c.String(),
                        FoodType = c.Int(),
                        Interview = c.String(),
                        ReservationInfo1 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Zipcode = c.String(),
                        Remarks = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Hall = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Remark = c.String(),
                        Invoice = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderPayed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderItems", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ItemId", "dbo.OrderItems");
            DropForeignKey("dbo.OrderItems", "ItemId", "dbo.Events");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropIndex("dbo.Orders", new[] { "ItemId" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropIndex("dbo.OrderItems", new[] { "ItemId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Locations");
            DropTable("dbo.Events");
            DropTable("dbo.OrderItems");
        }
    }
}

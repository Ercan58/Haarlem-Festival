namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FestivalEvents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        CartDescription = c.String(),
                        CartTitle = c.String(),
                        Price = c.Double(nullable: false),
                        Seats = c.Int(nullable: false),
                        TicketType = c.Int(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Price = c.Double(nullable: false),
                        Seats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Aantal = c.Int(nullable: false),
                        Prijs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FestivalEvents", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        statusId = c.Int(nullable: false),
                        Remark = c.String(),
                        Invoice = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderPayed = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Admin = c.Boolean(nullable: false),
                        Email = c.String(),
                        Mail = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Diner",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Session = c.Int(nullable: false),
                        imagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FestivalEvents", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Historic",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FamilyPrice = c.Int(nullable: false),
                        ReservationInfo = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FestivalEvents", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Jazz",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Band = c.String(),
                        imagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FestivalEvents", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Talk",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Interview = c.String(),
                        ReservationInfo = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FestivalEvents", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Talk", "ID", "dbo.FestivalEvents");
            DropForeignKey("dbo.Jazz", "ID", "dbo.FestivalEvents");
            DropForeignKey("dbo.Historic", "ID", "dbo.FestivalEvents");
            DropForeignKey("dbo.Diner", "ID", "dbo.FestivalEvents");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "ItemId", "dbo.FestivalEvents");
            DropForeignKey("dbo.FestivalEvents", "LocationId", "dbo.Locations");
            DropIndex("dbo.Talk", new[] { "ID" });
            DropIndex("dbo.Jazz", new[] { "ID" });
            DropIndex("dbo.Historic", new[] { "ID" });
            DropIndex("dbo.Diner", new[] { "ID" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "ItemId" });
            DropIndex("dbo.FestivalEvents", new[] { "LocationId" });
            DropTable("dbo.Talk");
            DropTable("dbo.Jazz");
            DropTable("dbo.Historic");
            DropTable("dbo.Diner");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Locations");
            DropTable("dbo.FestivalEvents");
        }
    }
}

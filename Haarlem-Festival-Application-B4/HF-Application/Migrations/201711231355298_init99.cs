namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init99 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        CartDescription = c.String(),
                        CartTitle = c.String(),
                        Price = c.Double(nullable: false),
                        Seats = c.Int(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        OrderrId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.ItemId, cascadeDelete: false)
                .ForeignKey("dbo.Orders", t => t.OrderrId, cascadeDelete: false)
                .Index(t => t.ItemId)
                .Index(t => t.OrderrId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Remark = c.String(),
                        Invoice = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderPayed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Mail = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ItemsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.OrderItems", t => t.ItemsId, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.ItemsId);
            
            CreateTable(
                "dbo.Diner",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Session = c.Int(nullable: false),
                        RestaurantName = c.String(),
                        FoodType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tickets", t => t.ID)
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
                .ForeignKey("dbo.Tickets", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Jazz",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Band = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tickets", t => t.ID)
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
                .ForeignKey("dbo.Tickets", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Talk", "ID", "dbo.Tickets");
            DropForeignKey("dbo.Jazz", "ID", "dbo.Tickets");
            DropForeignKey("dbo.Historic", "ID", "dbo.Tickets");
            DropForeignKey("dbo.Diner", "ID", "dbo.Tickets");
            DropForeignKey("dbo.WishLists", "ItemsId", "dbo.OrderItems");
            DropForeignKey("dbo.WishLists", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "OrderrId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "ItemId", "dbo.Tickets");
            DropIndex("dbo.Talk", new[] { "ID" });
            DropIndex("dbo.Jazz", new[] { "ID" });
            DropIndex("dbo.Historic", new[] { "ID" });
            DropIndex("dbo.Diner", new[] { "ID" });
            DropIndex("dbo.WishLists", new[] { "ItemsId" });
            DropIndex("dbo.WishLists", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderItems", new[] { "OrderrId" });
            DropIndex("dbo.OrderItems", new[] { "ItemId" });
            DropTable("dbo.Talk");
            DropTable("dbo.Jazz");
            DropTable("dbo.Historic");
            DropTable("dbo.Diner");
            DropTable("dbo.WishLists");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Tickets");
        }
    }
}

namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tickets", newName: "EventFestivals");
            DropForeignKey("dbo.WishLists", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.WishLists", "ItemsId", "dbo.OrderItems");
            DropIndex("dbo.WishLists", new[] { "CustomerId" });
            DropIndex("dbo.WishLists", new[] { "ItemsId" });
            RenameColumn(table: "dbo.OrderItems", name: "OrderrId", newName: "OrderId");
            RenameIndex(table: "dbo.OrderItems", name: "IX_OrderrId", newName: "IX_OrderId");
            AddColumn("dbo.EventFestivals", "TicketType", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "Aantal", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "Prijs", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "status", c => c.Int(nullable: false));
            DropTable("dbo.WishLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ItemsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Orders", "status");
            DropColumn("dbo.OrderItems", "Prijs");
            DropColumn("dbo.OrderItems", "Aantal");
            DropColumn("dbo.EventFestivals", "TicketType");
            RenameIndex(table: "dbo.OrderItems", name: "IX_OrderId", newName: "IX_OrderrId");
            RenameColumn(table: "dbo.OrderItems", name: "OrderId", newName: "OrderrId");
            CreateIndex("dbo.WishLists", "ItemsId");
            CreateIndex("dbo.WishLists", "CustomerId");
            AddForeignKey("dbo.WishLists", "ItemsId", "dbo.OrderItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WishLists", "CustomerId", "dbo.Users", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.EventFestivals", newName: "Tickets");
        }
    }
}

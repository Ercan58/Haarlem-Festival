namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EvenChoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ItemId");
            AddForeignKey("dbo.Orders", "ItemId", "dbo.OrderItems", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ItemId", "dbo.OrderItems");
            DropIndex("dbo.Orders", new[] { "ItemId" });
            DropColumn("dbo.Orders", "ItemId");
            DropTable("dbo.OrderItems");
        }
    }
}

namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WishLists", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.WishLists", "ItemId");
            AddForeignKey("dbo.WishLists", "ItemId", "dbo.OrderItems", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "ItemId", "dbo.OrderItems");
            DropIndex("dbo.WishLists", new[] { "ItemId" });
            DropColumn("dbo.WishLists", "ItemId");
        }
    }
}

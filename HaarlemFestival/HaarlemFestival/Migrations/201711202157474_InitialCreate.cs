namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        invoice = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderPayed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
        }
    }
}

namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PagePassPartouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PageEvents", "PassPartoutId");
            AddForeignKey("dbo.PageEvents", "PassPartoutId", "dbo.PagePassPartouts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageEvents", "PassPartoutId", "dbo.PagePassPartouts");
            DropIndex("dbo.PageEvents", new[] { "PassPartoutId" });
            DropTable("dbo.PagePassPartouts");
        }
    }
}

namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Historic", "tourLanguage_Id", c => c.Int());
            AddColumn("dbo.Historic", "TourGuide_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Historic", "Language_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Historic", "tourLanguage_Id");
            AddForeignKey("dbo.Historic", "tourLanguage_Id", "dbo.TourLanguages", "Id");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TourGuideLangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tourGuide_Id = c.Int(),
                        tourLanguage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Historic", "tourLanguage_Id", "dbo.TourLanguages");
            DropIndex("dbo.Historic", new[] { "tourLanguage_Id" });
            DropColumn("dbo.Historic", "Language_ID");
            DropColumn("dbo.Historic", "TourGuide_ID");
            DropColumn("dbo.Historic", "tourLanguage_Id");
        }
    }
}

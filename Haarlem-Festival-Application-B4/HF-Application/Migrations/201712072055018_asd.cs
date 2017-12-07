namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TourGuideLangs", "tourGuide_Id", "dbo.TourGuids");
            DropForeignKey("dbo.TourGuideLangs", "tourLanguage_Id", "dbo.TourLanguages");
            DropIndex("dbo.TourGuideLangs", new[] { "tourGuide_Id" });
            DropIndex("dbo.TourGuideLangs", new[] { "tourLanguage_Id" });
            AddColumn("dbo.Historic", "tourLanguage_Id", c => c.Int());
            AddColumn("dbo.Historic", "TourGuide_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Historic", "Language_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Historic", "tourLanguage_Id");
            AddForeignKey("dbo.Historic", "tourLanguage_Id", "dbo.TourLanguages", "Id");
            DropTable("dbo.TourGuideLangs");
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
            CreateIndex("dbo.TourGuideLangs", "tourLanguage_Id");
            CreateIndex("dbo.TourGuideLangs", "tourGuide_Id");
            AddForeignKey("dbo.TourGuideLangs", "tourLanguage_Id", "dbo.TourLanguages", "Id");
            AddForeignKey("dbo.TourGuideLangs", "tourGuide_Id", "dbo.TourGuids", "Id");
        }
    }
}
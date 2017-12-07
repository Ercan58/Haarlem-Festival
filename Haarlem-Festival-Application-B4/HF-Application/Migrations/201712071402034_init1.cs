namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TourGuids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuidName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TourGuideLangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tourGuide_Id = c.Int(),
                        tourLanguage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TourGuids", t => t.tourGuide_Id)
                .ForeignKey("dbo.TourLanguages", t => t.tourLanguage_Id)
                .Index(t => t.tourGuide_Id)
                .Index(t => t.tourLanguage_Id);
            
            CreateTable(
                "dbo.TourLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToursLanguage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FestivalEvents", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourGuideLangs", "tourLanguage_Id", "dbo.TourLanguages");
            DropForeignKey("dbo.TourGuideLangs", "tourGuide_Id", "dbo.TourGuids");
            DropIndex("dbo.TourGuideLangs", new[] { "tourLanguage_Id" });
            DropIndex("dbo.TourGuideLangs", new[] { "tourGuide_Id" });
            DropColumn("dbo.FestivalEvents", "Price");
            DropTable("dbo.TourLanguages");
            DropTable("dbo.TourGuideLangs");
            DropTable("dbo.TourGuids");
        }
    }
}

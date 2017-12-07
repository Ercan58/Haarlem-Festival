namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Historic", "tourLanguage_Id", "dbo.TourLanguages");
            DropIndex("dbo.Historic", new[] { "tourLanguage_Id" });
            AddColumn("dbo.TourGuids", "Language", c => c.String());
            DropColumn("dbo.Historic", "tourLanguage_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Historic", "tourLanguage_Id", c => c.Int());
            DropColumn("dbo.TourGuids", "Language");
            CreateIndex("dbo.Historic", "tourLanguage_Id");
            AddForeignKey("dbo.Historic", "tourLanguage_Id", "dbo.TourLanguages", "Id");
        }
    }
}

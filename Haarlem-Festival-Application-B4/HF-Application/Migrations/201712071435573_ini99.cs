namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini99 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Historic", "tourGuid_Id", c => c.Int());
            CreateIndex("dbo.Historic", "tourGuid_Id");
            AddForeignKey("dbo.Historic", "tourGuid_Id", "dbo.TourGuids", "Id");
            DropColumn("dbo.Historic", "GuidName");
            DropColumn("dbo.Historic", "TourLanguage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Historic", "TourLanguage", c => c.String());
            AddColumn("dbo.Historic", "GuidName", c => c.String());
            DropForeignKey("dbo.Historic", "tourGuid_Id", "dbo.TourGuids");
            DropIndex("dbo.Historic", new[] { "tourGuid_Id" });
            DropColumn("dbo.Historic", "tourGuid_Id");
        }
    }
}

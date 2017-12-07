namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini00 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Historic", "TourGuide_ID");
            DropColumn("dbo.Historic", "Language_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Historic", "Language_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Historic", "TourGuide_ID", c => c.Int(nullable: false));
        }
    }
}

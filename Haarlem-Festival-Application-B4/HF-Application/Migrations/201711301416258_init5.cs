namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventFestivals", newName: "FestivalEvents");
            AddColumn("dbo.Diner", "imagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diner", "imagePath");
            RenameTable(name: "dbo.FestivalEvents", newName: "EventFestivals");
        }
    }
}

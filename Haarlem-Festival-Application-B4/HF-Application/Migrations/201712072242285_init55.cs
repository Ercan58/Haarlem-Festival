namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init55 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FestivalEvents", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FestivalEvents", "Price", c => c.Double(nullable: false));
        }
    }
}

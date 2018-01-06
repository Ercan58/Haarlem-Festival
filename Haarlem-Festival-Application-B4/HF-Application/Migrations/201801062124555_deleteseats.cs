namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteseats : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "Seats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Seats", c => c.Int(nullable: false));
        }
    }
}

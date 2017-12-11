namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restaurantmodelupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "imagePath", c => c.String());
            DropColumn("dbo.Diner", "imagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Diner", "imagePath", c => c.String());
            DropColumn("dbo.Restaurants", "imagePath");
        }
    }
}

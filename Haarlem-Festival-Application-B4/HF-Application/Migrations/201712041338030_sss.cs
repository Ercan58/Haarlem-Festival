namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diner", "FoodType1", c => c.Int(nullable: false));
            AddColumn("dbo.Diner", "FoodType2", c => c.Int(nullable: false));
            AddColumn("dbo.Diner", "FoodType3", c => c.Int(nullable: false));
            DropColumn("dbo.Diner", "FoodType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Diner", "FoodType", c => c.Int(nullable: false));
            DropColumn("dbo.Diner", "FoodType3");
            DropColumn("dbo.Diner", "FoodType2");
            DropColumn("dbo.Diner", "FoodType1");
        }
    }
}

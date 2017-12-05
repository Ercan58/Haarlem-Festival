namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inits : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Diner", "ReducedPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Diner", "ReducedPrice", c => c.Int(nullable: false));
        }
    }
}

namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemaangepast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Opmerking", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "Opmerking");
        }
    }
}

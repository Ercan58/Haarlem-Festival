namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "statusId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "statusId");
        }
    }
}

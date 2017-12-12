namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini9999 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talk", "Location_Id", c => c.Int());
            CreateIndex("dbo.Talk", "Location_Id");
            AddForeignKey("dbo.Talk", "Location_Id", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Talk", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Talk", new[] { "Location_Id" });
            DropColumn("dbo.Talk", "Location_Id");
        }
    }
}

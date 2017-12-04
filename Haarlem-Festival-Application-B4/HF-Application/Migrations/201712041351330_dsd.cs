namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jazz", "imagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jazz", "imagePath");
        }
    }
}

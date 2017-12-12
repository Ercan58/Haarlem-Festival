namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talk", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Talk", "ImagePath");
        }
    }
}

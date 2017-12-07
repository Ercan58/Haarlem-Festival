namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Historic", "GuidName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Historic", "GuidName");
        }
    }
}

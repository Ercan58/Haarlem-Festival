namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jazz", "eventDayID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jazz", "eventDayID");
        }
    }
}

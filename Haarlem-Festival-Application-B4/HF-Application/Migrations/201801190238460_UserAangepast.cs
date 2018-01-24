namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAangepast : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Mail", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
        }
    }
}

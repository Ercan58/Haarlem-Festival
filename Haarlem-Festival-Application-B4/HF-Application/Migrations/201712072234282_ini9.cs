namespace HF_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini9 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TourLanguages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TourLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToursLanguage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

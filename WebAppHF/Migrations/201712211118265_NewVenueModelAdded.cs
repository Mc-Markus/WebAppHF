namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewVenueModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        InfoText = c.String(nullable: false),
                        ImagePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Venues");
        }
    }
}

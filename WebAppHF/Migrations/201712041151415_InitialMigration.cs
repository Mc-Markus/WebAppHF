namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        LocationName = c.String(),
                        Price = c.Int(nullable: false),
                        Adress = c.String(),
                        SeatsAvailable = c.Int(nullable: false),
                        SecondaryEventID = c.Int(),
                        Hall = c.String(),
                        Band = c.String(),
                        IMGString = c.String(),
                        RestaurantID = c.Int(),
                        Title = c.String(),
                        Description = c.String(),
                        MaxTicketsPP = c.Int(),
                        Hall1 = c.String(),
                        IMGString1 = c.String(),
                        Language = c.String(),
                        GuideName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Stars = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        ReducedPrice = c.Int(nullable: false),
                        FoodTypes = c.String(),
                        FoodIMGString = c.String(),
                        RestaurantIMGString = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurants");
            DropTable("dbo.Records");
            DropTable("dbo.Orders");
            DropTable("dbo.Events");
            DropTable("dbo.AdminAccounts");
        }
    }
}

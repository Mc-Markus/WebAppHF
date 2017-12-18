namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restaurantNotNullable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM RESTAURANTS WHERE Name IS NULL");
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "FoodTypes", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "FoodIMGString", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "RestaurantIMGString", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "RestaurantIMGString", c => c.String());
            AlterColumn("dbo.Restaurants", "FoodIMGString", c => c.String());
            AlterColumn("dbo.Restaurants", "FoodTypes", c => c.String());
            AlterColumn("dbo.Restaurants", "Address", c => c.String());
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
        }
    }
}

namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Records", newName: "OrderItems");
            AddColumn("dbo.Events", "Amount", c => c.Int());
            AddColumn("dbo.Events", "Talk_ID", c => c.Int());
            AddColumn("dbo.Restaurants", "FoodType1", c => c.String(nullable: false));
            AddColumn("dbo.Restaurants", "FoodType2", c => c.String(nullable: false));
            AddColumn("dbo.Restaurants", "FoodType3", c => c.String(nullable: false));
            CreateIndex("dbo.Events", "Talk_ID");
            AddForeignKey("dbo.Events", "Talk_ID", "dbo.Events", "ID");
            DropColumn("dbo.Restaurants", "FoodTypes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "FoodTypes", c => c.String(nullable: false));
            DropForeignKey("dbo.Events", "Talk_ID", "dbo.Events");
            DropIndex("dbo.Events", new[] { "Talk_ID" });
            DropColumn("dbo.Restaurants", "FoodType3");
            DropColumn("dbo.Restaurants", "FoodType2");
            DropColumn("dbo.Restaurants", "FoodType1");
            DropColumn("dbo.Events", "Talk_ID");
            DropColumn("dbo.Events", "Amount");
            RenameTable(name: "dbo.OrderItems", newName: "Records");
        }
    }
}

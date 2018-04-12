namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passePartout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Event_ID", c => c.Int());
            CreateIndex("dbo.OrderItems", "Event_ID");
            AddForeignKey("dbo.OrderItems", "Event_ID", "dbo.Events", "ID");
            DropColumn("dbo.OrderItems", "EventID");
            DropColumn("dbo.OrderItems", "EventType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "EventType", c => c.String());
            AddColumn("dbo.OrderItems", "EventID", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderItems", "Event_ID", "dbo.Events");
            DropIndex("dbo.OrderItems", new[] { "Event_ID" });
            DropColumn("dbo.OrderItems", "Event_ID");
        }
    }
}

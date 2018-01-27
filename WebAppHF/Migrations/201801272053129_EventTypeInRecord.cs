namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventTypeInRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "EventType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "EventType");
        }
    }
}

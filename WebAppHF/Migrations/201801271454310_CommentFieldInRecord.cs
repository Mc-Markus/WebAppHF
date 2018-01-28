namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentFieldInRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "Comment");
        }
    }
}

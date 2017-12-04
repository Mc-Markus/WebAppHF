namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAdminAccount : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ADMINACCOUNTS (USERNAME, PASSWORD) VALUES ('Jan-Rintje', 'JRAb2')");
            Sql("INSERT INTO ADMINACCOUNTS (USERNAME, PASSWORD) VALUES ('Hossam', 'HCb2')");
            Sql("INSERT INTO ADMINACCOUNTS (USERNAME, PASSWORD) VALUES ('Samir', 'SYb2')");
            Sql("INSERT INTO ADMINACCOUNTS (USERNAME, PASSWORD) VALUES ('Mike', 'MTb2')");
            Sql("INSERT INTO ADMINACCOUNTS (USERNAME, PASSWORD) VALUES ('Mark', 'MvdBb2')");
        }

        public override void Down()
        {
        }
    }
}

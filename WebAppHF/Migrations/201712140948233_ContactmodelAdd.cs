namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactmodelAdd : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Contact(Email,Name,Subject,Question) Values(Test@email.nl,Bas,RestaurantModel,Hello?)");
        }
        
        public override void Down()
        {
        }
    }
}

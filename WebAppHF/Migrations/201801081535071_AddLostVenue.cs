namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLostVenue : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Venues (Name, InfoText, ImagePath) VALUES ('Hof van Bakenes', 'The Hofje van Bakenes or Bakenesserkamer is a hofje in Haarlem, Netherlands, located between the Bakenessergracht and the Wijde Appelaarsteeg.', '../IMG/IMAGES_WALKS/HofVanBakenes.jpg')");
        }
        
        public override void Down()
        {
        }
    }
}

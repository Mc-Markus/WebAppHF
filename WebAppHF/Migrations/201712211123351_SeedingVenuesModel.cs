namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingVenuesModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Venues (Name, InfoText, ImagePath) VALUES ('Church of St.Bavo', 'The Grote Kerk or St.-Bavokerk is a Protestant church and former Catholic cathedral located on the central market square in the Dutch city of Haarlem. Another Haarlem church called the Cathedral of Saint Bavo now serves as the main cathedral for the Roman Catholic Diocese of Haarlem-Amsterdam.', '../IMG/IMAGES_WALKS/BavoKerk.jpg')");
            Sql("INSERT INTO Venues (Name, InfoText, ImagePath) VALUES ('De Grote Markt', 'The Grote Markt is in the center of Haarlem, with the City Hall across from the St. Bavochurch.', '../IMG/IMAGES_WALKS/GroteMarkt.jpg')");
            Sql("INSERT INTO Venues (Name, InfoText, ImagePath) VALUES ('De Hallen', 'De Hallen Haarlem is the name of the exhibition space on the Grote Markt, Haarlem, Netherlands, where modern and contemporary art is on display in alternating presentations.', '../IMG/IMAGES_WALKS/DeHallen.jpg')");
            Sql("INSERT INTO Venues (Name, InfoText, ImagePath) VALUES ('Proveniershof', 'The Proveniershuis is a hofje and former schutterij on the Grote Houtstraat in Haarlem, Netherlands. The complex of buildings surrounds a rectangular garden taking up a city block.', '../IMG/IMAGES_WALKS/Proveniershof.jpg')");
            Sql("INSERT INTO Venues (Name, InfoText, ImagePath) VALUES ('Jopen kerk', 'Jopen is a beer brewery from Haarlem, Netherlands. Jopens beer is a result of the work of Stichting Haarlems Biergenootschap, which was founded in 1992. The mission of the Biergenootschap is to re-create traditional Haarlem beers and bring them to the commercial market.', '../IMG/IMAGES_WALKS/JopenKerk.jpg')");
            Sql("INSERT INTO Venues (Name, InfoText, ImagePath) VALUES ('Waalse kerk', 'The Waalse kerk is a historical church dating from the 14th century on the Begijnhof in Haarlem, Netherlands. The Waalse kerk is a Walloon church that was built in the middle of the 14th century and has an upper gallery built for the Beguines who lived there on the courtyard that still bears their name.', '../IMG/IMAGES_WALKS/WaalseKerk.jpg')");
            Sql("INSERT INTO Venues (Name, InfoText, ImagePath) VALUES ('De Adriaan', 'De Adriaan is a windmill in the Netherlands that burnt down in 1932 and was rebuilt in 2002. The original windmill dates from 1779 and the mill has been a distinctive part of the skyline of Haarlem for centuries.', '../IMG/IMAGES_WALKS/DeAdriaan.jpg')");
            Sql("INSERT INTO Venues (Name, InfoText, ImagePath) VALUES ('Amsterdamse Poort', 'The Amsterdamse Poort is an old city gate of Haarlem, Netherlands. It is located at the end of the old route from Amsterdam to Haarlem and the only gate left from the original twelve city gates.', '../IMG/IMAGES_WALKS/DeAmsterdamsePoort.jpg')");

        }
        
        public override void Down()
        {
        }
    }
}

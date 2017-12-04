namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRestaurants : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Restaurants (NAME, ADDRESS, STARS, PRICE, REDUCEDPRICE, FOODTYPES, FOODIMGSTRING, RESTAURANTIMGSTRING) VALUES ('Restaurant Mr. & Mrs.', 'Lange Veerstraat 4, 2011 DB Haarlem, Nederland', 4, 4500, 2250, 'Dutch, fish and seafood, European', '/IMG/food1.jpg', '/IMG/restaurant1.jpg')");
            Sql("INSERT INTO Restaurants (NAME, ADDRESS, STARS, PRICE, REDUCEDPRICE, FOODTYPES, FOODIMGSTRING, RESTAURANTIMGSTRING) VALUES ('Ratatouille', 'Spaarne 96, 2011 CL Haarlem, Nederland', 4, 4500, 2250, 'French, fish and seafood, European', '/IMG/food2.jpg', '/IMG/restaurant2.jpg')");
            Sql("INSERT INTO Restaurants (NAME, ADDRESS, STARS, PRICE, REDUCEDPRICE, FOODTYPES, FOODIMGSTRING, RESTAURANTIMGSTRING) VALUES ('Restaurant ML', 'Kleine Houtstraat 70, 2011 DR Haarlem, Nederland', 4, 4500, 2250, 'Dutch, fish and seafood, European', '/IMG/food3.jpg', '/IMG/restaurant3.jpg')");
            Sql("INSERT INTO Restaurants (NAME, ADDRESS, STARS, PRICE, REDUCEDPRICE, FOODTYPES, FOODIMGSTRING, RESTAURANTIMGSTRING) VALUES ('Restaurant Fris', 'Twijnderslaan 7, 2012 BG Haarlem, Nederland', 4, 4500, 2250, 'Dutch, French, European', '/IMG/food4.jpg', '/IMG/restaurant4.jpg')");
            Sql("INSERT INTO Restaurants (NAME, ADDRESS, STARS, PRICE, REDUCEDPRICE, FOODTYPES, FOODIMGSTRING, RESTAURANTIMGSTRING) VALUES ('Specktakel', 'Spekstraat 4, 2011 HM Haarlem, Nederland', 3, 3500, 1750, 'Europees, Internationaal,Aziatisch', '/IMG/food5.jpg', '/IMG/restaurant5.jpg')");
            Sql("INSERT INTO Restaurants (NAME, ADDRESS, STARS, PRICE, REDUCEDPRICE, FOODTYPES, FOODIMGSTRING, RESTAURANTIMGSTRING) VALUES ('Grand Cafe Brinkman', 'Grote Markt 13, 2011 RC Haarlem, Nederland', 3, 3500, 1750, 'Dutch, European, Modern', '/IMG/food6.jpg', '/IMG/restaurant6.jpg')");
            Sql("INSERT INTO Restaurants (NAME, ADDRESS, STARS, PRICE, REDUCEDPRICE, FOODTYPES, FOODIMGSTRING, RESTAURANTIMGSTRING) VALUES ('Urban Frenchy Bistro Toujours', 'Oude Groenmarkt 10-12, 2011 HL Haarlem, Nederland', 3, 3500, 1750, 'Dutch, fish and seafood, European', '/IMG/food7.jpg', '/IMG/restaurant7.jpg')");
            Sql("INSERT INTO Restaurants (NAME, ADDRESS, STARS, PRICE, REDUCEDPRICE, FOODTYPES, FOODIMGSTRING, RESTAURANTIMGSTRING) VALUES ('The Golden Bull', 'Zijlstraat 39, 2011 TK Haarlem, Nederland', 3, 3500, 1750, 'Steakhouse, Argentinian, European', '/IMG/food8.jpg', '/IMG/restaurant8.jpg')");

        }

        public override void Down()
        {
        }
    }
}

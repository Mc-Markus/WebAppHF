namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertFirstTour : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180726','10:00 AM', '10:00 AM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'Frederic')");
        }
        
        public override void Down()
        {
        }
    }
}

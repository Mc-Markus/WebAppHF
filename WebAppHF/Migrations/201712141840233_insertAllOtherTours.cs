namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertAllOtherTours : DbMigration
    {
        public override void Up()
        {
            Sql(" INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180726','10:00AM', '10:00AM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Jan-Willem')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180726','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'Frederic')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180726','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Jan-Willem')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180726','16:00PM', '16:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'Frederic')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180726','16:00PM', '16:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Jan-Willem')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180727','10:00AM', '10:00AM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'William')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180727','10:00AM', '10:00AM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Annet')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180727','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'William')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180727','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Annet')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180727','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Chinese', 'Kim')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180727','16:00PM', '16:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'William')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180727','16:00PM', '16:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Annet')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','10:00AM', '10:00AM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'Frederic')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','10:00AM', '10:00AM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'William')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','10:00AM', '10:00AM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Jan-Willem')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','10:00AM', '10:00AM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Annet')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'Frederic')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'William')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Jan-Willem')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Annet')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','13:00PM', '13:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Chinese', 'Kim')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','16:00PM', '16:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'English', 'Frederic')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','16:00PM', '16:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Dutch', 'Jan-Willem')"
+ " INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, LANGUAGE, GUIDENAME) VALUES ('TOUR','HAARLEM TOUR', '20180728','16:00PM', '16:00PM', 'Bavo', 1750, 'Grote Markt 22, 2011 RD Haarlem', 12, 'Chinese', 'Kim')"
);
        }
        
        public override void Down()
        {
        }
    }
}

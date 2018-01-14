namespace WebAppHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateTalks : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EVENTS(DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, TITLE, DESCRIPTION, MAXTICKETSPP, HALL, IMGSTRING) VALUES('TALK', 'Giel Beelen', '20180726', '8:00PM', '10:00PM', 'De toneelschuur', 0, 'Lange Begijnestraat 9 2011 HH Haarlem', 125, 'Giel Beelen meets Rob Trip', 'Have you ever wanted to question a famous DJ or a TV host? Giel Beelen(40) a famous DJ for 3FM and Rob Trip(57); another famous person will question each other, LIVE at the Toneelschuur in Haarlem.', 2, 't.b.d.', '/IMG/talk1.jpg')" 
              + "INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, TITLE, DESCRIPTION, MAXTICKETSPP, HALL, IMGSTRING) VALUES ('TALK','Femke Halsema', '20180727','8:00PM', '10:00PM', 'De toneelschuur', 0, 'Lange Begijnestraat 9 2011 HH Haarlem', 125, 'Femke Halsema meets Job Cohen', 'Would you like to see famous ex-politics talk about the experience of Haarlem for them and the influence of Haarlem on their career? Ex - politic Femke Halsema(51) meets jurist and ex - politic almost bald Job Cohen(70).Femke and Job both were part of the Labour Party(PvdA in Dutch).', 2, 't.b.d.', '/IMG/talk2.jpg')" 
              + "INSERT INTO EVENTS (DISCRIMINATOR, NAME, DATE, STARTTIME, ENDTIME, LOCATIONNAME, PRICE, ADRESS, SEATSAVAILABLE, TITLE, DESCRIPTION, MAXTICKETSPP, HALL, IMGSTRING) VALUES ('TALK','Paul Witteman', '20180728','8:00PM', '10:00PM', 'De toneelschuur', 0, 'Lange Begijnestraat 9 2011 HH Haarlem', 125, 'Paul Witteman meets Brigitte Kaandorp', ' TV host and journalist Paul Witteman (70) meets comedian and singer-songwriter Brigitte Kaandorp (55). Fun fact: Brigitte sometimes plays the ukulele in her performances.She might just play it at the Toneelschuur if you go the talk!', 2, 't.b.d.', '/IMG/talk3.jpg')");
        }
        
        public override void Down()
        {
        }
    }
}

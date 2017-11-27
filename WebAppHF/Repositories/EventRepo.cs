using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class EventRepo : IEventRepo
    {
        public Event GetEventByID(int ID)
        {
            using (Database database = new Database())
            {
                Event eventByID;

                eventByID = database.Events.SingleOrDefault(e => e.ID == ID);

                return eventByID;
            }
        }
    }
}
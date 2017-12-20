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
            using (HFContext database = new HFContext())
            {
                Event eventByID;

                eventByID = database.Events.SingleOrDefault(e => e.ID == ID);

                return eventByID;
            }
        }

        public void CreateEvent (Event e, int eventType)
        {

        }
    }
}
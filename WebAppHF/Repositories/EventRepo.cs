using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class EventRepo : IEventRepo
    {

        // SHOULD NOT BE USED!! EVENT IS ABSTRACT
        HFContext ctx = new HFContext();
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

        public void UpdateEvent(Event e)
        {
            throw new NotImplementedException();
        }

        public void Remove(Event e)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEvents()
        {
            List<Event> list = ctx.Events.ToList();
            return list;
        }

    }
}
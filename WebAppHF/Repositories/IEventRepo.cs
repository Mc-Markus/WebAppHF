using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public interface IEventRepo
    {
        // SHOULD NOT BE USED!! EVENT IS ABSTRACT
        Event GetEventByID(int ID);
        void CreateEvent(Event e, int eventType);
        void UpdateEvent(Event e);
        void Remove(Event e);
        List<Event> GetEvents();
    }
}
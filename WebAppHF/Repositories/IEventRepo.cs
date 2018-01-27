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
        List<Event> GetEvents();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public interface IEventRepo
    {
        Event GetEventByID(int ID);
        List<Event> GetEvents();
    }
}
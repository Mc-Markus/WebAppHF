using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class EventRepo : IEventRepo
    {
        public List<Event> GetAll()
        {
            using (Database database = new Database())
            {
                List<Event> events = new List<Event>();

                return events;
            }
        }
    }
}
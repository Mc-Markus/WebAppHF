using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RestaurantSittingRepo : IRestaurantSitting
    {
        private readonly HFContext _database = new HFContext();
        public RestaurantSitting GetRestaurantSessionByID(int id)
        {
            using (HFContext context = new HFContext())
            {
                var restaurantSession = context.RestaurantSessions.SingleOrDefault(j => j.ID == id);
                return restaurantSession;
            }
        }

        public Event GetEvent(int resId, DateTime date, DateTime startingtime)
        {

            Event eventId = _database.RestaurantSessions.SingleOrDefault(m => m.Date == date
            && m.RestaurantID == resId
            && m.StartTime == startingtime);
            return eventId;
        }

        public IEnumerable<RestaurantSitting> Events()
        {
            IEnumerable<RestaurantSitting> restaurant = _database.RestaurantSessions.ToList();
            return restaurant;
        }
    }
}
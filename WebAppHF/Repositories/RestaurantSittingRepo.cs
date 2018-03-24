using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RestaurantSittingRepo : IRestaurantSitting
    {
        private HFContext database = new HFContext();
        public RestaurantSitting GetRestaurantSessionByID(int ID)
        {
            RestaurantSitting restaurantSession;
            using (HFContext context = new HFContext())
            {
                restaurantSession = context.RestaurantSessions.SingleOrDefault(j => j.ID == ID);
                return restaurantSession;
            }
        }

        public int GetEventID(int ResID, DateTime date, DateTime startingtime)
        {

            int EventId = database.RestaurantSessions.Where(m => m.Date == date
            && m.RestaurantID == ResID
            && m.StartTime == startingtime)
            .Select(m => m.ID).SingleOrDefault();
            return EventId;
        }

        public IEnumerable<RestaurantSitting> Events()
        {
            IEnumerable<RestaurantSitting> restaurant = database.RestaurantSessions.ToList();
            return restaurant;
        }
    }
}
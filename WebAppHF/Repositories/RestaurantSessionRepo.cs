using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RestaurantSessionRepo : IRestaurantSessionRepo
    {
        public RestaurantSession GetRestaurantSessionByID(int ID)
        {
            RestaurantSession restaurantSession;
            using (HFContext context = new HFContext())
            {
                restaurantSession = context.RestaurantSessions.SingleOrDefault(j => j.ID == ID);
                return restaurantSession;
            }
        }
    }
}
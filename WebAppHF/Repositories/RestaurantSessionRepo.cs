﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RestaurantSessionRepo : IRestaurantSessionRepo
    {
        private HFContext database = new HFContext();
        public RestaurantSession GetRestaurantSessionByID(int ID)
        {
            RestaurantSession restaurantSession;
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
    }
}
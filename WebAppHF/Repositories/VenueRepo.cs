using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class VenueRepo : IVenueRepo
    {
        public Venue GetVenueByID(int Id)
        {
            Venue venue;

            using (HFContext context = new HFContext())
            {
                venue = context.Venues.SingleOrDefault(v => v.ID == Id);
                return venue;
            }

        }
    }
}
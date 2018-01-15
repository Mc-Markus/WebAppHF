using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Repositories;
using WebAppHF.Models;

namespace WebAppHF.Controllers
{
    public class WalksController : Controller
    {
        // GET: Walks
        private IVenueRepo venueRepo = new VenueRepo();
        public ActionResult Index()
        {
            Venue venue = venueRepo.GetVenueByID(1);
            return View(venue);
        }

        
        public ActionResult LoadLocation()
        {
            return PartialView("_locations");
        }
        
        public ActionResult LoadMap()
        {
            return PartialView("_map");
        }

        public ActionResult LoadMapVenue(int id)
        {
            Venue venue = venueRepo.GetVenueByID(id);
            return PartialView("_venue", venue);
        }

        public ActionResult LoadOrderPage()
        {
            return View("OrderPageTour");
        }
    }
}
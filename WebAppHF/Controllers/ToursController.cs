using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Repositories;
using WebAppHF.Models;

namespace WebAppHF.Controllers
{
    public class ToursController : Controller
    {
        // GET: Walks
        private IVenueRepo venueRepo = new VenueRepo();
        private ITourRepo TourRepo = new TourRepo();

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

        public ActionResult OrderPageTour()
        {
            List<Tour> tours = TourRepo.GetAll();

            List<DisplayRecord> drs = new List<DisplayRecord>();

            foreach (Tour tour in tours)
            {
                drs.Add(new DisplayRecord(tour, new Record()));
            }

            return View("OrderPageTour", drs);
        }
    }
}
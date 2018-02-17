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
        //Create a new TourRepo and VenueRepo object.
        private IVenueRepo venueRepo = new VenueRepo();
        private ITourRepo TourRepo = new TourRepo();

        //Get a venue for the initial pageload.
        public ActionResult Index()
        {
            Venue venue = venueRepo.GetVenueByID(1);
            return View(venue);
        }

        //Return a PartialView
        public ActionResult LoadLocation()
        {
            return PartialView("_locations");
        }

        //Return a PartialView
        public ActionResult LoadMap()
        {
            return PartialView("_map");
        }

        //Get a venue view based on the numeric value of a button and return it.
        public ActionResult LoadMapVenue(int id)
        {
            Venue venue = venueRepo.GetVenueByID(id);
            return PartialView("_venue", venue);
        }

        public ActionResult OrderPageTour()
        {
            List<List<OrderTourViewModel>> OrderTours = TourRepo.GetTourViewModels();

            return View("OrderPageTour", OrderTours);
        }
    }
}
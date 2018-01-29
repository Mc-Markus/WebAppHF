using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppHF.Models;
using WebAppHF.Repositories;

namespace Unit_Tests
{
    public class AdminController : Controller
    {
        AdminAccount account = new AdminAccount();
        private IRestaurantRepo restaurantRepo = new RestaurantRepo();
        private IEventRepo eventRepo = new EventRepo();



        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }



        [Authorize]
        public ActionResult RestaurantList()
        {
            var allRestaurants = restaurantRepo.GetAllRestaurants();
            return View(allRestaurants);
        }

        [Authorize]
        public ActionResult CreateRestaurant()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateRestaurant(Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    restaurantRepo.CreateRestaurant(restaurant);
                    return RedirectToAction("RestaurantList");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(restaurant);
        }
        [Authorize]
        
        public ActionResult UpdateRestaurant(int id)
        {
            Restaurant @restaurant = restaurantRepo.GetRestaurant(id);
            return View(@restaurant);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateRestaurant(Restaurant restaurant, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    restaurantRepo.UpdateRestaurant(restaurant);
                    return RedirectToAction("RestaurantList");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(restaurant);
        }
        [Authorize]
        
        public ActionResult DeleteRestaurant(int id)
        {
            Restaurant @restaurant = restaurantRepo.GetRestaurant(id);
            return View(@restaurant);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public bool DeleteRestaurantConfirm(int id)
        {
            try
            {
                Restaurant e = restaurantRepo.GetRestaurant(id);
                restaurantRepo.Remove(e);

            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return false;
            }
            return true;
        }


        [Authorize]
        public ActionResult EventList()
        {
            var allEvents = eventRepo.GetEvents();
            return View(allEvents);
        }

        [Authorize]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateEvent(Event e, int eventType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    eventRepo.CreateEvent(e, eventType);
                    return RedirectToAction("EventList");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(e);
        }

        [Authorize]
        
        public ActionResult UpdateEvent(int id)
        {
            Event @restaurant = eventRepo.GetEventByID(id);
            return View(@restaurant);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateEvent(Event e, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    eventRepo.UpdateEvent(e);
                    return RedirectToAction("EventList");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(e);
        }

        [Authorize]
        
        public ActionResult DeleteEvent(int id)
        {
            Event @restaurant = eventRepo.GetEventByID(id);
            return View(@restaurant);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteEventConfirm(int id)
        {
            try
            {
                Event e = eventRepo.GetEventByID(id);
                eventRepo.Remove(e);

            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("EventList");
        }

    }
}
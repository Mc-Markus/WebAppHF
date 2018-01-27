using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Models;
using WebAppHF.Repositories;

namespace WebAppHF.Controllers
{
    public class CartController : Controller
    {
        //IEventRepo rep = new EventRepo();
        IJazzRepo jazzRepo = new JazzRepo();
        ITalkRepo talkRepo = new TalkRepo();
        ITourRepo tourRepo = new TourRepo();
        IRestaurantRepo restaurantRepo = new RestaurantRepo();

        // GET: Cart
        public ActionResult Index()
        {
            //Checks if sessions contains a valid list of records
            List<Record> sessionCart = null;
            try
            {
                sessionCart = (List<Record>)Session["Cart"];
            }
            catch
            {
                return RedirectToAction("CartEmpty");
            }
            //Checks if cart isnt empty
            if (sessionCart == null)
            {
                return RedirectToAction("CartEmpty");
            }

            //creates displayRecords for all records in session
            List<DisplayRecord> displayRecords = new List<DisplayRecord>();
            foreach (Record record in sessionCart)
            {
                displayRecords.Add(new DisplayRecord(getEvent(record), record));
            }

            //chooses 3 random restaurants for cross selling
            List<Restaurant> restaurants = restaurantRepo.GetAllRestaurants().ToList();

            Random rnd = new Random();

            List<Restaurant> crossSelling = new List<Restaurant>();

            for (int i = 0; i < 3; i++)
            {
                Restaurant restaurant = restaurants[rnd.Next(0, restaurants.Count())];
                crossSelling.Add(restaurant);
                restaurants.Remove(restaurant);
            }

            CartViewModel cartViewModel = new CartViewModel(displayRecords, crossSelling);

            #region OLD CART FROM HOSSAM
            
            ////Cart items
            //CartModel cart1 = new CartModel();
            //cart1.Items = (List<Event>)Session["cart"];
            //if (cart1.Items == null)
            //{
            //    return RedirectToAction("CartEmpty");
            //}
            //List<Event> list = rep.GetEvents();
            //cart1.Items = list;

            ////Crossselling
            //Random rng = new Random();
            //List<Event> cross = new List<Event>();

            //int i = 0;

            //while (i != 5)
            //{
            //    cross.Add(list[rng.Next(0, (list.Count - 1))]);
            //    i++;
            //}

            //cart1.CrossSellItems = cross;

            #endregion

            return View(cartViewModel);
        }

        [HttpPost]
        public ActionResult Index(CartModel cart)
        {
            return View();
        }

        public ActionResult PaymentMethod()
        {
            CartModel cart = new CartModel();
            cart.Items = (List<Event>)Session["cart"];
            foreach (Event e in cart.Items)
            {
                cart.Price += e.Price;
            }
            return View(cart);
        }

        [HttpPost]
        public ActionResult PaymentMethod(CartModel cart)
        {
            // gooi shit in db
            return RedirectToAction("Success"); // of failure
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult CartEmpty()
        {
            return View();
        }

        public ActionResult Failure()
        {
            return View();
        }

        //Gets event based on eventType and eventID
        public Event getEvent(Record record)
        {
            switch (record.EventType)
            {
                case "Jazz":
                    return jazzRepo.GetJazzByID(record.EventID);
                case "Tour":
                    return tourRepo.GetWalkByID(record.EventID);
                case "Talk":
                    return talkRepo.GetTalk(record.EventID);
                default:
                    return null;
            }
        }
    }
}
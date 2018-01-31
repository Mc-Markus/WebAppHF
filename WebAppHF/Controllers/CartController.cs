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
        IRestaurantSessionRepo restaurantSession = new RestaurantSessionRepo();
        IRecordRepository recordRepository = new RecordRepository();
        IRestaurantRepo restaurantRepo = new RestaurantRepo();

        // GET: Cart
//        public ActionResult Index()
//        {
//            //Checks if sessions contains a valid list of records
//            //List<Record> sessionCart = null;
//            //try
//            //{
//            //    sessionCart = (List<Record>)Session["Cart"];
//            //}
//            //catch
//            //{
//            //    return RedirectToAction("CartEmpty");
//            //}
//            ////Checks if cart isnt empty
//            //if (sessionCart == null)
//            //{
//            //    return RedirectToAction("CartEmpty");
//            //}

//            ////creates displayRecords for all records in session
//            //List<DisplayRecord> displayRecords = new List<DisplayRecord>();
//            //foreach (Record record in sessionCart)
//            //{
//            //    displayRecords.Add(new DisplayRecord(getEvent(record), record));
//            //}

//            ////chooses 3 random restaurants for cross selling
//            //List<Restaurant> restaurants = restaurantRepo.GetAllRestaurants().ToList();

//            //Random rnd = new Random();

//            //List<Restaurant> crossSelling = new List<Restaurant>();

//            //for (int i = 0; i < 3; i++)
//            //{
//            //    Restaurant restaurant = restaurants[rnd.Next(0, restaurants.Count())];
//            //    crossSelling.Add(restaurant);
//            //    restaurants.Remove(restaurant);
//            //}

//            //CartViewModel cartViewModel = new CartViewModel(displayRecords, crossSelling);

//            if (Session["Cart"] == null && Session["RestCart"] == null)
//            {
//                return RedirectToAction("CartEmpty");
//            }
//            else
//            {
//                CartModel cart = new CartModel();
//                cart.Items = (List<Event>)Session["cart"];
//                cart.RestItems = (List<Restaurant>)Session["RestCart"];
//                //List<Event> list = rep.GetEvents();
//                //cart.Items = list;

//                //////Crossselling
//                //Random rng = new Random();
//                //List<Event> cross = new List<Event>();

//                //int i = 0;

//                //while (i != 5)
//                //{
//                //    cross.Add(list[rng.Next(0, (list.Count - 1))]);
//                //    i++;
//                //}

//                //cart.CrossSellItems = cross;
//                int totalPrice = 0;

//                foreach (Event e in cart.Items)
//                {
//                    if (e is TalkModel)
//                    {
//                        TalkModel talk = (TalkModel)e;
//                        totalPrice += (talk.Amount * talk.Price);
//                    }
//                    //zet hier jullie viewmodels van jullie champions die een amount bevat net als de if statement hierboven.
                    
                    
//                }

//                foreach (Restaurant rest in cart.RestItems)
//                {
//                    //doe hetzelfde hier met een viewmodel met een amount voor restaurant als hierboven.
//                }
//            { 
//}
//                return View(cart);
//            }
//        }

//        [HttpPost]//Cartmodel is no longer in use
//        public ActionResult Index(CartModel cart)
//        {
//            return View();
//        }

        public ActionResult Cart()
        {
            if (Session["Cart"] == null && Session["RestCart"] == null)
            {
                //Als de session leeg is, zijn er geen items toegevoegd aan de cart, redirect naar cartempty view.
                return RedirectToAction("CartEmpty");
            }
            //bij deze else statement wordt de totaalprijs van alle items in de cart berekend.
            else
            {
                CartModel cart = (CartModel)Session["Cart"];
                int totalPrice = 0;

                foreach (Event e in cart.Items)
                {
                    if (e is TalkModel)
                    {
                        TalkModel talk = (TalkModel)e;
                        totalPrice += (talk.Amount * talk.Price);
                    }
                    //zet hier jullie viewmodels van jullie champions die een amount bevat net als de if statement hierboven.


                }
                //doe hetzelfde hier met een viewmodel met een amount voor restaurant als hierboven.
                //foreach (Restaurant rest in cart.RestItems)
                //{

                //}
                cart.Price = totalPrice;
                return View(cart);
            }
        }

        [HttpPost]
        public ActionResult Cart(CartModel cart)
        {
            //als er eventuele wijzigingen in aantal zijn geweest wordt de cart in session herschreven.
            Session["Cart"] = cart;
            return RedirectToAction("PaymentMethod");
        }

        public ActionResult PaymentMethod()
        {
            //session wordt opgehaald om af te rekenen, als de prijs 0 is wordt er direct naar de success view geredirect.
            CartModel cart = (CartModel)Session["Cart"];
            if(cart.Price == 0)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return View(cart);
            }
        }

        [HttpPost]
        public ActionResult PaymentMethod(CartModel cart)
        {
            return RedirectToAction("Success"); 
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
        //public Event getEvent(Record record)
        //{
        //    switch (record.EventType)
        //    {
        //        case "Jazz":
        //            return jazzRepo.GetJazzByID(record.EventID);
        //        case "Tour":
        //            return tourRepo.GetWalkByID(record.EventID);
        //        case "Talk":
        //            return talkRepo.GetTalk(record.EventID);
        //        case "RESTAURANTSESSION":
        //            return restaurantSession.GetRestaurantByID(record.EventID);
        //        default:
        //            return null;
        //    }
        //}
    }
}
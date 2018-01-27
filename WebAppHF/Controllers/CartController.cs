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

        // GET: Cart
        public ActionResult Index()
        {
            List<Record> sessionCart = null;
            try
            {
                sessionCart = (List<Record>)Session["Cart"];
            }
            catch
            {
                return RedirectToAction("CartEmpty");
            }

            if (sessionCart == null)
            {
                return RedirectToAction("CartEmpty");
            }

            List<DisplayRecord> displayRecords = new List<DisplayRecord>();
            foreach (Record record in sessionCart)
            {
                displayRecords.Add(new DisplayRecord(getEvent(record), record));
            }

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
            return View(displayRecords);
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
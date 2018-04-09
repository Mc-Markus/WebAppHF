using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Models;
using WebAppHF.Repositories;

namespace WebAppHF.Controllers
{
    public class JazzController : Controller
    {

        private IJazzRepo repo = new JazzRepo();
        // GET: Jazz
        public ActionResult Index()
        {
            //gets a list with summarys for every day of the festival
            List<JazzDaySummary> summarys = repo.GetDaySummarys();

            if (summarys == null)
            {
                return RedirectToAction("Index", "Home", null);
            }

            return View(summarys); 
        }

        public ActionResult Day(DateTime date)
        {
            //gets all jazz events for a single day
            List<Jazz> JazzActs = repo.GetJazzActsByDay(date);

            if (JazzActs == null)
            {
                return RedirectToAction("Index");
            }
            return View(JazzActs);
        }

        [HttpGet]
        public ActionResult Book(DateTime date)
        {
            //gets all jazz tickets for an event
            List<Jazz> JazzActs = repo.GetJazzActsByDay(date);
            Jazz passePartoutWeekend = repo.GetPassePartoutWeekend();
            Jazz passePartoutDay = repo.GetPassePartoutDay(date);

            //converts jazz's into displayrecords
            OrderItem weekend = new OrderItem(passePartoutWeekend);
            OrderItem day = new OrderItem(passePartoutDay);
            List<OrderItem> events = new List<OrderItem>();

            foreach (Jazz jazz in JazzActs)
            {
                OrderItem oi = new OrderItem(jazz);
                events.Add(oi);
            }

            JazzBook jazzBook = new JazzBook(day, weekend, events);

            //string hall = ((Jazz)dr.Event).Hall;
            return View(jazzBook);

        }

        [HttpPost]
        public ActionResult AddToSession(JazzBook FormResponse)
        {
            //parameter could possably be changed but i leave it here cause of problems in the past
            JazzBook book = FormResponse;

            CartModel cart;

            if((CartModel)Session["Cart"] == null)
            {
                cart = new CartModel();
            }
            else
            {
                cart = (CartModel)Session["Cart"];
            }

            //adds the passe-partouts if they are selected by customer
            if (book.DayPassePartout.Amount > 0)
            {
                book.DayPassePartout.Event = repo.GetJazzByID(book.DayPassePartout.Event.ID);
                cart.AddOrderItem(book.DayPassePartout);
            }
            if (book.WeekendPassePartout.Amount > 0)
            {
                book.WeekendPassePartout.Event = repo.GetJazzByID(book.WeekendPassePartout.Event.ID);
                cart.AddOrderItem(book.WeekendPassePartout);
            }

            //adds other jazz's if selected by customer
            foreach (OrderItem oi in book.DayEvents)
            {
                if (oi.Amount > 0)
                {
                    oi.Event = repo.GetJazzByID(oi.Event.ID);
                    cart.AddOrderItem(oi);
                }
            }

            Session["Cart"] = cart;

            //send user to basket after things are added to basket
            return RedirectToAction("Index", "Cart");
            

            #region OLD DO NOT USE addToSession copy with extra documentation
            ////put this at the end of your book/reservation/buy post method ActionResult and add your records to session basket as described below
            ////please use the complete thing so it works the same in all places

            ////I use this method instead of "+=" because you can only use "+=" if there is already something in the cart
            ////and using this method you can also check if the contents of the cart are valid

            ////List that will be the new contents of the cart
            //List<Record> sessionBasket = new List<Record>();

            ////you can put your records in like sessionBasket.Add(new Record(eventID, eventType);

            ////check if session contains records if so add them to new cart contents
            //try
            //{
            //    //adds valid records to sessionBasket
            //    List<Record> basket = (List<Record>)Session["Cart"];
            //    foreach (Record record in basket)
            //    {
            //        sessionBasket.Add(record);
            //    }
            //}
            //catch
            //{
            //    //when session contains invalid values it is cleared
            //    Session["Cart"] = null;
            //}
            //finally
            //{
            //    //adds new contents to cart
            //    Session["Cart"] = sessionBasket;
            //}

            ////send user to basket after things are added to basket
            //return RedirectToAction("Index", "Basket");
            #endregion
        }

        /*HttpPost*/
        public void NEW_addToSession(/* Data van je book pagina*/)
        {

            //krijg amount description etc uit je form

            //maak een lege cart
            CartModel cart;

            //als cart in de session leeg is maak een nieuwe
            if ((CartModel)Session["Cart"] == null)
            {
                cart = new CartModel();
            }
            //anders stop de inhoud van de session in de cart
            else
            {
                cart = (CartModel)Session["Cart"];
            }
            /*
             * als amount hoger is als 0 stop het in cart met de volgende regel code:
             * 
             * cart.AddOrderItem(onderdeel uit je cart);
             *
             * een orderItem is nu wat vroeger record was met als verschil dat het
             * nu een heel event bevat ipv alleen een event id, dit maakt het meer
             * O.O. en beter uitbreidbaar
             * 
             * om het goed te laten werken moet in een orderItem hetvolgende zitten:
             * - Event
             * - Amount
             * - TotalPrice 
             * 
             * TotalPrice wordt automatisch gedaan op het moment dat je AddOrderItem doet
             * Hiervoor moet je wel zorgen dat amount > 0 en Event != null
            */

            //stop de hele cart weer terug in de session
            Session["Cart"] = cart;
        }

    }
}



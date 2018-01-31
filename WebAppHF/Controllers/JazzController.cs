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
        private string eventType = "Jazz";
        // GET: Jazz
        public ActionResult Index()
        {
            //gets a list with summarys for every day of the festival
            List<JazzDaySummary> summarys = repo.GetDaySummarys();

            if (summarys == null)
            {
                return RedirectToAction("Index", "HomeController", null);
            }

            return View(summarys);
        }
         
        public ActionResult Day()
        {
            return RedirectToAction("Index");
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

        public ActionResult Book()
        {
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public ActionResult Book(DateTime date)
        {
            //gets all jazz tickets for an event
            List<Jazz> JazzActs = repo.GetJazzActsByDay(date);
            Jazz passePartoutWeekend = repo.GetPassePartoutWeekend();
            Jazz passePartoutDay = repo.GetPassePartoutDay(date);

            //converts jazz's into displayrecords
            DisplayRecord displayRecordWeekend = new DisplayRecord(passePartoutWeekend, new Record(passePartoutWeekend.ID, eventType));
            DisplayRecord displayRecordDay = new DisplayRecord(passePartoutDay, new Record(passePartoutDay.ID, eventType));
            List<DisplayRecord> displayRecordEvents = new List<DisplayRecord>();

            foreach (Jazz jazz in JazzActs)
            {
                DisplayRecord dr = new DisplayRecord(jazz, new Record(jazz.ID, "Jazz"));
                displayRecordEvents.Add(dr);
            }

            JazzBook jazzBook = new JazzBook(displayRecordDay, displayRecordWeekend, displayRecordEvents);

            //string hall = ((Jazz)dr.Event).Hall;
            return View(jazzBook);

        }

        [HttpPost]
        public ActionResult AddToSession(JazzBook MyTestParameter)
        {
            //parameter could possably be changed but i leave it here cause of problems in the past
            JazzBook book = MyTestParameter;


            List<Record> sessionBasket = new List<Record>();
            //adds the passe-partouts if they are selected by customer
            if (book.DayPassePartout.Record.Amount > 0)
            {
                sessionBasket.Add(book.DayPassePartout.Record);
            }
            if (book.WeekendPassePartout.Record.Amount > 0)
            {
                sessionBasket.Add(book.WeekendPassePartout.Record);
            }

            //adds other jazz's if selected by customer
            foreach (DisplayRecord dr in book.DayEvents)
            {
                if (dr.Record.Amount > 0)
                {
                    sessionBasket.Add(dr.Record);
                }
            }

            //check if session contains records if so add them to new cart value
            try
            {
                List<Record> basket = (List<Record>)Session["Cart"];
                foreach (Record record in basket)
                {
                    sessionBasket.Add(record);
                }
            }
            catch
            {
                Session["Cart"] = null;
            }
            finally
            {
                Session["Cart"] = sessionBasket;
            }

            //send user to basket after things are added to basket
            return RedirectToAction("Index", "Cart");
        }

    }
}
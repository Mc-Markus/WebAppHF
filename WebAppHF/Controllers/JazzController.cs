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
            List<JazzDaySummary> summarys = repo.GetDaySummarys();

            if(summarys == null)
            {
                return RedirectToAction("Index", "HomeController", null);
            }

            return View(summarys);
        }
        
        public ActionResult Day(DateTime date)
        {
            List<Jazz> JazzActs = repo.GetJazzActsByDay(date);

            return View(JazzActs);
        }

        public ActionResult Book(DateTime date)
        {
            List<Jazz> JazzActs = repo.GetJazzActsByDay(date);
            Jazz passePartoutWeekend = repo.GetPassePartoutWeekend();
            Jazz passePartoutDay = repo.GetPassePartoutDay(date);

            DisplayRecord dr = new DisplayRecord(passePartoutWeekend, new Record());

            string hall = ((Jazz)dr.Event).Hall;
            return View(dr);
        }
    }
}
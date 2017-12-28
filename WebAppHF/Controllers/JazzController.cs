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
            List<Jazz> JazzActs = repo.GetJazzsByDay(date);

            return View(JazzActs);
        }
    }
}
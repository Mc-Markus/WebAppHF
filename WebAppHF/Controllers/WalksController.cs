using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHF.Controllers
{
    public class WalksController : Controller
    {
        // GET: Walks
        public ActionResult Index()
        {
            return View();
        }
    }
}
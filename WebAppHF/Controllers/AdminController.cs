using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppHF.Models;
using WebAppHF.Repositories;

namespace WebAppHF.Controllers
{
    public class AdminController : Controller
    {
        AdminAccount account = new AdminAccount();
        private IResetaurantRepo repo = new RestaurantRepo();
        private IEventRepo Erepo = new EventRepo();

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            
            if (ModelState.IsValid)
            {
                AdminAccount account = repository.GetAccount(model.EmailAddress, model.Password);
            }
            if (account != null)
            {
                FormsAuthentication.SetAuthCookie(account.UserName, false);

                Session["Loggedin_admin"] = account;

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("login-error", "Incorrect username/password");
                return View();
            }

        }

        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurant([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.CreateRestaurant(restaurant);
                    return RedirectToAction("Index");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateRestaurant([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]Restaurant restaurant, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.UpdateRestaurant(restaurant);
                    return RedirectToAction("Index");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRestaurant(int id)
        {
            try
            {
                Restaurant e = repo.GetRestaurant(id);
                repo.Remove(e);
                
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]Event e, int eventType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Erepo.CreateEvent(e, eventType);
                    return RedirectToAction("Index");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEvent([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]Event e, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Erepo.UpdateEvent(e);
                    return RedirectToAction("Index");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(int id)
        {
            try
            {
                Event e = Erepo.GetEventByID(id);
                Erepo.Remove(e);

            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
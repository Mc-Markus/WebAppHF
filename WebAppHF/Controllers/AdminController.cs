using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
        private IRestaurantRepo restaurantRepo = new RestaurantRepo();
        private IJazzRepo jazzRepo = new JazzRepo();
        private ITalkRepo talkRepo = new TalkRepo();
        private IAccountRepo accountRepo = new AccountRepo();
        private IRecordRepo recordRepo = new RecordRepo();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminAccount model)
        {  
            if (ModelState.IsValid)
            {
                account = accountRepo.GetAccount(model.UserName, model.Password);
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
        [Authorize]
        public ActionResult Register()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Register(AdminAccount model)
        {
            if (ModelState.IsValid)
            {
                accountRepo.RegisterUser(model);
            }

            return RedirectToAction("Index", "Admin");
        }




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
            Restaurant retrieved = restaurantRepo.GetRestaurant(id);
            if (retrieved == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(retrieved);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateRestaurant(Restaurant restaurant)
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
            Restaurant retrieved = restaurantRepo.GetRestaurant(id);
            if (retrieved == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(retrieved);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteRestaurant(int id, FormCollection fcNotUsed)
        {
            try
            {
                Restaurant e = restaurantRepo.GetRestaurant(id);
                restaurantRepo.Remove(e);

            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("RestaurantList");
        }


        [Authorize]
        public ActionResult JazzList()
        {
            var allEvents = jazzRepo.GetAll();
            return View(allEvents);
        }

        [Authorize]
        public ActionResult CreateJazz()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateJazz(Jazz e)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    jazzRepo.CreateJazz(e);
                    return RedirectToAction("JazzList");
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

        public ActionResult UpdateJazz(int id)
        {
            Event retrieved = jazzRepo.GetJazzByID(id);
            if (retrieved == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(retrieved);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateJazz(Jazz e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    jazzRepo.UpdateJazz(e);
                    return RedirectToAction("JazzList");
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

        public ActionResult DeleteJazz(int id)
        {
            Event retrieved = jazzRepo.GetJazzByID(id);
            if (retrieved == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(retrieved);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteJazz(int id, FormCollection fcNotUsed)
        {
            try
            {
                Jazz e = jazzRepo.GetJazzByID(id);
                jazzRepo.Remove(e);

            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("JazzList");
        }

        [Authorize]
        public ActionResult TalkList()
        {
            var allEvents = talkRepo.GetTalks();
            return View(allEvents);
        }

        [Authorize]
        public ActionResult CreateTalk()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateTalk(Talk e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    talkRepo.CreateTalk(e);
                    return RedirectToAction("TalkList");
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

        public ActionResult UpdateTalk(int id)
        {
            Event retrieved = talkRepo.GetTalkById(id);
            if (retrieved == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(retrieved);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateTalk(Talk e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    talkRepo.UpdateTalk(e);
                    return RedirectToAction("TalkList");
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

        public ActionResult DeleteTalk(int id)
        {
            Event retrieved = talkRepo.GetTalkById(id);
            if (retrieved == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(retrieved);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteTalk(int id, FormCollection fcNotUsed)
        {
            try
            {
                Talk e = talkRepo.GetTalkById(id);
                talkRepo.Remove(e);

            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("TalkList");
        }

        [Authorize]
        public ActionResult RecordList()
        {
            var allRecords = recordRepo.GetAllRecords();
            return View(allRecords);
        }



        [Authorize]
        public ActionResult Logout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult LoggedOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult RegisterAdmin()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult RegisterAdmin(AdminAccount newAdmin)
        {
            try
            {
                accountRepo.RegisterUser(newAdmin);

            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return View();
            }
            return RedirectToAction("Success", "Admin");
        }

        // GET: Admin
        [Authorize]
        public ActionResult Success()
        {
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Models;
using WebAppHF.Repositories;

namespace WebAppHF.Controllers
{
    public class TalkController : Controller
    {
        ITalkRepo rep = new TalkRepo();
        // GET: Talk
        public ActionResult Index()
        {
            IEnumerable<Talk> list = rep.GetTalks();
            return View(list);
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Book(Talk talk)
        {
            List<TalkModel> list = new List<TalkModel>();
            TalkModel convertedTalk = new TalkModel();
            convertedTalk = ConvertTalk(talk, convertedTalk);
            list.Add(convertedTalk);
            return View(list);
        }

        [HttpPost]
        public ActionResult Book(List<TalkModel> list)
        {
            Session["Cart"] = list;
            return View();
        }
        
        public TalkModel ConvertTalk(Talk talk, TalkModel model)
        {
            talk.Adress = model.Adress;
            talk.Date = model.Date;
            talk.Description = model.Description;
            talk.EndTime = model.EndTime;
            talk.Hall = model.Hall;
            talk.ID = model.ID;
            talk.IMGString = model.IMGString;
            talk.LocationName = model.LocationName;
            talk.MaxTicketsPP = model.MaxTicketsPP;
            talk.Name = model.Name;
            talk.Price = model.Price;
            talk.SeatsAvailable = model.SeatsAvailable;
            talk.StartTime = model.StartTime;
            talk.Title = model.Title;
            return model;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class TalkRepo : ITalkRepo
    {
        private HFContext ctx = new HFContext();
        public IEnumerable<Talk> GetTalks()
        {
            IEnumerable<Talk> list = ctx.Talks.ToList();
            return list;
        }

        public Talk GetTalk(int id)
        {
            Talk talk = ctx.Talks.Single(m => m.ID == id);
            return talk;
        }
        public void AddTalk(Talk talk)
        {
            ctx.Talks.Add(talk);
            ctx.SaveChanges();
        }
    }
}
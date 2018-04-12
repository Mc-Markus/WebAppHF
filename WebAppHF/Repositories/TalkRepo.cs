using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void AddTalk(Talk talk)
        {
            ctx.Talks.Add(talk);
            ctx.SaveChanges();
        }
        public Talk GetTalk(int id)
        {
            Talk talk = ctx.Talks.SingleOrDefault(m => m.ID == id);
            return talk;
        }

        public void CreateTalk(Talk e)
        {
            ctx.Events.Add(e);
            ctx.SaveChanges();
        }

        public void UpdateTalk(Talk e)
        {
            ctx.Entry(e).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Remove(Talk e)
        {
            ctx.Events.Remove(e);
            ctx.SaveChanges();

        }
    }
}
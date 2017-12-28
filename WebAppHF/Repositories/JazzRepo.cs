using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class JazzRepo : IJazzRepo
    {
        public List<Jazz> GetAll()
        {
            IEnumerable<Jazz> Jazzs;
            using (HFContext context = new HFContext())
            {
                Jazzs = context.Jazzs.AsEnumerable();
                return Jazzs.ToList();
            }
        }

        public List<JazzDaySummary> GetDaySummarys()
        {
            IEnumerable<Jazz> jazzs;
            List<JazzDaySummary> summarys = new List<JazzDaySummary>();
            using (HFContext context = new HFContext())
            {
                jazzs = context.Jazzs.AsEnumerable();
                
                //JazzDaySummary summary = ;
                DateTime day;

                jazzs = jazzs.Reverse();
                day = (jazzs.First()).Date;

                foreach(Jazz jazz in jazzs)
                {
                    if(day == jazz.Date)
                    {
                   //     summary
                    }
                }

                return summarys;
            }
        }

        public List<Jazz> GetJazzsByDay(DateTime date)
        {
            IEnumerable<Jazz> Jazzs;
            using (HFContext context = new HFContext())
            {
                Jazzs = context.Jazzs.Where(j => j.Date == date);
                return Jazzs.ToList();
            }
        }

        public Jazz GetJazzByID(int ID)
        {
            Jazz jazz;
            using (HFContext context = new HFContext())
            {
                jazz = context.Jazzs.SingleOrDefault(j => j.ID == ID);
                return jazz;
            }
        }
    }
}
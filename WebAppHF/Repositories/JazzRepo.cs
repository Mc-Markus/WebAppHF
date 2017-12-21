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

                day = (jazzs.First()).Date;

                jazzs = jazzs.Reverse();

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
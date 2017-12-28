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
            List<Jazz> jazzList;
            List<JazzDaySummary> summarys = new List<JazzDaySummary>();
            using (HFContext context = new HFContext())
            {
                jazzs = context.Jazzs.AsEnumerable();
                jazzs.OrderBy(j => j.Date);
                jazzList = jazzs.ToList();

                if(jazzs== null)
                {
                    return null;
                }

                jazzList = RemovePassPartout(jazzList);
                
                DateTime day;
                day = jazzList.Last().Date;

                foreach(Jazz jazz in jazzList)
                {
                    if (day != jazz.Date)
                    {
                        day = jazz.Date;
                        summarys.Add(new JazzDaySummary(jazz.IMGString, jazz.Date.DayOfWeek.ToString(),jazz.Date, jazz.LocationName, jazz.Band ));
                    }
                    else
                    {
                        summarys.Last().AddBand(jazz.Band);
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

                Jazzs.OrderBy(j => j.StartTime);
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

        private List<Jazz> RemovePassPartout(List<Jazz> list)
        {
            List<Jazz> newList = new List<Jazz>();

            foreach(Jazz jazz in list)
            {
                if (!jazz.Band.ToLower().Contains("pass-partout"))
                {
                    newList.Add(jazz);
                }
            }

            return newList;
        }
    }
}
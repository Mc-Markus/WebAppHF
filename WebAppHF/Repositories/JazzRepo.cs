using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class JazzRepo : IJazzRepo
    {

        //gets all jazz events
        public List<Jazz> GetAll()
        {
            IEnumerable<Jazz> Jazzs;
            using (HFContext context = new HFContext())
            {
                Jazzs = context.Jazzs.AsEnumerable();
                return Jazzs.ToList();
            }
        }

        //gets the summarys of what jazzs play on a day
        public List<JazzDaySummary> GetDaySummarys()
        {
            IEnumerable<Jazz> jazzs;
            List<Jazz> jazzList;
            List<JazzDaySummary> summarys = new List<JazzDaySummary>();
            using (HFContext context = new HFContext())
            {
                jazzs = context.Jazzs.AsEnumerable();
                jazzs.OrderBy(j =>j.Date);
                jazzList = jazzs.ToList();

                if(jazzs== null)
                {
                    return null;
                }
                
                //pass-partout's are not needed
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

        //gets all jazz events for a given day
        /*Because a deleted event or events in three halls at the same day can cause problems with
         filtering in two columns they are not filtered in two columns*/
        public List<Jazz> GetJazzsByDay(DateTime date)
        {
            IEnumerable<Jazz> Jazzs;
            using (HFContext context = new HFContext())
            {
                Jazzs = context.Jazzs.Where(j => j.Date == date).OrderBy(j=>j.StartTime);
                return RemovePassPartout(Jazzs.ToList());
            }
        }

        //gets one jazz event according to an id
        public Jazz GetJazzByID(int ID)
        {
            Jazz jazz;
            using (HFContext context = new HFContext())
            {
                jazz = context.Jazzs.SingleOrDefault(j => j.ID == ID);
                return jazz;
            }
        }


        //removes pass-partout from results as they may not be needed in all cases
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
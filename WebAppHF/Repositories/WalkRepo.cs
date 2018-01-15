using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class WalkRepo : IWalkRepo
    {
        public Tour GetWalkByID(int Id)
        {
            using (HFContext context = new HFContext())
            {
                Tour tour = context.Tours.SingleOrDefault(t => t.ID == Id);
                return tour;
            }
        }
        
        public List<Tour> GetAll()
        {
            IEnumerable<Tour> Tours;
            using (HFContext context = new HFContext())
            {
                Tours = context.Tours.AsEnumerable();

                if(Tours == null)
                {
                    Console.WriteLine("empty");
                }
                return Tours.ToList();
            }
        }

    }
}
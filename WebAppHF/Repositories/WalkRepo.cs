﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class WalkRepo : IWalkRepo
    {
        public Tour GetWalkByID(int Id)
        {
            Tour tour;

            using (HFContext context = new HFContext())
            {
                tour = context.Tours.SingleOrDefault(t => t.ID == Id);
                return tour;
            }
                
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public interface IResetaurantRepo
    {
        Restaurant GetRestaurantByID(int ID);
        IEnumerable<Restaurant> GetAllRestaurants();
    }
}
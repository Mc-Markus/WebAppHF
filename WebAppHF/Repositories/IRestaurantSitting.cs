using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    interface IRestaurantSitting 
    {
        RestaurantSitting GetRestaurantSessionByID(int ID);
        Event GetEventID(int ResID, DateTime date, DateTime startingtime);
        IEnumerable<RestaurantSitting> Events();
    }
}

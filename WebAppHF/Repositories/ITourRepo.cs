using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    interface ITourRepo
    {
        Tour GetWalkByID(int Id);
        List<Tour> GetAll();
        List<List<OrderTourViewModel>> GetTourViewModels();
        void CreateTour(Tour walk);
        void UpdateTour(Tour tour);
        void Remove(Tour e);
    }
}

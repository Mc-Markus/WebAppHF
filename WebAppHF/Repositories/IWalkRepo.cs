using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    interface IWalkRepo
    {
        Tour GetWalkByID(int Id);
        List<Tour> GetAll();
    }
}

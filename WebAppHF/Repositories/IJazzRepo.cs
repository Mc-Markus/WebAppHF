using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    interface IJazzRepo
    {
        List<Jazz> GetAll();
        Jazz GetJazzByID(int ID);
        List<Jazz> GetJazzsByDay(DateTime date);
        List<JazzDaySummary> GetDaySummarys();
    }
}

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
        List<Jazz> GetJazzActsByDay(DateTime date);
        Jazz GetPassePartoutWeekend();
        Jazz GetPassePartoutDay(DateTime date);
        List<JazzDaySummary> GetDaySummarys();
        void CreateJazz(Jazz e);
        void UpdateJazz(Jazz e);
        void Remove(Jazz e);
    }
}

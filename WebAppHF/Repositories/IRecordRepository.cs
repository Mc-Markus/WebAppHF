using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    interface IRecordRepository
    {
        int GetEventID(int ResID, DateTime date, DateTime startingtime);
        IEnumerable<Record> GetAllRestaurants();
        void AddRecord(Record record);
    }
}

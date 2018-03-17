using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    interface IRecordRepo
    {
        IEnumerable<OrderItem> GetAllRecords();
        void AddRecord(OrderItem record);
    }
}

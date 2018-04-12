using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RecordRepo : IRecordRepo
    {
        private HFContext database = new HFContext();

        // Get all Records 
        public IEnumerable<OrderItem> GetAllRecords()
        {
            IEnumerable<OrderItem> records = database.OrderItems.ToList();
            return records;
        }


        public void AddRecord(OrderItem record)
        {
            database.OrderItems.Add(record);
            database.SaveChanges();
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private HFContext database = new HFContext();

        // Get all Records 
        public IEnumerable<OrderItem> GetAllRestaurants()
        {
            IEnumerable<OrderItem> records = database.Records.ToList();
            return records;
        }


        public void AddRecord(OrderItem record)
        {
            database.Records.Add(record);
            database.SaveChanges();
        }



    }
}
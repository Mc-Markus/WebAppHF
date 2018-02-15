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
        public IEnumerable<Record> GetAllRestaurants()
        {
            IEnumerable<Record> records = database.Records.ToList();
            return records;
        }


        public void AddRecord(Record record)
        {
            database.Records.Add(record);
            database.SaveChanges();
        }



    }
}
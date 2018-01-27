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

        // Get Event ID 
        public int GetEventID(int ResID, DateTime date, DateTime startingtime)
        {
            int EventId = database.RestaurantSessions.Where(m => m.Date == date 
            && m.RestaurantID == ResID 
            && m.StartTime == startingtime)
            .Select(m => m.ID).SingleOrDefault();
            return EventId;
        }

        public void AddRecord(Record record)
        {
            database.Records.Add(record);
            database.SaveChanges();
        }



    }
}
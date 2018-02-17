using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class OrderTourViewModel
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public List<string> LanguageList { get; set; }
        public List<string> GuidenameList { get; set; }
        public Record NormalTicketRecord { get; set; }
        public Record FamilyTicketRecord { get; set; }

        public OrderTourViewModel()
        {
                
        }

        public OrderTourViewModel(DateTime date, DateTime startTime, string language, string guidename, Record normalRecord, Record familyRecord)
        {
            LanguageList = new List<string>(); 
            GuidenameList = new List<string>();
            this.Date = date;
            this.StartTime = startTime;
            LanguageList.Add(language);
            GuidenameList.Add(guidename);
            this.NormalTicketRecord = normalRecord;
            this.FamilyTicketRecord = familyRecord;
        }
    }
}
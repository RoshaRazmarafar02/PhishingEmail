using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhishingPlatform.Models
{
    public class PhishingInteractionsModel
    {
        public int SubmittedCount { get; set; }
        public int PendingCount { get; set; }
        public int VisitedCount { get; set; }
        public int NotVisitedCount { get; set; }
        public int TotalSendEmailCount { get; set; }

        public int WebsiteID { get; set; }
        public int Count { get; set; }
    }
}
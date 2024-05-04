using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhishingPlatform.Models
{
    public class WebsiteModel
    {
        public string WebsiteName { get; set; }
        public string URL { get; set; }
        public string StringCode { get; set; }
        public int WebID { get; set; } 
    }
}

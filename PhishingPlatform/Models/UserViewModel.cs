using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhishingPlatform.Models
{
    public class UserViewModel
    {
        public List<UsersModel> Users { get; set; }
        public UsersModel NewUser { get; set; }
        public string SelectedEmail { get; set; }
        public string selectedTemplate { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PhishingPlatform.Models
{
    public class TemplateEmail
    {
        public int EmailID { get; set; }
        public string TemplateName { get; set; }
        public int WebsiteID { get; set; }

        [Required(ErrorMessage = "Please provide email body content.")]
        [AllowHtml]
        public string Content { get; set; }

        public string Subject { get; set; }
        [AllowHtml]
        public string FullEmail { get; set; }
    }
}

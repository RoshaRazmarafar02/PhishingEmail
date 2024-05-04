using PhishingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using MimeKit;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using System.Diagnostics;



namespace PhishingPlatform.Controllers
{
    public class PhishingController : Controller
    {

        string CONNECTION_STRING = "Data Source = localhost\\MSSQLSERVER01;Initial Catalog = PhishingPlatformDB; Integrated Security = True";
        public SqlConnection openConnection()
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            return con;
        }


        public ActionResult Templates()
        {
            List<SelectListItem> websiteData = GetWebsiteData();
            ViewBag.WebsiteData = new SelectList(websiteData, "Value", "Text");

            // Assuming you have the StringCode for the selected website (e.g., the first one)
            ViewBag.StringCode = GetWebsiteStringCode(websiteData.FirstOrDefault()?.Value);

            return View();
        }

        private string GetWebsiteStringCode(string websiteId)
        {
            using (var con = openConnection()) // Assuming you have a method named openConnection
            {
                using (var cmd = new SqlCommand("SELECT [StringCode] FROM [PhishingWebsites] WHERE [WebsiteID] = @WebsiteID", con))
                {
                    cmd.Parameters.AddWithValue("@WebsiteID", websiteId);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    var result = cmd.ExecuteScalar();

                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }

        [HttpGet]
        public ActionResult GetWebsiteStringCode(int websiteId)
        {
            var stringCode = GetWebsiteStringCode(websiteId.ToString());
            return Content(stringCode);
        }


        private List<SelectListItem> GetWebsiteData()
        {
            List<SelectListItem> websites = new List<SelectListItem>();
            using (var con = openConnection())
            {
                using (var cmd = new SqlCommand("SELECT [WebsiteName], [WebsiteID], [StringCode] FROM [PhishingWebsites]", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            websites.Add(new SelectListItem
                            {
                                Text = reader["WebsiteName"].ToString(),
                                Value = reader["WebsiteID"].ToString(),
                            });
                        }
                    }
                }
            }

            return websites;
        }

        private string GetCategoryName(int WebID)
        {
            switch (WebID)
            {
                case 1:
                    return "Google";
                case 2:
                    return "Netflix";
                case 3:
                    return "Mubis";
                default:
                    return "Unknown";
            }
        }

        [HttpPost]
        public ActionResult SubmitTemplate(TemplateEmail template)
        {
            if (ModelState.IsValid)
            {
                template.TemplateName = $"{GetCategoryName(template.WebsiteID)}, {template.Subject}";
                using (var con = openConnection())
                {
                    using (var cmd = new SqlCommand("INSERT INTO PhishingEmails (TemplateName, WebsiteID, Content, Subject, FullEmail) VALUES (@TemplateName, @WebsiteID, @Content, @Subject, @FullEmail)", con))
                    {
                        cmd.Parameters.AddWithValue("@TemplateName", template.TemplateName);
                        cmd.Parameters.AddWithValue("@WebsiteID", template.WebsiteID);
                        cmd.Parameters.AddWithValue("@Content", template.Content);
                        cmd.Parameters.AddWithValue("@Subject", template.Subject);
                        cmd.Parameters.AddWithValue("@FullEmail", template.FullEmail);

                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("Templates");
            }

            return View("Templates", template);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel usertmep)
        {

            Console.WriteLine($"Received email: {usertmep.NewUser.Email}");
            if (ModelState.IsValid)
            {
                using (var con = openConnection())
                {
                    using (var cmd = new SqlCommand("INSERT INTO Users (Email) VALUES (@Email)", con))
                    {
                        // Use AddWithValue to add the parameter and set its value
                        cmd.Parameters.AddWithValue("@Email", usertmep.NewUser.Email);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }

                    // Close the connection after executing the query
                    con.Close();



                }

                return RedirectToAction("UserTest");
            }

            return View("UserTest", usertmep);
        }


        private List<SelectListItem> GetEmailTemplates()
        {
            List<SelectListItem> EmailTemps = new List<SelectListItem>();

            // Wrap the database-related code in a using statement
            using (var con = openConnection())
            {
                // The connection will be automatically closed when leaving this block
                using (var cmd = new SqlCommand("SELECT [TemplateName], [EmailID], [FullEmail] FROM [PhishingEmails]", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmailTemps.Add(new SelectListItem
                            {
                                Text = reader["TemplateName"].ToString(),
                                Value = reader["EmailID"].ToString(),
                            });
                        }
                    }
                }
            }

            return EmailTemps;
        }

        private string GetEmailStringCode(string emailId)
        {
            using (var con = openConnection()) // Assuming you have a method named openConnection
            {
                using (var cmd = new SqlCommand("SELECT [FullEmail] FROM [PhishingEmails] WHERE [EmailID] = @EmailID", con))
                {
                    cmd.Parameters.AddWithValue("@EmailID", emailId);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    var result = cmd.ExecuteScalar();

                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }

        [HttpGet]
        public ActionResult GetEmailStringCode(int emailId)
        {
            var EmailCode = GetEmailStringCode(emailId.ToString());
            return Content(EmailCode);
        }

        public ActionResult UserTest()
        {
            UserViewModel viewModel = new UserViewModel
            {
                Users = GetUserListFromDatabase(),
                NewUser = new UsersModel()
            };

            List<SelectListItem> emailTemps = GetEmailTemplates();
            ViewBag.EmailTemps = new SelectList(emailTemps, "Value", "Text");
            ViewBag.EmailCode = GetEmailStringCode(emailTemps.FirstOrDefault()?.Value);

            return View(viewModel);
        }


        private List<UsersModel> GetUserListFromDatabase()
        {
            List<UsersModel> users = new List<UsersModel>();

            using (var con = openConnection())
            {
                using (var cmd = new SqlCommand("SELECT [UserID], [Email] FROM [Users]", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsersModel user = new UsersModel
                            {
                                UserID = reader["UserID"].ToString(),
                                Email = reader["Email"].ToString()
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public string GetSubjectByEmailID(int emailID)
        {
            string subject = string.Empty;

            using (SqlConnection connection = openConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT [Subject] FROM [dbo].[PhishingEmails] WHERE [EmailID] = @EmailID", connection))
                {
                    command.Parameters.AddWithValue("@EmailID", emailID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            subject = reader["Subject"].ToString();
                        }
                    }
                }
            }

            return subject;
        }

        public string GetWebsiteNameByEmailID(int emailID)
        {
            string websiteName = string.Empty;

            using (SqlConnection connection = openConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT PWE.[WebsiteName] " +
                                                           "FROM [dbo].[PhishingEmails] PE " +
                                                           "JOIN [dbo].[PhishingWebsites] PWE ON PE.[WebsiteID] = PWE.[WebsiteID] " +
                                                           "WHERE PE.[EmailID] = @EmailID", connection))
                {
                    command.Parameters.AddWithValue("@EmailID", emailID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            websiteName = reader["WebsiteName"].ToString();
                        }
                    }
                }
            }

            return websiteName;
        }
        public string GetUserIdByEmail(string emailadd)
        {
            string UserId = string.Empty;

            using (SqlConnection con = openConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [UserID] FROM [Users] where Email = @Email", con))
                {
                    cmd.Parameters.AddWithValue("@Email", emailadd);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserId = reader["UserID"].ToString();
                        }
                    }
                }
            }
            return UserId;
        }

        private void InsertReceivedEmail(int tempID, string userID, int formID)
        {
            try
            {
                using (SqlConnection connection = openConnection())
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[ReceivedEmails] ([EmailID], [UserID], [Status], [ReceivedDate], [FormID]) " +
                                                               "VALUES (@EmailID, @UserID, @Status, @ReceivedDate, @FormID)", connection))
                    {
                        command.Parameters.AddWithValue("@EmailID", tempID);
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@Status", "Sent");
                        command.Parameters.AddWithValue("@ReceivedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@FormID", formID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into ReceivedEmails table: {ex.Message}");
            }
        }

        private bool IsRandomVarExists(int randomVar)
        {
            // SQL query to check if the randomVar exists in the FormID column
            string query = "SELECT COUNT(*) FROM [PhishingPlatformDB].[dbo].[ReceivedEmails] WHERE FormID = @RandomVar";

            using (SqlConnection con = openConnection())
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Add parameter to the query to prevent SQL injection
                    command.Parameters.AddWithValue("@RandomVar", randomVar);

                    // Execute the query and check if the count is greater than 0
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail(UserViewModel viewModel)
        {
            Debug.WriteLine($"Selected template:  {viewModel.selectedTemplate}");
            Debug.WriteLine($"Selected email: {viewModel.SelectedEmail}");


            string emailadd = viewModel.SelectedEmail;
            int tempID = Convert.ToInt32(viewModel.selectedTemplate);
            string ID = GetUserIdByEmail(emailadd);
            string sub = GetSubjectByEmailID(tempID);
            string senderName = GetWebsiteNameByEmailID(Convert.ToInt32(ID));
            Random random = new Random();
            int randomVar;

            do
            {
                randomVar = random.Next(10000, 99999);
            } while (IsRandomVarExists(randomVar));

            Debug.WriteLine($"Selected tempID: {tempID}, Selected ID: {ID}, Selected sub: {sub}, Selected randomVar: {randomVar}");

            try
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress(senderName, "rosharazmarafar@gmail.com"));
                email.To.Add(new MailboxAddress(viewModel.SelectedEmail, viewModel.SelectedEmail));
                Debug.WriteLine($"Selected email ID: {ID}");
                email.Subject = sub;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = GetEmailStringCode(viewModel.selectedTemplate).Replace("{{USER_ID}}", ID ?? "").Replace("{{Form_Id}}", randomVar.ToString())
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync("rosharazmarafar@gmail.com", "snvj hdqu laqz ccjl");

                    await client.SendAsync(email);
                    await client.DisconnectAsync(true);
                }
                InsertReceivedEmail(tempID, ID, randomVar);
                return RedirectToAction("UserTest");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }

            return RedirectToAction("UserTest");
        }
    }
}
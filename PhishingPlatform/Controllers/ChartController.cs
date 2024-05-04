using PhishingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;



namespace PhishingPlatform.Controllers
{
    public class ChartController : Controller
    {
        private PhishingPlatformDBEntities1 db = new PhishingPlatformDBEntities1(); // Replace with your actual context name

        public ActionResult Dashboard()
        {
            using (var db = new PhishingPlatformDBEntities1())
            {
                // Fetch data from the Entity Data Model
                var interactionData = db.InteractionSummaries.AsNoTracking().ToList();
                PhishingInteractionsModel model = GetPhishingInteractionsCounts();
                ViewBag.InteractionsModel = model;

                List<PhishingInteractionsModel> submissionsCounts = GetSubmissionsCountByWebsite();
                List<PhishingInteractionsModel> visitsCounts = GetVisitsCountByWebsite();

                // Add results to ViewBag
                ViewBag.SubmissionsCounts = submissionsCounts;
                ViewBag.VisitsCounts = visitsCounts;

                // Calculate Submit, Pending, Visited, and Not Visited counts
                ViewBag.SubmitCount = CalculateSubmitCount();
                ViewBag.PendingCount = CalculatePendingCount();
                ViewBag.VisitedCount = CalculateVisitedCount();
                ViewBag.NotVisitedCount = CalculateNotVisitedCount();
                ViewBag.Total = model.VisitedCount + model.NotVisitedCount;
                ViewBag.TotalVisitedRate = Math.Round((double)model.VisitedCount / ViewBag.Total * 100, 2);
                ViewBag.TotalSubmitRate = Math.Round((double)ViewBag.SubmitCount / ViewBag.Total * 100, 2);
                ViewBag.SubmitOverVisit = (model.VisitedCount != 0) ? Math.Round((double)ViewBag.SubmitCount / model.VisitedCount * 100, 2) : 0;


                // Debugging information
                Debug.WriteLine($"SubmitCount: {ViewBag.SubmitCount}");
                Debug.WriteLine($"PendingCount: {ViewBag.PendingCount}");
                Debug.WriteLine($"VisitedCount: {ViewBag.VisitedCount}");
                Debug.WriteLine($"NotVisitedCount: {ViewBag.NotVisitedCount}");
                Debug.WriteLine($"VisitsCounts: {JsonConvert.SerializeObject(ViewBag.VisitsCounts)}");
                Debug.WriteLine($"SubmissionsCounts: {JsonConvert.SerializeObject(ViewBag.SubmissionsCounts)}");


                ModelState.Clear();
                return View(interactionData);
            }
        }

        private string CONNECTION_STRING = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=PhishingPlatformDB;Integrated Security=True";

        public PhishingInteractionsModel GetPhishingInteractionsCounts()
        {
            PhishingInteractionsModel model = new PhishingInteractionsModel();

            using (SqlConnection connection = openConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT [UserEmailID]) AS [Submitted] FROM [PhishingInteractions] WHERE [Submitted] = 1;", connection))
                {
                    model.SubmittedCount = Convert.ToInt32(command.ExecuteScalar());
                }

                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT [UserEmailID]) AS [Pending] FROM [PhishingInteractions] WHERE [Submitted] = 0;", connection))
                {
                    model.PendingCount = Convert.ToInt32(command.ExecuteScalar());
                }

                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT [UserEmailID]) AS [Visited] FROM [PhishingInteractions];", connection))
                {
                    model.VisitedCount = Convert.ToInt32(command.ExecuteScalar());
                }

                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT [UserEmailID]) AS [NotVisited] FROM [ReceivedEmails] WHERE [UserEmailID] NOT IN (SELECT DISTINCT [UserEmailID] FROM [PhishingInteractions]);", connection))
                {
                    model.NotVisitedCount = Convert.ToInt32(command.ExecuteScalar());
                }

                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT [UserEmailID]) AS [TotalSendEmail] FROM [ReceivedEmails];", connection))
                {
                    model.TotalSendEmailCount = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return model;
        }

        public List<PhishingInteractionsModel> GetSubmissionsCountByWebsite()
        {
            List<PhishingInteractionsModel> submissionsCounts = new List<PhishingInteractionsModel>();

            using (SqlConnection connection = openConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT WebsiteID, COUNT(DISTINCT UserEmailID) AS SubmissionsCount FROM PhishingPlatformDB.dbo.PhishingInteractions WHERE Submitted = 1 GROUP BY WebsiteID;", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            submissionsCounts.Add(new PhishingInteractionsModel
                            {
                                WebsiteID = Convert.ToInt32(reader["WebsiteID"]),
                                Count = Convert.ToInt32(reader["SubmissionsCount"])
                            });
                        }
                    }
                }
            }

            return submissionsCounts;
        }

        public List<PhishingInteractionsModel> GetVisitsCountByWebsite()
        {
            List<PhishingInteractionsModel> visitsCounts = new List<PhishingInteractionsModel>();

            using (SqlConnection connection = openConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT WebsiteID, COUNT(DISTINCT UserEmailID) AS VisitsCount FROM PhishingPlatformDB.dbo.PhishingInteractions GROUP BY WebsiteID;", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            visitsCounts.Add(new PhishingInteractionsModel
                            {
                                WebsiteID = Convert.ToInt32(reader["WebsiteID"]),
                                Count = Convert.ToInt32(reader["VisitsCount"])
                            });
                        }
                    }
                }
            }

            return visitsCounts;
        }

        public int CalculateSubmitCount()
        {
            using (SqlConnection connection = openConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT [UserEmailID]) AS [SubmitCount] FROM [PhishingInteractions] WHERE [Submitted] = 1;", connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int CalculatePendingCount()
        {
            using (SqlConnection connection = openConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT [UserEmailID]) AS [PendingCount] FROM [PhishingInteractions] WHERE [Submitted] = 0;", connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int CalculateVisitedCount()
        {
            using (SqlConnection connection = openConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT [UserEmailID]) AS [VisitedCount] FROM [PhishingInteractions];", connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int CalculateNotVisitedCount()
        {
            using (SqlConnection connection = openConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT [UserEmailID]) AS [NotVisitedCount] FROM [ReceivedEmails] WHERE [UserEmailID] NOT IN (SELECT DISTINCT [UserEmailID] FROM [PhishingInteractions]);", connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private SqlConnection openConnection()
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            return con;
        }
    }
}

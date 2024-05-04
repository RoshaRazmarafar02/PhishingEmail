using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhishingPlatform.PhishingEmails
{
    public partial class Mubis : System.Web.UI.Page
    {

        int clickCount = 0;
        int formid; // from the link i can get it
        int userid; // extracted from the link 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clickCount++;
                string fullUrl = Request.Url.AbsoluteUri;
                Debug.WriteLine($"Selected fullUrl: {fullUrl}");

                //https://localhost:44326/PhishingEmails/Googletemp.aspx?user_id=1&form_id=83066
                // Parse the query parameters
                var uri = new Uri(fullUrl);
                var query = HttpUtility.ParseQueryString(uri.Query);

                // Extract form_id and user_id
                if (int.TryParse(query["form_id"], out formid) && int.TryParse(query["user_id"], out userid))
                {
                    Debug.WriteLine($"form_id: {formid}, user_id: {userid}");
                }

                int WebID = GetWebsiteID(formid);
                int UserEmailID = Convert.ToInt32(GetUserEmailID(formid));
                Debug.WriteLine($"webid: {WebID}, UserEmailID: {UserEmailID}, webid: {clickCount}");

                InsertIntercationByFormId(WebID, UserEmailID);
                UpdateWebsiteCount(WebID);
            }


        }
        protected void btnGirisServer_Click(object sender, EventArgs e)
        {
            
             UpdateSubmitStat(formid);

        }


        string CONNECTION_STRING = "Data Source = localhost\\MSSQLSERVER01;Initial Catalog = PhishingPlatformDB; Integrated Security = True";
        public SqlConnection openConnection()
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            return con;
        }

        private void UpdateWebsiteCount(int WebID)
        {
            try
            {
                using (SqlConnection connection = openConnection())
                {
                    using (SqlCommand command = new SqlCommand("UPDATE [dbo].[PhishingWebsites] " +
                                                                "SET [ClickCount] = [ClickCount] + 1 WHERE [WebsiteID] = @WebsiteID", connection))
                    {
                        command.Parameters.AddWithValue("@WebsiteID", WebID);
                        Debug.WriteLine($"Executing SQL command: {command.CommandText}");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data in PhishingWebsites table: {ex.Message}");

                // Log the exception for debugging
                Debug.WriteLine($"Exception details: {ex.StackTrace}");
            }
        }


        private void UpdateSubmitStat(int FormID)
        {
            int UserEmailID = Convert.ToInt32(GetUserEmailID(FormID));
            try
            {
                using (SqlConnection connection = openConnection())
                {
                    using (SqlCommand command = new SqlCommand("Update [dbo].[PhishingInteractions] " +
                        "set [Submitted] = @Submitted", connection))
                    {
                        command.Parameters.AddWithValue("@Submitted", true);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into PhishingWebsites table: {ex.Message}");
            }
        }

        public string GetUserEmailID(int formid)
        {
            string userEmailId = null;
            string query = "SELECT re.[UserEmailID] " +
                           "FROM [PhishingPlatformDB].[dbo].[ReceivedEmails] re " +
                           "WHERE re.[FormID] = @FormID";
            try
            {
                using (SqlConnection connection = openConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FormID", formid);
                        userEmailId = command.ExecuteScalar()?.ToString();
                        Debug.WriteLine($"userEmailId: {userEmailId}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying UserEmailID: {ex.Message}");
            }

            return userEmailId;
        }

        public int GetWebsiteID(int formid)
        {
            int websiteId = -1; // Set a default value or handle the case where the value is not found
            string query = "SELECT pe.[WebsiteID] " +
                   "FROM [PhishingPlatformDB].[dbo].[PhishingEmails] pe " +
                   "JOIN [PhishingPlatformDB].[dbo].[ReceivedEmails] re ON pe.[EmailID] = re.[EmailID] " +
                   "WHERE re.[FormID] = @FormID";
            try
            {
                using (SqlConnection connection = openConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FormID", formid);
                        websiteId = Convert.ToInt32(command.ExecuteScalar());
                        Debug.WriteLine($"websiteId: {websiteId}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying WebsiteID: {ex.Message}");
            }

            return websiteId;
        }


        private void InsertIntercationByFormId(int WebID, int UserEmailID)
        {
            try
            {
                using (SqlConnection connection = openConnection())
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[PhishingInteractions] ([UserEmailID], [WebsiteID], [Clicked], [Submitted], [InteractionDate]) " +
                                                                "VALUES (@UserEmailId, @WebID, @Clicked, @Submitted, @Date)", connection))
                    {
                        // Use the retrieved UserEmailID and WebID values
                        command.Parameters.AddWithValue("@UserEmailId", UserEmailID);
                        command.Parameters.AddWithValue("@WebID", WebID);
                        command.Parameters.AddWithValue("@Clicked", true); // Use boolean value for bit column
                        command.Parameters.AddWithValue("@Submitted", false); // Use boolean value for bit column
                        command.Parameters.AddWithValue("@Date", DateTime.Now);

                        // Log the SQL command for debugging
                        Debug.WriteLine($"Executing SQL command: {command.CommandText}");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into PhishingInteractions table: {ex.Message}");

                // Log the exception details for debugging
                Debug.WriteLine($"Exception details: {ex.StackTrace}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhishingPlatform.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PhishingPlatform.Controllers
{
    public class AdminController : Controller
    {
        string CONNECTION_STRING = "Data Source = localhost\\MSSQLSERVER01;Initial Catalog = PhishingPlatformDB; Integrated Security = True";

        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            Session["IsAdminAuthenticated"] = false;
            return View();
        } 



        public SqlConnection openConnection()
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            return con;
        }


        [HttpPost]
        public ActionResult Verify(Admin admin)
        {
            Session["IsAdminAuthenticated"] = false;
            try
            {
                using (SqlConnection conn = openConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT Email, Password FROM [Admins] WHERE Email = @email AND Password = @pass";

                        cmd.Parameters.AddWithValue("@email", admin.Email);
                        cmd.Parameters.AddWithValue("@pass", admin.Password);

                        cmd.Connection = conn;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                Session["IsAdminAuthenticated"] = true;
                                Session["AdminName"] = admin.Email;
                                conn.Close();
                                return RedirectToAction("Dashboard", "Chart", "Dashboard");
                            }
                        }
                    }
                }

                // If no rows are returned, close the connection and return to the view with an error message
                ViewBag.ErrorMessage = "Invalid email or password";
                return View("Index");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                ViewBag.ErrorMessage = "An error occurred while processing your request";
                return View("Index");
            }
        }

        public ActionResult Signup() 
        {
            Session["IsAdminAuthenticated"] = false;
            return View();
        }

        [HttpPost]
        public ActionResult Inserting(Admin admin)
        {
            Session["IsAdminAuthenticated"] = false;

            if (admin.Password == admin.PasswordRepeat)
            {
                try
                {
                    using (SqlConnection conn = openConnection())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "INSERT INTO [Admins] ([FullName], [Email], [Password]) VALUES (@FName, @email, @Pass)";

                            cmd.Parameters.AddWithValue("@FName", admin.FullName);
                            cmd.Parameters.AddWithValue("@email", admin.Email);
                            cmd.Parameters.AddWithValue("@pass", admin.Password);

                            cmd.Connection = conn;

                            // Use ExecuteNonQuery for INSERT operation
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Session["IsAdminAuthenticated"] = true;
                                Session["AdminName"] = admin.Email;
                                conn.Close();
                                return RedirectToAction("Dashboard", "Chart", "Dashboard");
                            }
                        }
                    }

                    // If no rows are affected, close the connection and return to the view with an error message
                    ViewBag.ErrorMessage = "Failed to insert admin";
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    ViewBag.ErrorMessage = "An error occurred while processing your request";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Passwords do not match";
            }

            return View("Signup");
        }

    }
}
//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Auth
{
    //[RequireAuth]
    [BindProperties]
    public class LoginModel : PageModel
    {
        [Required(ErrorMessage = "The Email is required"), EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = "";

        public string errorMessage = "";
        public string successMessage = "";



        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Data validation failed";
                return;
            }

            // successfull data validation

            // connect to database and check the user credentials
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM users WHERE email=@email";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", Email);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string firstname = reader.GetString(1);
                                string lastname = reader.GetString(2);
                                string email = reader.GetString(3);
                                string phone = reader.GetString(4);
                                string hashedPassword = reader.GetString(5);
                                string role = reader.GetString(6);
                                string created_at = reader.GetDateTime(7).ToString("MM/dd/yyyy");

                                // verify the password
                                var passwordHasher = new PasswordHasher<IdentityUser>();
                                var result = passwordHasher.VerifyHashedPassword(new IdentityUser(),
                                    hashedPassword, Password);

                                if (result == PasswordVerificationResult.Success
                                    || result == PasswordVerificationResult.SuccessRehashNeeded)
                                {
                                    // successful password verification => initialize the session
                                    HttpContext.Session.SetInt32("id", id);
                                    HttpContext.Session.SetString("firstname", firstname);
                                    HttpContext.Session.SetString("lastname", lastname);
                                    HttpContext.Session.SetString("email", email);
                                    HttpContext.Session.SetString("phone", phone);
                                    HttpContext.Session.SetString("role", role);
                                    HttpContext.Session.SetString("created_at", created_at);

                                    // the user is authenticated successfully => redirect to the home page
                                    Response.Redirect("/");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            // Wrong Email or Password
            errorMessage = "Wrong Email or Password";
        }
    }
}

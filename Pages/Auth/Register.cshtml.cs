//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Net;

namespace HRMSApplication.Pages.Auth
{
    //[RequireNoAuth]
    [BindProperties]
    public class RegisterModel : PageModel
    {

        [Required(ErrorMessage = "The First Name is required")]
        public string Firstname { get; set; } = "";

        [Required(ErrorMessage = "The Last Name is required")]
        public string Lastname { get; set; } = "";

        [Required(ErrorMessage = "The Email is required"), EmailAddress]
        public string Email { get; set; } = "";

        public string? Phone { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password must be between 5 and 50 characters", MinimumLength = 5)]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; } = "";


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
            if (Phone == null) Phone = "";

            // add the user details to the database
            string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO users " +
                    "(firstname, lastname, email, phone, password, role) VALUES " +
                    "(@firstname, @lastname, @email, @phone, @password, 'client');";

                    var passwordHasher = new PasswordHasher<IdentityUser>();
                    string hashedPassword = passwordHasher.HashPassword(new IdentityUser(), Password);

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@firstname", Firstname);
                        command.Parameters.AddWithValue("@lastname", Lastname);
                        command.Parameters.AddWithValue("@email", Email);
                        command.Parameters.AddWithValue("@phone", Phone);
                        command.Parameters.AddWithValue("@password", hashedPassword);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(Email))
                {
                    errorMessage = "Email address already used";
                }
                else
                {
                    errorMessage = ex.Message;
                }

                return;
            }

			// initialize the authenticated session => add the user details to the session data
			try
			{
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
								//string hashedPassword = reader.GetString(5);
								string role = reader.GetString(6);
								string created_at = reader.GetDateTime(7).ToString("MM/dd/yyyy");

								HttpContext.Session.SetInt32("id", id);
								HttpContext.Session.SetString("firstname", firstname);
								HttpContext.Session.SetString("lastname", lastname);
								HttpContext.Session.SetString("email", email);
								HttpContext.Session.SetString("phone", phone);
								HttpContext.Session.SetString("role", role);
								HttpContext.Session.SetString("created_at", created_at);
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

			successMessage = "Account created successfully";
			// redirect to the home page
			Response.Redirect("/");
		}
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Setup.Units
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Code { get; set; } = "";
        [BindProperty]
        [Required]
        public string Section { get; set; } = "";
        [BindProperty]
		[Required]
		public string Description { get; set; } = "";

		public string errorMessage = "";
		public string successMessage = "";

		public void OnGet()
        {
        }
        public void OnPost()
		{

            try 
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO HPaySection" +
                        "(Code, Section , Description ) VALUES " + "(@Code, @Section, @Description);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("Code", Code);
                        command.Parameters.AddWithValue("Section", Section);
                        command.Parameters.AddWithValue("Description", Description);

                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
				errorMessage = ex.Message;
				return;
			}
			successMessage = "Data saved correctly";
			Response.Redirect("/Setup/Units/Index");
		}
    }
}

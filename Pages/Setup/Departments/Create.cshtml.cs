using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Setup.Departments
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Code { get; set; } = "";
        [BindProperty]
        [Required]
        public string Name { get; set; } = "";
        [BindProperty]
		[Required]
		public string Remark { get; set; } = "";

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
                    string sql = "INSERT INTO HPayDept" +
                        "(Code, Name , Remark ) VALUES " + "(@Code, @Name, @Remark);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("Code", Code);
                        command.Parameters.AddWithValue("Name", Name);
                        command.Parameters.AddWithValue("Remark", Remark);

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
			Response.Redirect("/Setup/Departments/Index");
		}
    }
}

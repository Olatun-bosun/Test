using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Setup.Grades
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        
        public string StaffGrpID { get; set; } = "";
        [BindProperty]
        [Required]
        public string Name { get; set; } = "";
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
                    string sql = "INSERT INTO HPayGrade" +
                        "(StaffGrpID, Name , Description ) VALUES " + "(@StaffGrpID, @Name, @Description);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("StaffGrpID", StaffGrpID);
                        command.Parameters.AddWithValue("Name", Name);
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
			Response.Redirect("/Setup/Grades/Index");
		}
    }
}

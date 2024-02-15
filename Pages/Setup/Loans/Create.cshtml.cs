using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Setup.Loans
{
    public class CreateModel : PageModel
    {
        
        [BindProperty]
        [Required]
        public string LoanType { get; set; } = "";
		[BindProperty]
		[Required]
		public string LoanRate { get; set; } = "";
		[BindProperty]
		[Required]
		public string Remarks { get; set; } = "";

		public string errorMessage = "";
		public string successMessage = "";

		public void OnGet()
        {
        }
        public void OnPost()
		{
			if (Remarks == null) Remarks = "";

			try 
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO LoanType" +
                        "( LoanType, LoanRate, Remarks ) VALUES " + "(@LoanType, @LoanRate, @Remarks);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("LoanType", LoanType);
						command.Parameters.AddWithValue("LoanRate", LoanRate);
						command.Parameters.AddWithValue("Remarks", Remarks);


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
			Response.Redirect("/Setup/Loans/Index");
		}
    }
}

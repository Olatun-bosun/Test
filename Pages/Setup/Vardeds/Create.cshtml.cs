using HRMSApplication.Setup.Varalls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HRMSApplication.Pages.Setup.Vardeds
{
    

    public class CreateModel : PageModel
    {


        public void OnGet()
        {
            
        }
        [BindProperty]
        [Required]
        public string DedName { get; set; } = "";
        [BindProperty]
		[Required]
		public int Value2 { get; set; }
		[BindProperty]
		[Required]
		public string Description { get; set; } = "";
       

        public string errorMessage = "";
		public string successMessage = "";

		//public void OnGet()
  //      {
  //      }

        public void OnPost()
		{

			if (Description == null) Description = "";

			try 
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO VPayDeductions" +
                        "(DedName, Value2, Description ) VALUES " + "(@DedName, @Value2, @Description);";
                   
                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
						command.Parameters.AddWithValue("DedName", DedName);

						command.Parameters.AddWithValue("Value2", Value2);
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
			Response.Redirect("/Setup/Vardeds/Index");
		}
    }
    
}

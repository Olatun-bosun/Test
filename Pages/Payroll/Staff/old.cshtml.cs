using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Payroll.Staff
{
    public class oldModel : PageModel
    {
                
            
		[BindProperty]
		
		public int EmployeeID { get; set; }
		[BindProperty]
		
		public string Surname { get; set; } = "";
		[BindProperty]
		
		public string OtherNames { get; set; } = "";
		[BindProperty]
		
		public int Basic { get; set; }
		[BindProperty]
		
		public int Housing { get; set; }
		[BindProperty]
		
		public int Transport { get; set; }
		[BindProperty]
		
		public string Step { get; set; } = "";
		[BindProperty]
		
		public string Grade { get; set; } = "";


		public string errorMessage = "";
		public string successMessage = "";
		public void OnGet()
        {
			string requestId = Request.Query["EmployeeID"];

			try
			{
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";

                using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = "SELECT * FROM PaySlips WHERE EmployeeID=@EmployeeID";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@EmployeeID", requestId);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							
								EmployeeID = reader.GetInt32(0);
								Surname = reader.GetString(1);
								OtherNames = reader.GetString(2);
								Basic = reader.GetInt32(3);
								Housing = reader.GetInt32(4);
								Transport = reader.GetInt32(5);
								Step = reader.GetString(6);
								Grade = reader.GetString(7);
							
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				
			}
		}
		public void OnPost()
		{
			if (!ModelState.IsValid)
			{
				errorMessage = "Data validation failed";
				return;
			}

			// successfull data validation
			try
			{
				string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string sql = "UPDATE PaySlips SET EmployeeID=@EmployeeID, Surname=@Surname, OtherNames=@OtherNames, Basic=@Basic, Housing=@Housing, Transport=@Transport, Step=@Step, Grade=@Grade  ;";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("EmployeeID", EmployeeID);
						command.Parameters.AddWithValue("Surname", Surname);
						command.Parameters.AddWithValue("OtherNames", OtherNames);
						command.Parameters.AddWithValue("Basic", Basic);
						command.Parameters.AddWithValue("Housing", Housing);
						command.Parameters.AddWithValue("Transport", Transport);
						command.Parameters.AddWithValue("Step", Step);
						command.Parameters.AddWithValue("Grade", Grade);



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
			Response.Redirect("/Admin/Employees/Index");
		
	
        }
    }
}

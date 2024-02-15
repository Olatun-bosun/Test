using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;

namespace HRMSApplication.Pages.Payroll.Staff
{
    public class EditModel : PageModel
    {
      

        [BindProperty]

        public int ID { get; set; }
        [BindProperty]

        public int SheetID { get; set; }
        [BindProperty]

		public string EmployeeID { get; set; } = "";
		[BindProperty]
		
		public string Surname { get; set; } = "";
		[BindProperty]
		
		public string OtherNames { get; set; } = "";
        //[BindProperty]

        //public string Period { get; set; } = "";
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

			string requestId = Request.Query["ID"];

			try
			{
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";

                using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = "SELECT * FROM PaySlips WHERE ID=@ID  ORDER BY Period ASC";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@ID", requestId);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
                                ID = reader.GetInt32(0);
                                SheetID = reader.GetInt32(1);
                                EmployeeID = reader.GetString(2);
								Surname = reader.GetString(3);
								OtherNames = reader.GetString(4);
                                //Period = reader.GetString(5);
                                Basic = reader.GetInt32(6);
								Housing = reader.GetInt32(7);
								Transport = reader.GetInt32(8);
                                Step = reader.GetString(97);
                                Grade = reader.GetString(99);



                            }
                            else
							{
								Response.Redirect("/Payroll/Index");
							}
                           

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
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string sql = "UPDATE PaySlips SET EmployeeID=@EmployeeID, Surname=@Surname, OtherNames=@OtherNames, Basic=@Basic, Housing=@Housing, Transport=@Transport, Step=@Step, Grade=@Grade  ;";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
                        command.Parameters.AddWithValue("ID", ID);
                        command.Parameters.AddWithValue("ID", SheetID);
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

using HRMSApplication.Setup.Varalls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HRMSApplication.Pages.Setup.Varalls
{
    

    public class CreateModel : PageModel
    {


        public List<Varallinfo> listVaralls = new List<Varallinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM VPayAllowance ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Varallinfo varallinfo = new Varallinfo();
                                varallinfo.AllowID = reader.GetInt32(0);
                                varallinfo.AllowName = reader.GetString(1);
                                varallinfo.Value1 = reader.GetInt32(2);



                                listVaralls.Add(varallinfo);



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
        [BindProperty]
        [Required]
        public string AllowName { get; set; } = "";
        [BindProperty]
		[Required]
		public int Value1 { get; set; }
		[BindProperty]
		[Required]
		public string Descrption { get; set; } = "";
       

        public string errorMessage = "";
		public string successMessage = "";

		//public void OnGet()
  //      {
  //      }

        public void OnPost()
		{

			if (Descrption == null) Descrption = "";

			try 
            {
                        
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO VPayAllowance" +
                        "(AllowName, Value1, Descrption ) VALUES " + "(@AllowName, @Value1, @Descrption);";
                   
                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
						command.Parameters.AddWithValue("AllowName", AllowName);

						command.Parameters.AddWithValue("Value1", Value1);
                        command.Parameters.AddWithValue("Descrption", Descrption);


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
			Response.Redirect("/Setup/Varalls/Index");
		}
    }
    public class Varallinfo
    {
        public int AllowID { get; set; }
        public string AllowName { get; set; } = "";
        public int Value1 { get; set; }






    }
}

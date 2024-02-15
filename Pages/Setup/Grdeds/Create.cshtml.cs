using HRMSApplication.Setup.Grades;
using HRMSApplication.Setup.Steps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Pages.Setup.Grdeds
{
    public class CreateModel : PageModel
    {
        public List<Gradeinfo> listGrades = new List<Gradeinfo>();
        public List<Stepinfo> listSteps = new List<Stepinfo>();
        public List<Maindedinfo> listMaindeds = new List<Maindedinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM GradeLevel ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Gradeinfo gradeinfo = new Gradeinfo();
                                gradeinfo.ID = reader.GetInt32(0);
                                gradeinfo.GradeName = reader.GetString(1);



                                listGrades.Add(gradeinfo);



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM HRSteps ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Stepinfo stepinfo = new Stepinfo();
                                stepinfo.ID = reader.GetInt32(0);
                                stepinfo.Name = reader.GetString(1);



                                listSteps.Add(stepinfo);



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM DeductionID ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Maindedinfo maindedinfo = new Maindedinfo();
                                maindedinfo.DedID = reader.GetInt64(0);
                                maindedinfo.DedName = reader.GetString(1);



                                listMaindeds.Add(maindedinfo);



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
        public string DedName { get; set; } = "";
        [BindProperty]
		[Required]
		public int Value1 { get; set; }
		[BindProperty]
		[Required]
		public string Steps { get; set; } = "";
        [BindProperty]
        [Required]
        public string Grade { get; set; } = "";

        public string errorMessage = "";
		public string successMessage = "";

		//public void OnGet()
  //      {
  //      }
        public void OnPost()
		{
			//if (Descrption == null) Descrption = "";

			try 
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO HPayDeductions" +
                        "(DedName, Value1, Steps, Grade ) VALUES " + "(@DedName, @Value1, @Steps, @Grade);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
						command.Parameters.AddWithValue("DedName", DedName);

						command.Parameters.AddWithValue("Value1", Value1);
                        command.Parameters.AddWithValue("Steps", Steps);
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
			Response.Redirect("/Setup/Grdeds/Index");
		}
    }
    public class Maindedinfo
    {
        public BigInteger DedID { get; set; }
        public string DedName { get; set; } = "";
        

    }
    public class Stepinfo
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        

    }
    public class Gradeinfo
    {
        public int ID { get; set; }
        public string GradeName { get; set; } = "";






    }
}

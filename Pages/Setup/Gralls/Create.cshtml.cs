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

namespace HRMSApplication.Pages.Setup.Gralls
{
    public class CreateModel : PageModel
    {
        public List<Gradeinfo> listGrades = new List<Gradeinfo>();
        public List<Stepinfo> listSteps = new List<Stepinfo>();
        public List<Mainallinfo> listMainalls = new List<Mainallinfo>();
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

                    string sql = "SELECT * FROM AllowanceID ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Mainallinfo mainallinfo = new Mainallinfo();
                                mainallinfo.AllowID = reader.GetInt32(0);
                                mainallinfo.AllowName = reader.GetString(1);



                                listMainalls.Add(mainallinfo);



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
                    string sql = "INSERT INTO HPayAllowance" +
                        "(AllowName, Value1, Steps, Grade ) VALUES " + "(@AllowName, @Value1, @Steps, @Grade);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
						command.Parameters.AddWithValue("AllowName", AllowName);

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
			Response.Redirect("/Setup/Gralls/Index");
		}
    }
    public class Mainallinfo
    {
        public int AllowID { get; set; }
        public string AllowName { get; set; } = "";
        

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

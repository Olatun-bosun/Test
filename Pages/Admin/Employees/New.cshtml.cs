using HRMSApplication.Admin.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;

namespace HRMSApplication.Pages.Admin.Employees
{
    public class NewModel : PageModel
    {
        public List<Gradeinfo> listGrades = new List<Gradeinfo>();
        public List<Stepinfo> listSteps = new List<Stepinfo>();
        public List<Employeeinfo> listEmployees = new List<Employeeinfo>();
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
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
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
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT TOP 1 * FROM HREmployees ORDER BY ModifiedOn DESC ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employeeinfo employeeinfo = new Employeeinfo();
                                employeeinfo.EmployeeID = reader.GetString(0);
                                employeeinfo.StaffIDNo = reader.GetString(1);
                                employeeinfo.Title = reader.GetString(2);
                                employeeinfo.Surname = reader.GetString(3);
                                employeeinfo.OtherNames = reader.GetString(4);


                                listEmployees.Add(employeeinfo);



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
        public int EmployeeID { get; set; }
        [BindProperty]
        [Required]
        public string Surname { get; set; } = "";
        [BindProperty]
        [Required]
        public string OtherNames { get; set; } = "";
        [BindProperty]
        [Required]
        public int Basic { get; set; }
        [BindProperty]
        [Required]
        public int Housing { get; set; }
        [BindProperty]
        [Required]
        public int Transport { get; set; }
        [BindProperty]
        [Required]
        public string Step { get; set; } = "";
        [BindProperty]
        [Required]
        public string Grade { get; set; } = "";


        public string errorMessage = "";
        public string successMessage = "";
        
        public void OnPost()
        {

            try
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO PaySlips" +
                        "(EmployeeID, Surname, OtherNames, Basic, Housing, Transport, Step, Grade ) VALUES " + "(@EmployeeID, @Surname, @OtherNames, @Basic, @Housing, @Transport, @Step, @Grade);";

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

//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Numerics;

namespace HRMSApplication.Admin.Employees
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Employeeinfo> listEmployees = new List<Employeeinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM HREmployees ";

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
    }

    public class Employeeinfo
    {
        public string EmployeeID { get; set; } = "";
        public string StaffIDNo { get; set; } = "";
        public string Title { get; set; } = "";
        public string Surname { get; set; } = "";
        public string OtherNames { get; set; } = "";
       




    }
}

//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Numerics;

namespace HRMSApplication.Setup.Steps
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Stepinfo> listSteps = new List<Stepinfo>();
        public void OnGet()
        {
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
                               stepinfo.Remarks = reader.GetString(2);
                              
                               

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
        }
    }

    public class Stepinfo
    {
        public int ID { get; set; } 
        public string Name { get; set; } = "";
        public string Remarks { get; set; } = "";
       
       




    }
}

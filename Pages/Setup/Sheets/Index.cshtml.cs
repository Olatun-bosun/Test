//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Numerics;

namespace HRMSApplication.Setup.Sheets
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Sheetinfo> listSheets = new List<Sheetinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM PaySheets ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Sheetinfo sheetinfo = new Sheetinfo();
                             sheetinfo.SheetID = reader.GetInt32(0);            
                             sheetinfo.PaySheet = reader.GetString(1);
                             sheetinfo.Frequency = reader.GetString(2);
                              
                               

                                listSheets.Add(sheetinfo);
                                


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

    public class Sheetinfo
    {
        public int SheetID { get; set; } 
        public string PaySheet { get; set; } = "";
        public string Frequency { get; set; } = "";
       
       




    }
}

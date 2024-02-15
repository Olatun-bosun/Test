//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Varalls
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Varallinfo> listVaralls = new List<Varallinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
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
    }

    public class Varallinfo
    {
        public int AllowID { get; set; } 
        public string AllowName { get; set; } = "";
        public int Value1 { get; set; } 
       
       




    }
}

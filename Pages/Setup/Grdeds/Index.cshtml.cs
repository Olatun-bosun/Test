//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Grdeds
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Grdedinfo> listGrdeds = new List<Grdedinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM HPayDeductions ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Grdedinfo grdedinfo = new Grdedinfo();
								grdedinfo.HID = reader.GetInt64(0);

                             grdedinfo.DedName = reader.GetString(1);
                             grdedinfo.Value1 = reader.GetInt32(2);
                             grdedinfo.Steps = reader.GetString(3);
								grdedinfo.GradeID = reader.GetInt64(4);

								grdedinfo.Grade = reader.GetString(5);



                                listGrdeds.Add(grdedinfo);
                                


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

    public class Grdedinfo
    {
		public BigInteger HID { get; set; }

        public string DedName { get; set; } = "";
        public int Value1 { get; set; }
        public string Steps { get; set; } = "";
		public BigInteger GradeID { get; set; }

		public string Grade { get; set; } = "";





    }
}

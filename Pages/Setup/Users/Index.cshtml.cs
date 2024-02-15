//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Users
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Userinfo> listUsers = new List<Userinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
					connection.Open();

					string sql = "SELECT * FROM users ";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Userinfo userinfo = new Userinfo();
								userinfo.id = reader.GetInt32(0);
								userinfo.firstname = reader.GetString(1);
                                userinfo.lastname = reader.GetString(2);
                                userinfo.email = reader.GetString(3);
                                userinfo.phone = reader.GetString(4);
                                userinfo.password = reader.GetString(5);




                                listUsers.Add(userinfo);


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

	public class Userinfo
	{
		public int id { get; set; }
		public string firstname { get; set; } = "";
        public string lastname { get; set; } = "";
        public string email { get; set; } = "";
        public string phone { get; set; } = "";
        public string password { get; set; } = "";







    }
}

//using HRMSApplication.MyHelpers;
using HRMSApplication.Pages.Setup.Gralls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Mainalls
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
		public List<Mainallinfo> listMainalls = new List<Mainallinfo>();
		public void OnGet()
        {
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
    }

	public class Mainallinfo
	{
		public int AllowID { get; set; }
		public string AllowName { get; set; } = "";






	}
}

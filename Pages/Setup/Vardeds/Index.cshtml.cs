//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Vardeds
{
	//[RequireAuth(RequiredRole = "admin")]
	public class IndexModel : PageModel
	{
		public List<Vardedinfo> listVardeds = new List<Vardedinfo>();
		public void OnGet()
		{
			try
			{
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = "SELECT * FROM VPayDeductions ";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Vardedinfo vardedinfo = new Vardedinfo();
								vardedinfo.DedID = reader.GetInt32(0);
								vardedinfo.DedName = reader.GetString(1);
								vardedinfo.Value2 = reader.GetInt32(2);




								listVardeds.Add(vardedinfo);



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

	public class Vardedinfo
	{
		public int DedID { get; set; }
		public string DedName { get; set; } = "";
		public int Value2 { get; set; }







	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Setup.Departments
{
	//[RequireAuth(RequiredRole = "admin")]
	public class Index1Model : PageModel
	{
		public List<DepartmentInfo> listDepartments = new List<DepartmentInfo>();
		public void OnGet()
		{
			try
			{
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = "SELECT * FROM HPayDept";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								DepartmentInfo departmentinfo = new DepartmentInfo();
								departmentinfo.Code = reader.GetString(0);
								departmentinfo.Name = reader.GetString(1);




								listDepartments.Add(departmentinfo);



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

	public class DepartmentInfo
	{
		public string Code { get; set; } = "";
		public string Name { get; set; } = "";







	}
}

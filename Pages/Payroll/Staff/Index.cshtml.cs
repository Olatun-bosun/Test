using HRMSApplication.Pages.Setup.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Payroll.Staff
{
    public class IndexModel : PageModel
    {
        public List<StaffInfo> listStaffs = new List<StaffInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM PaySlips";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StaffInfo staffinfo = new StaffInfo();
                                staffinfo.ID = reader.GetInt32(0);
                                staffinfo.SheetID = reader.GetInt32(1);
                                staffinfo.EmployeeID = reader.GetString(2);
                                staffinfo.Surname = reader.GetString(3);
                                staffinfo.OtherNames = reader.GetString(4);
                                staffinfo.Grade = reader.GetString(99);


                                listStaffs.Add(staffinfo);



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
    public class StaffInfo
    {
        public int ID { get; set; }
        public int SheetID { get; set; }
        public string EmployeeID { get; set; } = "";
        public string Surname { get; set; } = "";
        public string OtherNames { get; set; } = "";
        public string Grade { get; set; } = "";


    }
}

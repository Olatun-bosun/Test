//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Admin.Employees
{
    //[RequireAuth(RequiredRole = "admin")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public int EmployeeID { get; set; }
        [BindProperty]
        [Required]
        public string StaffIDNo { get; set; } = "";
        [BindProperty]
        [Required]
        public string Title { get; set; } = "";
        [BindProperty]
        [Required]
        public string Surname { get; set; } = "";
        [BindProperty]
        [Required]
        public string OtherNames { get; set; } = "";
        [BindProperty]
        [Required]
        public string Address { get; set; } = "";
        [BindProperty]
        [Required]
        public string State { get; set; } = "";
        [BindProperty]
        [Required]
        public string Country { get; set; } = "";
        [BindProperty]
        [Required]
        public string Sex { get; set; } = "";
        [BindProperty]
        [Required]
        public DateTime BirthDate { get; set; }
        [BindProperty]
        [Required]
        public string MaritalStatus { get; set; } = "";
        [BindProperty]
        [Required]
        public string StateOrigin { get; set; } = "";
        [BindProperty]
        [Required]
        public string NationalIDNo { get; set; } = "";
        [BindProperty]
        [Required]
        public string AcctNo1 { get; set; } = "";
        [BindProperty]
        [Required]
        public string AcctName1 { get; set; } = "";
        [BindProperty]
        [Required]
        public string AcctNo2 { get; set; } = "";
        [BindProperty]
        public string AcctName2 { get; set; } = "";
        [BindProperty]
        [Required]
        public string BranchID { get; set; } = "";
        [BindProperty]
        [Required]
        public string Branch { get; set; } = "";
        [BindProperty]
        [Required]
        public string DeptID { get; set; } = "";
        [BindProperty]
        [Required]
        public string Dept { get; set; } = "";
        [BindProperty]
        [Required]
        public string UnitID { get; set; } = "";
        [BindProperty]
        public string Unit { get; set; } = "";
        [BindProperty]
        [Required]
        public int GradeID { get; set; }
        [BindProperty]
        [Required]
        public string Grade { get; set; } = "";
        [BindProperty]
        [Required]
        public DateTime HireDate { get; set; }
        [BindProperty]
        [Required]
        public string Telephone { get; set; } = "";
        [BindProperty]
        [Required]
        public string MobilePhone { get; set; } = "";
        [BindProperty]
        [Required]
        public string Email { get; set; } = "";
        [BindProperty]
        [Required]
        public string Email2 { get; set; } = "";
        [BindProperty]
        [Required]
        public string HMOName { get; set; } = "";
        [BindProperty]
        [Required]
        public string HMOID { get; set; } = "";
        [BindProperty]
        [Required]
        public string NextKin { get; set; } = "";
        [BindProperty]
        [Required]
        public string KinAddress { get; set; } = "";
        [BindProperty]
        [Required]
        public string KinRelationship { get; set; } = "";
        [BindProperty]
        [Required]
        public string KinPhone { get; set; } = "";
        [BindProperty]
        [Required]
        public string Height { get; set; } = "";
        [BindProperty]
        [Required]
        public string Weight { get; set; } = "";
        [BindProperty]
        [Required]
        public string Smoker { get; set; } = "";
        [BindProperty]
        [Required]
        public string DisableType { get; set; } = "";
        [BindProperty]
        [Required]
        public string Remarks { get; set; } = "";
        [BindProperty]
        [Required]
        public string Tag { get; set; } = "";
        [BindProperty]
        [Required]
        public string PayFirstMonth { get; set; } = "";
        [BindProperty]
        [Required]
        public int SheetID2 { get; set; }
        [BindProperty]
        [Required]
        public string ConfirmStatus { get; set; } = "";
        [BindProperty]
        [Required]
        public int ConfirmDuration { get; set; }
        [BindProperty]
        public DateTime ConfirmationDate { get; set; }
        [BindProperty]
        [Required]
        public DateTime RetiredDate { get; set; }
        [BindProperty]
        [Required]
        public string Deleted { get; set; } = "";
        [BindProperty]
        [Required]
        public string Active { get; set; } = "";
        [BindProperty]
        [Required]
        public string Submitby { get; set; } = "";
        [BindProperty]
        [Required]
        public DateTime SubmitOn { get; set; }
        [BindProperty]
        [Required]
        public string ModifiedBy { get; set; } = "";
        [BindProperty]
        [Required]
        public DateTime ModifiedOn { get; set; }

        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
            string requestId = Request.Query["EmployeeID"];

            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM HREmployees WHERE EmployeeID=@EmployeeID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", requestId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                EmployeeID = reader.GetInt32(0);
                                StaffIDNo = reader.GetString(1);
                                Title = reader.GetString(2);
                                Surname = reader.GetString(3);
                                OtherNames = reader.GetString(4);
                                Address = reader.GetString(5);
                                State = reader.GetString(6);
                                Country = reader.GetString(7);
                                Sex = reader.GetString(8);
                                BirthDate = reader.GetDateTime(9);
                                MaritalStatus = reader.GetString(10);
                                StateOrigin = reader.GetString(11);
                                NationalIDNo = reader.GetString(12);
                                AcctNo1 = reader.GetString(13);
                                AcctName1 = reader.GetString(14);
                                AcctNo2 = reader.GetString(15);
                                AcctName2 = reader.GetString(16);
                                BranchID = reader.GetString(17);
                                Branch = reader.GetString(18);
                                DeptID = reader.GetString(19);
                                Dept = reader.GetString(20);
                                UnitID = reader.GetString(21);
                                Unit = reader.GetString(22);
                                GradeID = reader.GetInt32(23);
                                Grade = reader.GetString(24);
                                HireDate = reader.GetDateTime(25);
                                Telephone = reader.GetString(26);
                                MobilePhone = reader.GetString(27);
                                Email = reader.GetString(28);
                                Email2 = reader.GetString(29);
                                HMOName = reader.GetString(30);
                                HMOID = reader.GetString(31);
                                NextKin = reader.GetString(32);
                                KinAddress = reader.GetString(33);
                                KinRelationship = reader.GetString(34);
                                KinPhone = reader.GetString(35);
                                Height = reader.GetString(36);
                                Weight = reader.GetString(37);
                                Smoker = reader.GetString(38);
                                DisableType = reader.GetString(39);
                                Remarks = reader.GetString(40);
                                Tag = reader.GetString(41);
                                PayFirstMonth = reader.GetString(42);
                                SheetID2 = reader.GetInt32(43);
                                ConfirmStatus = reader.GetString(44);
                                ConfirmDuration = reader.GetInt32(45);
                                ConfirmationDate = reader.GetDateTime(46);
                                RetiredDate = reader.GetDateTime(47);
                                Deleted = reader.GetString(48);
                                Active = reader.GetString(59);
                                Submitby = reader.GetString(50);
                                SubmitOn = reader.GetDateTime(51);
                                ModifiedBy = reader.GetString(52);
                                ModifiedOn = reader.GetDateTime(53);
                            }
                            else
                            {
                                Response.Redirect("/Admin/Employees/Index");
                            }
                        }
                    }
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("/Admin/Employees/Index");
            }

        }

        public void OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //	errorMessage = "Data validation failed";
            //	return;
            //}

            // successfull data validation

            //successMessage = "Data saved correctly";

            try
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE HREmployees SET StaffIDNo=@StaffIDNo , Title=@Title, Surname=@Surname, OtherNames=@OtherNames, Address=@Address, State=@State, Country=@Country, Sex=@Sex, BirthDate=@BirthDate, MaritalStatus=@MaritalStatus, StateOrigin=@StateOrigin, NationalIDNo=@NationalIDNo, AcctNo1=@AcctNo1, AcctName1=@AcctName1, AcctNo2=@AcctNo2, AcctName2=@AcctName2, BranchID=@BranchID, Branch=@Branch, DeptID=@DeptID, Dept=@Dept, UnitID=@UnitID, Unit=@Unit, GradeID=@GradeID, Grade=@Grade, HireDate=@HireDate, Telephone=@Telephone, MobilePhone=@MobilePhone, Email=@Email, Email2=@Email2, HMOName=@HMOName, HMOID=@HMOID, NextKin=@NextKin, KinAddress=@KinAddress, KinRelationship=@KinRelationship, KinPhone=@KinPhone, Height=@Height, Weight=@Weight, Smoker=@Smoker, DisableType=@DisableType, Remarks=@Remarks, Tag=@Tag, PayFirstMonth=@PayFirstMonth, SheetID2=@SheetID2, ConfirmStatus=@ConfirmStatus, ConfirmDuration=@ConfirmDuration, ConfirmationDate=@ConfirmationDate, RetiredDate=@RetiredDate, Deleted=@Deleted, Active=@Active, Submitby=@Submitby, SubmitOn=@SubmitOn, ModifiedBy=@ModifiedBy, ModifiedOn=@ModifiedOn WHERE EmployeeID=@EmployeeID ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@StaffIDNo", StaffIDNo);
                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@Surname", Surname);
                        command.Parameters.AddWithValue("@OtherNames", OtherNames);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@State", State);
                        command.Parameters.AddWithValue("@Country", Country);
                        command.Parameters.AddWithValue("@Sex", Sex);
                        command.Parameters.AddWithValue("@BirthDate", BirthDate);
                        command.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);
                        command.Parameters.AddWithValue("@StateOrigin", StateOrigin);
                        command.Parameters.AddWithValue("@NationalIDNo", NationalIDNo);
                        command.Parameters.AddWithValue("@AcctNo1", AcctNo1);
                        command.Parameters.AddWithValue("@AcctName1", AcctName1);
                        command.Parameters.AddWithValue("@AcctNo2", AcctNo2);
                        command.Parameters.AddWithValue("@AcctName2", AcctName2);
                        command.Parameters.AddWithValue("@BranchID", BranchID);
                        command.Parameters.AddWithValue("@Branch", Branch);
                        command.Parameters.AddWithValue("@DeptID", DeptID);
                        command.Parameters.AddWithValue("@Dept", Dept);
                        command.Parameters.AddWithValue("@UnitID", UnitID);
                        command.Parameters.AddWithValue("@Unit", Unit);
                        command.Parameters.AddWithValue("@GradeID", GradeID);
                        command.Parameters.AddWithValue("@Grade", Grade);
                        command.Parameters.AddWithValue("@HireDate", HireDate);
                        command.Parameters.AddWithValue("@Telephone", Telephone);
                        command.Parameters.AddWithValue("@MobilePhone", MobilePhone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Email2", Email2);
                        command.Parameters.AddWithValue("@HMOName", HMOName);
                        command.Parameters.AddWithValue("@HMOID", HMOID);
                        command.Parameters.AddWithValue("@NextKin", NextKin);
                        command.Parameters.AddWithValue("@KinAddress", KinAddress);
                        command.Parameters.AddWithValue("@KinRelationship", KinRelationship);
                        command.Parameters.AddWithValue("@KinPhone", KinPhone);
                        command.Parameters.AddWithValue("@Height", Height);
                        command.Parameters.AddWithValue("@Weight", Weight);
                        command.Parameters.AddWithValue("@Smoker", Smoker);
                        command.Parameters.AddWithValue("@DisableType", DisableType);
                        command.Parameters.AddWithValue("@Remarks", Remarks);
                        command.Parameters.AddWithValue("@Tag", Tag);
                        command.Parameters.AddWithValue("@PayFirstMonth", PayFirstMonth);
                        command.Parameters.AddWithValue("@SheetID2", SheetID2);
                        command.Parameters.AddWithValue("@ConfirmStatus", ConfirmStatus);
                        command.Parameters.AddWithValue("@ConfirmDuration", ConfirmDuration);
                        command.Parameters.AddWithValue("@ConfirmationDate", ConfirmationDate);
                        command.Parameters.AddWithValue("@RetiredDate", RetiredDate);
                        command.Parameters.AddWithValue("@Deleted", Deleted);
                        command.Parameters.AddWithValue("@Active", Active);
                        command.Parameters.AddWithValue("@Submitby", Submitby);
                        command.Parameters.AddWithValue("@SubmitOn", SubmitOn);
                        command.Parameters.AddWithValue("@ModifiedBy", ModifiedBy);
                        command.Parameters.AddWithValue("@ModifiedOn", ModifiedOn);


                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                        command.ExecuteNonQuery();

                    }
                }




            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            successMessage = "Data saved correctly";
            Response.Redirect("/Admin/Employees/Index");

        }
    }
}

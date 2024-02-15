//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Admin.Employees
{
    //[RequireAuth(RequiredRole ="admin")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        [Required]
        public string EmployeeID { get; set; } = "";
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
        public string? PayFirstMonth { get; set; } = "";
        [BindProperty]
        [Required]
        public int? SheetID2 { get; set; }
        [BindProperty]
        [Required]
        public string? ConfirmStatus { get; set; } = "";
        [BindProperty]
        [Required]
        public int? ConfirmDuration { get; set; }
        [BindProperty]
        public DateTime? ConfirmationDate { get; set; }
        [BindProperty]
        [Required]
        public DateTime? RetiredDate { get; set; }
        [BindProperty]
        [Required]
        public string? Deleted { get; set; } = "";
        [BindProperty]
        [Required]
        public string? Active { get; set; } = "";
        [BindProperty]
        [Required]
        public string? Submitby { get; set; } = "";
        [BindProperty]
        [Required]
        public DateTime? SubmitOn { get; set; }
        [BindProperty]
        [Required]
        public string? ModifiedBy { get; set; } = "";
        [BindProperty]
        [Required]
        public DateTime? ModifiedOn { get; set; }

        public string errorMessage = "";
        public string successMessage = "";

        //private IWebHostEnvironment webHostEnvironment;

        //public CreateModel(IWebHostEnvironment env)
        //{
        //	webHostEnvironment = env;
        //}

        public void OnGet()
        {
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

            // save image
            //string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //newFileName += Path.GetExtension(ImageFile.FileName);

            //string imageFolder = webHostEnvironment.WebRootPath + "/images/Employees/";

            //string imageFullPath = Path.Combine(imageFolder, newFileName);
            //Console.WriteLine("New image: " + imageFullPath);

            //using (var stream = System.IO.File.Create(imageFullPath))
            //{
            //	ImageFile.CopyToAsync(stream);
            //}

            //save to database

            try
            {
                string connectionString = " Data Source = INTTECK7\\SQL_2012; Initial Catalog = HRMS2DB; User ID = sa; Password = Gibs@321.";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO HREmployees " +
                        "(EmployeeID,StaffIDNo, Title, Surname, OtherNames, Address, State, Country, Sex, BirthDate, MaritalStatus, StateOrigin, NationalIDNo, AcctNo1, AcctName1, AcctNo2, AcctName2, BranchID, Branch, DeptID, Dept, UnitID, Unit, GradeID, Grade, HireDate, Telephone, MobilePhone, Email, Email2, HMOName, HMOID, NextKin, KinAddress, KinRelationship, KinPhone, Height, Weight, Smoker, DisableType, Remarks, Tag, PayFirstMonth, SheetID2, ConfirmStatus, ConfirmDuration, ConfirmationDate, RetiredDate, Deleted, Active, Submitby, SubmitOn, ModifiedBy, ModifiedOn) VALUES  " + "(@EmployeeID,@StaffIDNo, @Title, @Surname, @OtherNames, @Address, @State, @Country, @Sex, @BirthDate, @MaritalStatus, @StateOrigin, @NationalIDNo, @AcctNo1, @AcctName1, @AcctNo2, @AcctName2, @BranchID, @Branch, @DeptID, @Dept, @UnitID, @Unit, @GradeID, @Grade, @HireDate, @Telephone, @MobilePhone, @Email, @Email2, @HMOName, @HMOID, @NextKin, @KinAddress, @KinRelationship, @KinPhone, @Height, @Weight, @Smoker, @DisableType, @Remarks, @Tag, @PayFirstMonth, @SheetId2, @ConfirmStatus, @ConfirmDuration, @ConfirmationDate, @RetiredDate, @Deleted, @Active, @Submitby, @SubmitOn, @ModifiedBy, @ModifiedOn)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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
                        command.Parameters.AddWithValue("@NationalIdNo", NationalIDNo);
                        command.Parameters.AddWithValue("@AcctNo1", AcctNo1);
                        command.Parameters.AddWithValue("@AcctName1", AcctName1);
                        command.Parameters.AddWithValue("@AcctNo2", AcctNo2);
                        command.Parameters.AddWithValue("@AcctName2", AcctName2);
                        command.Parameters.AddWithValue("@BranchId", BranchID);
                        command.Parameters.AddWithValue("@Branch", Branch);
                        command.Parameters.AddWithValue("@DeptId", DeptID);
                        command.Parameters.AddWithValue("@Dept", Dept);
                        command.Parameters.AddWithValue("@UnitId", UnitID);
                        command.Parameters.AddWithValue("@Unit", Unit);
                        command.Parameters.AddWithValue("@GradeId", GradeID);
                        command.Parameters.AddWithValue("@Grade", Grade);
                        command.Parameters.AddWithValue("@HireDate", HireDate);
                        command.Parameters.AddWithValue("@Telephone", Telephone);
                        command.Parameters.AddWithValue("@Mobilephone", MobilePhone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Email2", Email2);
                        command.Parameters.AddWithValue("@HmoName", HMOName);
                        command.Parameters.AddWithValue("@HmoId", HMOID);
                        command.Parameters.AddWithValue("@NextKin", NextKin);
                        command.Parameters.AddWithValue("@KinAddress", KinAddress);
                        command.Parameters.AddWithValue("@KinRelationship", KinRelationship);
                        command.Parameters.AddWithValue("@Kinphone", KinPhone);
                        command.Parameters.AddWithValue("@Height", Height);
                        command.Parameters.AddWithValue("@Weight", Weight);
                        command.Parameters.AddWithValue("@Smoker", Smoker);
                        command.Parameters.AddWithValue("@DisableType", DisableType);
                        command.Parameters.AddWithValue("@Remarks", Remarks);
                        command.Parameters.AddWithValue("@Tag", Tag);
                        command.Parameters.AddWithValue("@PayFirstMonth", PayFirstMonth);
                        command.Parameters.AddWithValue("@SheetId2", SheetID2);
                        command.Parameters.AddWithValue("@ConfirmStatus", ConfirmStatus);
                        command.Parameters.AddWithValue("@ConfirmDuration", ConfirmDuration);
                        command.Parameters.AddWithValue("@ConfirmationDate", ConfirmationDate);
                        command.Parameters.AddWithValue("@RetiredDate", RetiredDate);
                        command.Parameters.AddWithValue("@Deleted", Deleted);
                        command.Parameters.AddWithValue("@Active", Active);
                        command.Parameters.AddWithValue("@SubmitBy", Submitby);
                        command.Parameters.AddWithValue("@SubmitOn", SubmitOn);
                        command.Parameters.AddWithValue("@ModifiedBy", ModifiedBy);
                        command.Parameters.AddWithValue("@ModifiedOn", ModifiedOn);

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
            Response.Redirect("/Admin/Employees/New");
        }
    }
}

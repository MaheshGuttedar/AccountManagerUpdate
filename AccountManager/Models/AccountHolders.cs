using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountManager.Models
{
    public class AccountHolders
    {   [Key]
        public int Id { get; set; }
      
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Mobile Number")]         
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 numbers", MinimumLength = 10)]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Enter Guarantor Name")]
        [DisplayName("Guarantor Name")]
        public string GuarantorName { get; set; }
        
        [DisplayName("Guarantor Address")]
        [Required(ErrorMessage = "Enter Guarantor Address")]
        public string GuarantorAddress { get; set; }
        [Required(ErrorMessage = "Enter Guarantor Mobile")]
        [DisplayName("Guarantor Mobile")]
        
        [StringLength(10, ErrorMessage = "The Guarantor Mobile must contains 10 numbers", MinimumLength = 10)]
        public string GuarantorMobile { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string Cell { get; set; }
        [DisplayName("Reg No")]
        [StringLength(100, MinimumLength = 1)]
        public string RegNo { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string Model { get; set; }
      
 
        [Required(ErrorMessage = "Enter Make")]
        [StringLength(100, MinimumLength = 1)]
        public string Make { get; set; }
        [DisplayName("Chassis No")]
        [StringLength(100, MinimumLength = 1)]
        public string ChassisNo { get; set; }
        [DisplayName("Engine No")]
        [StringLength(100, MinimumLength = 1)]
        public string EngineNo { get; set; }
        [DisplayName("Insurance Upto")]
        [StringLength(10, MinimumLength = 1)]
        public string InsuranceUpto { get; set; }
        [DisplayName("Due Date")]
        [StringLength(10, MinimumLength = 1)]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format due date")]
        public string DueDate { get; set; }
        [DisplayName("Loan Advance Date")]
        [StringLength(10, MinimumLength = 1)]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format for loan advance.")]
        public string LoanAdvanceDate { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
      
        [Required(ErrorMessage = "Select Year")]
        public int YearId { get; set; }
        
        [DisplayName("Installment No")]
        [Required(ErrorMessage = "Enter Installments")]
        [Range(0, 1000)]
        public int TotalInstallments { get; set; }
       
        [DisplayName("Loan Advance")]
        [Required(ErrorMessage = "Enter Loan Advance")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? LoanAdvance { get; set; }
       
        [DisplayName("Installment Amount")]
        [Required(ErrorMessage = "Enter Installment Amount")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? InstallmentAmount { get; set; }
        [DisplayName("Account Status")]
       
        [StringLength(10, MinimumLength = 1)]
        public string Status { get; set; }
        [DisplayName("Register Account No")]
        [Required(ErrorMessage = "Enter Register Account No")]
        [StringLength(20, MinimumLength = 1)]
        public string AccountNoFromRegister { get; set; }
        public byte[] CustomerPhoto { get; set; }

    }
}
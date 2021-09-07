using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountManager.Models
{
    public class AccountHolders
    {   [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string GuarantorName { get; set; }
        [Required]
        public string GuarantorAddress { get; set; }
        [Required]
        public string GuarantorMobile { get; set; }
        public string Cell { get; set; }
        public string RegNo { get; set; }
        public string Model { get; set; }
        [Required]
        public string Make { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string InsuranceUpto { get; set; }
        public string DueDate { get; set; } //ends here all
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
        //public virtual LedgerAccountType LedgerAccountType_AccountId { get; set; }    
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        [Required]
        public int YearId { get; set; }
        [Required]
        public int TotalInstallments { get; set; }
        [Required]
        public double LoanAdvance { get; set; }
        [Required]
        public double InstallmentAmount { get; set; }
        public string Status { get; set; }
        public string AccountNoFromRegister { get; set; }

    }
}
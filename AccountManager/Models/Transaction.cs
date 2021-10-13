using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class Transaction
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Select Date")]
        [DisplayName("Installment Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        public string TransactionDate { get; set; }
        [StringLength(50)] 
        [DisplayName("Particulars")]
        [Required(ErrorMessage = "Enter Particulars")]
        public string Title { get; set; }
        [DisplayName("No of Installment")]
        [Required(ErrorMessage = "Enter Installment No")]
        public int InstallmentNo { get; set; }
        [DisplayName("Hire Charge")]
        [Required(ErrorMessage = "Enter HireCharge")]
        public decimal HireCharge { get; set; }
        [DisplayName("Debit Amount")]
        [Required(ErrorMessage = "Enter Debit Amount")]
        public Nullable<Decimal> DebitAmount { get; set; }
        [DisplayName("Credit Amount")]
        [Required(ErrorMessage = "Enter Credit Amount")]
        public Nullable<Decimal> CreditAmount { get; set; }
        [DisplayName("Balance Amount ")]
        [Required(ErrorMessage = "Enter Balance Amt")]
        public decimal BalanceAmount { get; set; }
        [DisplayName("Account Holder")]
        [Required(ErrorMessage = "Account Holder")]
        public int AccountHolderId { get; set; }
        [DisplayName("Year ")]
        [Required(ErrorMessage = "Year")]
        public int YearId { get; set; }
        [DisplayName("OverDue Days")]
        public int OverDueDays { get; set; }
        [DisplayName("OverDue Amount ")]
        public decimal OverDueAmount { get; set; }







        public virtual ICollection<InvoiceTransaction> InvoiceTransaction_TransactionIds { get; set; }   
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public int? PaymentStatusId { get; set; }


        public DateTime DateAdded { get; set; }
        public int AddedBy { get; set; }
        public int? OfficeId { get; set; }
       // public virtual CompanyOffice CompanyOffice_OfficeId { get; set; }       
        public int? DebitAccount { get; set; }
       // public virtual LedgerAccountType LedgerAccountType_DebitAccount { get; set; }




    }
}

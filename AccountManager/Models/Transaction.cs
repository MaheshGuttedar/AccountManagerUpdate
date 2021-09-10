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
        [DisplayName("Date")]       
        public DateTime TransactionDate { get; set; }
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
        [DisplayName("Account Holders")]
        [Required(ErrorMessage = "Select Account Holder")]
        public int AccountHolderId { get; set; }
        [DisplayName("Year ")]
        [Required(ErrorMessage = "Select Year")]
        public int YearId { get; set; }







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

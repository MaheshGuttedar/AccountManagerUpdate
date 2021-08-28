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
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Date Added")] 
        public DateTime DateAdded { get; set; }
        [Required]
        [DisplayName("Added By")] 
        public int AddedBy { get; set; }
        [Required]
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual CompanyOffice CompanyOffice_OfficeId { get; set; }
       
        [DisplayName("Debit Account")] 
        public int? DebitAccount { get; set; }
        public virtual LedgerAccountType LedgerAccountType_DebitAccount { get; set; }
         
        [DisplayName("Debit Amount")] 
        public Nullable<Decimal> DebitAmount { get; set; }
        
        [DisplayName("Credit Account")] 
        public int? CreditAccount { get; set; }
        public virtual LedgerAccountType LedgerAccountType_CreditAccount { get; set; }
         
        [DisplayName("Credit Amount")] 
        public Nullable<Decimal> CreditAmount { get; set; }

        [Required]
        [DisplayName("Transaction Date")] 
        public DateTime TransactionDate { get; set; }
        public virtual ICollection<InvoiceTransaction> InvoiceTransaction_TransactionIds { get; set; }

    }
}

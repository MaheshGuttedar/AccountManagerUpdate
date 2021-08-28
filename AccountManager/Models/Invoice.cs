using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class Invoice
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Bill Date")] 
        public DateTime BillDate { get; set; }
        [DisplayName("Due Date")] 
        public Nullable<DateTime> DueDate { get; set; }
        [Required]
        [DisplayName("Status")] 
        public int? Status { get; set; }
        public virtual PaymentStatus PaymentStatus_Status { get; set; }
        [DisplayName("Last Emailed")] 
        public Nullable<DateTime> LastEmailed { get; set; }
        [StringLength(50)] 
        [DisplayName("Other Invoice Code")] 
        public string OtherInvoiceCode { get; set; }
        [Required]
        [DisplayName("Client")] 
        public int? ClientId { get; set; }
        public virtual User User_ClientId { get; set; }
        [Required]
        [DisplayName("Created By")] 
        public int CreatedBy { get; set; }
        [Required]
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual CompanyOffice CompanyOffice_OfficeId { get; set; }
        public virtual ICollection<InvoiceTransaction> InvoiceTransaction_InvoiceIds { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItem_InvoiceIds { get; set; }

    }
}

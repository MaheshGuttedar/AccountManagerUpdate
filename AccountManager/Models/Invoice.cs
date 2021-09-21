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
        [DataType(DataType.Date)]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format for billdate")]
        public DateTime BillDate { get; set; }
        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format for duedate")]
        public Nullable<DateTime> DueDate { get; set; }
        [Required]
        [DisplayName("Payment Status")] 
        public int? Status { get; set; }
        public virtual PaymentStatus PaymentStatus_Status { get; set; }
        [DisplayName("Last Emailed")] 
        public Nullable<DateTime> LastEmailed { get; set; }
        [StringLength(50)] 
        [DisplayName("Transaction Id")] 
        public string OtherInvoiceCode { get; set; }
        
        [DisplayName("Client")] 
        public int? ClientId { get; set; }
        public virtual User User_ClientId { get; set; }
        
        [DisplayName("Created By")] 
        public int CreatedBy { get; set; }
        
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
      //  public virtual CompanyOffice CompanyOffice_OfficeId { get; set; }
        public virtual ICollection<InvoiceTransaction> InvoiceTransaction_InvoiceIds { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItem_InvoiceIds { get; set; }

        [DisplayName("Select Account Holder")]
        [Required(ErrorMessage = "Select Account Holder")]
        public int AccountHolderId { get; set; }
        [DisplayName("Select Year ")]
        [Required(ErrorMessage = "Select Year")]
        public int YearId { get; set; }

    }
}

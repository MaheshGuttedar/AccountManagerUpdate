using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class InvoiceItem
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Invoice")] 
        public int? InvoiceId { get; set; }
        public virtual Invoice Invoice_InvoiceId { get; set; }
        [StringLength(200)] 
        [DisplayName("Description")] 
        public string Description { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Quantity")] 
        public Decimal Quantity { get; set; }
        [Required]
        [DisplayName("Unit Price")] 
        public Decimal UnitPrice { get; set; }
        [Required]
        [DisplayName("Unit Name")] 
        public int? UnitName { get; set; }
        public virtual QuantityUnit QuantityUnit_UnitName { get; set; }
        [Required]
        [DisplayName("Total")] 
        public Decimal Total { get; set; }

    }
}

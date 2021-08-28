using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class QuantityUnit
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Title")] 
        public string Title { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItem_UnitNames { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class CompanyOffice
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [DisplayName("Code")] 
        public string Code { get; set; }
        [Required]
        [DisplayName("Created On")] 
        public DateTime CreatedOn { get; set; }
        [Required]
        [DisplayName("Office Type")] 
        public int? OfficeTypeId { get; set; }
        public virtual OfficeType OfficeType_OfficeTypeId { get; set; }
        [Required]
        [DisplayName("Company")] 
        public int? CompanyId { get; set; }
        public virtual Company Company_CompanyId { get; set; }
        public virtual ICollection<Transaction> Transaction_OfficeIds { get; set; }
        public virtual ICollection<Product> Product_OfficeIds { get; set; }
        public virtual ICollection<Invoice> Invoice_OfficeIds { get; set; }

    }
}

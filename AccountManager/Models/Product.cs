using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class Product
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [Required]
        [DisplayName("Purchase Cost")] 
        public Decimal PurchaseCost { get; set; }
        [DisplayName("Sale Price")] 
        public Nullable<Decimal> SalePrice { get; set; }
        [Required]
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual CompanyOffice CompanyOffice_OfficeId { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }
        [DisplayName("Product Image")] 
        public string ProductImage { get; set; }
        [StringLength(50)] 
        [DisplayName("Bare Code")] 
        public string BareCode { get; set; }
        [DisplayName("Description")] 
        public string Description { get; set; }
        [DisplayName("Re Order Value")] 
        public Nullable<int> ReOrderValue { get; set; }
        [Required]
        [DisplayName("Stock")] 
        public int Stock { get; set; }
        [DisplayName("Min Stock Value")] 
        public Nullable<int> MinStockValue { get; set; }

    }
}

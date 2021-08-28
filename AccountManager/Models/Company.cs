using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class Company
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [Required]
        [DisplayName("About")] 
        public string About { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }
        [StringLength(100)] 
        [DisplayName("Website")] 
        public string Website { get; set; }
        [StringLength(13)] 
        [DisplayName("Phone")] 
        public string Phone { get; set; }
        [StringLength(15)] 
        [DisplayName("Fax")] 
        public string Fax { get; set; }
        public virtual ICollection<CompanyClient> CompanyClient_CompanyIds { get; set; }
        public virtual ICollection<CompanyAccount> CompanyAccount_CompanyIds { get; set; }
        public virtual ICollection<CompanyOffice> CompanyOffice_CompanyIds { get; set; }

    }
}

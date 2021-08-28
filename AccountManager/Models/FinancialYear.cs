using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class FinancialYear
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Start Date")] 
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("End Date")] 
        public DateTime EndDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountManager.ModelDto
{
    public class HomeDto
    {
        public int User { get; set; }
        public int Role { get; set; }
        public int Menu { get; set; }
        public int Company { get; set; }
        public int Invoice { get; set; }
        public int Transaction { get; set; }
        public int Product { get; set; }

        public Nullable<decimal> Asset { get; set; }
        public int AccountHoders { get; set; }

        
    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountManager.ModelDto;
using AccountManager.Models;
namespace AccountManager.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            HomeDto home = new HomeDto();

            using (SIContext db = new SIContext())
            {
                 
                 
                home.Asset =db.Transactions.Select(t => t.DebitAmount).Sum();
                home.AccountHoders = db.AccountHolders.Count();
                //home.Role = db.Roles.Count();
                //home.User = db.Users.Count();
                //home.Company = db.Companys.Count();
                home.Invoice = db.Invoices.Count();
                //home.Product = db.Products.Count();
                home.Transaction = db.Transactions.Count();

            }

            return View(home);

        }


        


        
      

     

       
    }
}

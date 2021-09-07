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


        public class DateTable
        {
            public DateTime DateAdded { get; set; }

        }


        public JsonResult LineChart(int lastDay)
        {
            
            List<GraphData> dataList = new List<GraphData>();

            var LastDays = DateTime.Now.Date.AddDays(-lastDay);
            SIContext db = new SIContext();
             
            ///listDateTable just add your table where have date field like db.User
            var LastRegister = db.Transactions.Where(i => i.TransactionDate >= LastDays).ToArray();

            for (int i = 0; i < lastDay; i++)
            {
                var dateDynamic = DateTime.Now.Date.AddDays(-i);
                int year = dateDynamic.Year;
                int month = dateDynamic.Month;
                int day = dateDynamic.Day;

                DateTime newDate = new DateTime(year, month, day);
                var hav = LastRegister.Count(j => j.DateAdded.Date == newDate.Date);
                if (hav > 0)
                {
                    GraphData gdata = new GraphData();
                    gdata.label = newDate.ToString("yyyy-MM-dd");
                    gdata.value = hav;
                    dataList.Add(gdata);
                }
                else
                {
                    GraphData gdata = new GraphData();
                    gdata.label = newDate.ToString("yyyy-MM-dd");
                    gdata.value = 0;
                    dataList.Add(gdata);
                }

            }

            return Json(dataList, JsonRequestBehavior.AllowGet);
        }
        private class GraphData
        {
            public string label { get; set; }
            public int value { get; set; }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

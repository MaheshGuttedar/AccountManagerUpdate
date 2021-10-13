using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AccountManager.Models;
using System.Globalization;

namespace AccountManager.Controllers
{
    public class TransactionController : BaseController
    { 
        // GET: /Transaction/
        public ActionResult Index()
        {
            return View();
        }

        // GET Transaction/GetGrid
        [HttpGet]
        public ActionResult GetGrid()
        {
           
            int srlno = 1;
            string link = "/Invoice/Create?";
            var tak = db.Transactions.ToArray();
            var result = from c in tak select new string[] { 
            c.Id.ToString(),
            Convert.ToString(srlno++),
              Convert.ToString(db.AccountHolders.Find(c.AccountHolderId).AccountNoFromRegister),
            Convert.ToString(Convert.ToDateTime( c.TransactionDate).ToShortDateString()),
            Convert.ToString(c.InstallmentNo),
            Convert.ToString(c.Title),
            Convert.ToString(c.HireCharge),
            Convert.ToString(c.DebitAmount),
            Convert.ToString(c.BalanceAmount-c.CreditAmount),
            Convert.ToString(c.CreditAmount),
            Convert.ToString(c.BalanceAmount),
            Convert.ToString(c.OverDueDays),
            Convert.ToString(c.OverDueAmount),
            Convert.ToString(db.FinancialYears.Find(c.YearId).StartDate),
            Convert.ToInt32(c.PaymentStatusId) ==0 ? "<a href='"+link+"id="+c.Id.ToString()+ "' >Generate Invoice </a>" :"Paid"
            };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);

        }
        // GET: /Transaction/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction ObjTransaction = db.Transactions.Find(id);
            if (ObjTransaction == null)
            {
                return HttpNotFound();
            }
            return View(ObjTransaction);
        }

        public static int getdays(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);

            return days;
        }

        // GET: /Transaction/Create
        public ActionResult Create(int? AccountId)
        {

            Transaction Objtransaction = new Transaction();
            AccountHolders ObjAccountHolders = db.AccountHolders.Find(AccountId);            
            ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate", ObjAccountHolders.YearId);
            ViewBag.AccountHolderId = new SelectList(db.AccountHolders, "Id", "Name", ObjAccountHolders.Id);
            int InstallmentNo = (from a in db.AccountHolders join t in db.Transactions on a.Id equals t.AccountHolderId where a.Id==AccountId select a.AccountId).Count();
            ViewBag.InstallmentNo = InstallmentNo + 1;
            ViewBag.LoanAdvanceDate = ObjAccountHolders.LoanAdvanceDate;
            //DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            //DateTime DtLoanAdvanceDate = DateTime.Parse(ObjAccountHolders.LoanAdvanceDate);
            string strLoanAdvanceDate = ObjAccountHolders.LoanAdvanceDate;
            DateTime dtLoanAdvanceDate = Convert.ToDateTime(strLoanAdvanceDate,System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            DateTime todayDate = DateTime.Today;         
            TimeSpan difference = todayDate - dtLoanAdvanceDate;            
            int OverDueDays =Convert.ToInt32(difference.TotalDays) - getdays(dtLoanAdvanceDate.Year, dtLoanAdvanceDate.Month);
            ViewBag.OverDueDays = OverDueDays;
            return View();
        }

        // POST: /Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Transaction ObjTransaction )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                ObjTransaction.DateAdded = DateTime.Now;
                ObjTransaction.AddedBy = int.Parse(Env.GetUserInfo("userid"));
                ObjTransaction.OfficeId = 1;
                if (ModelState.IsValid)
                {
                    ObjTransaction.PaymentStatusId = 0;
                    db.Transactions.Add(ObjTransaction);
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }
  
            return Content(sb.ToString());
             
        }
        // GET: /Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction ObjTransaction = db.Transactions.Find(id);
            if (ObjTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate", ObjTransaction.YearId);
            ViewBag.AccountHolderId = new SelectList(db.AccountHolders, "Id", "Name", ObjTransaction.AccountHolderId);

            return View(ObjTransaction);
        }

        // POST: /Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Transaction ObjTransaction )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                {

                    ObjTransaction.PaymentStatusId = 0;
                    db.Entry(ObjTransaction).State = EntityState.Modified;
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }
 
             
            return Content(sb.ToString());

        }
        // GET: /Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction ObjTransaction = db.Transactions.Find(id);
            if (ObjTransaction == null)
            {
                return HttpNotFound();
            }
            return View(ObjTransaction);
        }

        // POST: /Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    Transaction ObjTransaction = db.Transactions.Find(id);
                    db.Transactions.Remove(ObjTransaction);
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                 
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }
  
            return Content(sb.ToString());
  
        }
        // GET: /Transaction/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id,bool accountholder=false)
        { 
            Transaction ObjTransaction = db.Transactions.Find(id);
            if (ObjTransaction != null && accountholder==false)
            {
                ViewBag.IsWorking = 0;
                if (id > 0)
                {
                    ViewBag.IsWorking = id;
                    ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate", ObjTransaction.YearId);
                    ViewBag.AccountHolderId = new SelectList(db.AccountHolders, "Id", "Name", ObjTransaction.AccountHolderId);
                }
            }
            else if(accountholder)
            {
                AccountHolders ObjAccountHolders = db.AccountHolders.Find(id);
                ViewBag.IsWorking = id;
                ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate", ObjAccountHolders.YearId);
                ViewBag.AccountHolderId = new SelectList(db.AccountHolders, "Id", "Name", ObjAccountHolders.Id);
            }              
            return View(ObjTransaction);
        }

        // POST: /Transaction/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Transaction ObjTransaction )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjTransaction).State = EntityState.Modified;
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            } 
             
            return Content(sb.ToString());
 
        }
         public ActionResult InvoiceTransactionGetGrid(int id=0)
        {
            var tak = db.InvoiceTransactions.Where(i=>i.TransactionId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Invoice_InvoiceId.OtherInvoiceCode),Convert.ToString(c.TransactionId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
      
        // POST: /Transaction/NewEntry
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        public ActionResult NewEntry(int id)
        {
            AccountHolders ObjAccountHolders = db.AccountHolders.Where(x=>x.Id==id).FirstOrDefault();
            Transaction ObjTransaction = db.Transactions.Where(x => x.AccountHolderId == 10).FirstOrDefault();
            try
            {


                var tak = db.AccountHolders.Where(x => x.Id == id).ToArray();

                // ObjTransaction.DateAdded = DateTime.Now;
                // ObjTransaction.AddedBy = int.Parse(Env.GetUserInfo("userid"));
                // ObjTransaction.OfficeId = 1;               


                 ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate", ObjAccountHolders.YearId);
                 ViewBag.AccountHolderId = new SelectList(db.AccountHolders, "Id", "Name", ObjAccountHolders.Id);


            }
            catch (Exception ex)
            {
              
            }

            return View(ObjTransaction);

        }
        private SIContext db = new SIContext();
		
		
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
		 
    }
}


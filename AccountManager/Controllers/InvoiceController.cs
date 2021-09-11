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

namespace AccountManager.Controllers
{
    public class InvoiceController : BaseController
    { 
        // GET: /Invoice/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET Invoice/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Invoices.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), 
                Convert.ToString(c.Id), 
            Convert.ToString(c.BillDate), 
            Convert.ToString(c.DueDate), 
            Convert.ToString(c.PaymentStatus_Status.Title), 
           
            Convert.ToString(c.OtherInvoiceCode)            
              
             
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Invoice/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Invoice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice ObjInvoice = db.Invoices.Find(id);
            if (ObjInvoice == null)
            {
                return HttpNotFound();
            }
            return View(ObjInvoice);
        }
        // GET: /Invoice/Create
        public ActionResult Create()
        {
            ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate");
            ViewBag.AccountHolderId = new SelectList(db.AccountHolders, "Id", "Name");
            ViewBag.Status = new SelectList(db.PaymentStatuss, "Id", "Title");

            ViewBag.OfficeId = 1;
            ViewBag.CreatedBy = 1;

            return View();
        }

        // POST: /Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Invoice ObjInvoice )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                ObjInvoice.OfficeId = 1;
                ObjInvoice.CreatedBy = 1;

                ObjInvoice.ClientId = 1;

                if (ModelState.IsValid)
                { 
                    

                    db.Invoices.Add(ObjInvoice);
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
        // GET: /Invoice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice ObjInvoice = db.Invoices.Find(id);
            if (ObjInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(db.PaymentStatuss, "Id", "Title", ObjInvoice.Status);
ViewBag.ClientId = new SelectList(db.Users, "Id", "Username", ObjInvoice.ClientId);
            ViewBag.OfficeId = 1;

            return View(ObjInvoice);
        }

        // POST: /Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Invoice ObjInvoice )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjInvoice).State = EntityState.Modified;
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
        // GET: /Invoice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice ObjInvoice = db.Invoices.Find(id);
            if (ObjInvoice == null)
            {
                return HttpNotFound();
            }
            return View(ObjInvoice);
        }

        // POST: /Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    Invoice ObjInvoice = db.Invoices.Find(id);
                    db.Invoices.Remove(ObjInvoice);
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
        // GET: /Invoice/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Invoice ObjInvoice = db.Invoices.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.Status = new SelectList(db.PaymentStatuss, "Id", "Title", ObjInvoice.Status);
ViewBag.ClientId = new SelectList(db.Users, "Id", "Username", ObjInvoice.ClientId);
                ViewBag.OfficeId = 1;

            }
            
            return View(ObjInvoice);
        }

        // POST: /Invoice/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Invoice ObjInvoice )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjInvoice).State = EntityState.Modified;
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
            var tak = db.InvoiceTransactions.Where(i=>i.InvoiceId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.InvoiceId),
                Convert.ToString(c.Transaction_TransactionId.Title), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult InvoiceItemGetGrid(int id=0)
        {
            var tak = db.InvoiceItems.Where(i=>i.InvoiceId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Description),
                Convert.ToString(c.Title),
                Convert.ToString(c.Quantity),
                Convert.ToString(c.UnitPrice),
                Convert.ToString(c.Id),
                Convert.ToString(c.Total),
                Convert.ToString(c.InvoiceId),
                Convert.ToString(c.QuantityUnit_UnitName.Id), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
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


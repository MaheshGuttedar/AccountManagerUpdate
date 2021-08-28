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
    public class InvoiceTransactionController : BaseController
    { 
        // GET: /InvoiceTransaction/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET InvoiceTransaction/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.InvoiceTransactions.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Transaction_TransactionId.Title), 
            Convert.ToString(c.Invoice_InvoiceId.OtherInvoiceCode), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /InvoiceTransaction/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /InvoiceTransaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceTransaction ObjInvoiceTransaction = db.InvoiceTransactions.Find(id);
            if (ObjInvoiceTransaction == null)
            {
                return HttpNotFound();
            }
            return View(ObjInvoiceTransaction);
        }
        // GET: /InvoiceTransaction/Create
        public ActionResult Create()
        {
             ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Title");
ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "OtherInvoiceCode");

             return View();
        }

        // POST: /InvoiceTransaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(InvoiceTransaction ObjInvoiceTransaction )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.InvoiceTransactions.Add(ObjInvoiceTransaction);
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
        // GET: /InvoiceTransaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceTransaction ObjInvoiceTransaction = db.InvoiceTransactions.Find(id);
            if (ObjInvoiceTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Title", ObjInvoiceTransaction.TransactionId);
ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "OtherInvoiceCode", ObjInvoiceTransaction.InvoiceId);

            return View(ObjInvoiceTransaction);
        }

        // POST: /InvoiceTransaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(InvoiceTransaction ObjInvoiceTransaction )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjInvoiceTransaction).State = EntityState.Modified;
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
        // GET: /InvoiceTransaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceTransaction ObjInvoiceTransaction = db.InvoiceTransactions.Find(id);
            if (ObjInvoiceTransaction == null)
            {
                return HttpNotFound();
            }
            return View(ObjInvoiceTransaction);
        }

        // POST: /InvoiceTransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    InvoiceTransaction ObjInvoiceTransaction = db.InvoiceTransactions.Find(id);
                    db.InvoiceTransactions.Remove(ObjInvoiceTransaction);
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
        // GET: /InvoiceTransaction/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            InvoiceTransaction ObjInvoiceTransaction = db.InvoiceTransactions.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Title", ObjInvoiceTransaction.TransactionId);
ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "OtherInvoiceCode", ObjInvoiceTransaction.InvoiceId);

            }
            
            return View(ObjInvoiceTransaction);
        }

        // POST: /InvoiceTransaction/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(InvoiceTransaction ObjInvoiceTransaction )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjInvoiceTransaction).State = EntityState.Modified;
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


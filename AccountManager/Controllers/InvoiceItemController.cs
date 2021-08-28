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
    public class InvoiceItemController : BaseController
    { 
        // GET: /InvoiceItem/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET InvoiceItem/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.InvoiceItems.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Invoice_InvoiceId.OtherInvoiceCode), 
            Convert.ToString(c.Description), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.Quantity), 
            Convert.ToString(c.UnitPrice), 
            Convert.ToString(c.QuantityUnit_UnitName.Id), 
            Convert.ToString(c.Total), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /InvoiceItem/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /InvoiceItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceItem ObjInvoiceItem = db.InvoiceItems.Find(id);
            if (ObjInvoiceItem == null)
            {
                return HttpNotFound();
            }
            return View(ObjInvoiceItem);
        }
        // GET: /InvoiceItem/Create
        public ActionResult Create()
        {
             ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "OtherInvoiceCode");
ViewBag.UnitName = new SelectList(db.QuantityUnits, "Id", "Id");

             return View();
        }

        // POST: /InvoiceItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(InvoiceItem ObjInvoiceItem )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.InvoiceItems.Add(ObjInvoiceItem);
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
        // GET: /InvoiceItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceItem ObjInvoiceItem = db.InvoiceItems.Find(id);
            if (ObjInvoiceItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "OtherInvoiceCode", ObjInvoiceItem.InvoiceId);
ViewBag.UnitName = new SelectList(db.QuantityUnits, "Id", "Id", ObjInvoiceItem.UnitName);

            return View(ObjInvoiceItem);
        }

        // POST: /InvoiceItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(InvoiceItem ObjInvoiceItem )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjInvoiceItem).State = EntityState.Modified;
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
        // GET: /InvoiceItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceItem ObjInvoiceItem = db.InvoiceItems.Find(id);
            if (ObjInvoiceItem == null)
            {
                return HttpNotFound();
            }
            return View(ObjInvoiceItem);
        }

        // POST: /InvoiceItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    InvoiceItem ObjInvoiceItem = db.InvoiceItems.Find(id);
                    db.InvoiceItems.Remove(ObjInvoiceItem);
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
        // GET: /InvoiceItem/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            InvoiceItem ObjInvoiceItem = db.InvoiceItems.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "OtherInvoiceCode", ObjInvoiceItem.InvoiceId);
ViewBag.UnitName = new SelectList(db.QuantityUnits, "Id", "Id", ObjInvoiceItem.UnitName);

            }
            
            return View(ObjInvoiceItem);
        }

        // POST: /InvoiceItem/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(InvoiceItem ObjInvoiceItem )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjInvoiceItem).State = EntityState.Modified;
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


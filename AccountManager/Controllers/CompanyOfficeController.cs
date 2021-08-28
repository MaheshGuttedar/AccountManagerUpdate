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
    public class CompanyOfficeController : BaseController
    { 
        // GET: /CompanyOffice/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET CompanyOffice/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.CompanyOffices.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.Code), 
            Convert.ToString(c.CreatedOn), 
            Convert.ToString(c.OfficeType_OfficeTypeId.Name), 
            Convert.ToString(c.Company_CompanyId.Name), 
             };
            
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /CompanyOffice/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /CompanyOffice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOffice ObjCompanyOffice = db.CompanyOffices.Find(id);
            if (ObjCompanyOffice == null)
            {
                return HttpNotFound();
            }
            return View(ObjCompanyOffice);
        }
        // GET: /CompanyOffice/Create
        public ActionResult Create()
        {
             ViewBag.OfficeTypeId = new SelectList(db.OfficeTypes, "Id", "Name");
ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name");

             return View();
        }

        // POST: /CompanyOffice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CompanyOffice ObjCompanyOffice )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.CompanyOffices.Add(ObjCompanyOffice);
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
        // GET: /CompanyOffice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOffice ObjCompanyOffice = db.CompanyOffices.Find(id);
            if (ObjCompanyOffice == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeTypeId = new SelectList(db.OfficeTypes, "Id", "Name", ObjCompanyOffice.OfficeTypeId);
ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name", ObjCompanyOffice.CompanyId);

            return View(ObjCompanyOffice);
        }

        // POST: /CompanyOffice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(CompanyOffice ObjCompanyOffice )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjCompanyOffice).State = EntityState.Modified;
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
        // GET: /CompanyOffice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOffice ObjCompanyOffice = db.CompanyOffices.Find(id);
            if (ObjCompanyOffice == null)
            {
                return HttpNotFound();
            }
            return View(ObjCompanyOffice);
        }

        // POST: /CompanyOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    CompanyOffice ObjCompanyOffice = db.CompanyOffices.Find(id);
                    db.CompanyOffices.Remove(ObjCompanyOffice);
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
        // GET: /CompanyOffice/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            CompanyOffice ObjCompanyOffice = db.CompanyOffices.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.OfficeTypeId = new SelectList(db.OfficeTypes, "Id", "Name", ObjCompanyOffice.OfficeTypeId);
ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name", ObjCompanyOffice.CompanyId);

            }
            
            return View(ObjCompanyOffice);
        }

        // POST: /CompanyOffice/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(CompanyOffice ObjCompanyOffice )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjCompanyOffice).State = EntityState.Modified;
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
         public ActionResult TransactionGetGrid(int id=0)
        {
            var tak = db.Transactions.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Title),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.CreditAmount),
                Convert.ToString(c.TransactionDate),
                Convert.ToString(c.DebitAmount),
                Convert.ToString(c.LedgerAccountType_DebitAccount.Title),Convert.ToString(c.LedgerAccountType_CreditAccount.Title),Convert.ToString(c.OfficeId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult ProductGetGrid(int id=0)
        {
            var tak = db.Products.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.IsActive),
                Convert.ToString(c.ProductImage),
                Convert.ToString(c.BareCode),
                Convert.ToString(c.Description),
                Convert.ToString(c.ReOrderValue),
                Convert.ToString(c.Stock),
                Convert.ToString(c.MinStockValue),
                Convert.ToString(c.Id),
                Convert.ToString(c.Name),
                Convert.ToString(c.PurchaseCost),
                Convert.ToString(c.SalePrice),
                Convert.ToString(c.OfficeId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult InvoiceGetGrid(int id=0)
        {
            var tak = db.Invoices.Where(i=>i.OfficeId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.BillDate),
                Convert.ToString(c.DueDate),
                Convert.ToString(c.LastEmailed),
                Convert.ToString(c.OtherInvoiceCode),
                Convert.ToString(c.CreatedBy),
                Convert.ToString(c.User_ClientId.Username),Convert.ToString(c.PaymentStatus_Status.Title),Convert.ToString(c.OfficeId),
                 };
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


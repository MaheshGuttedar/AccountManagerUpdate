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
    public class LedgerAccountTypeController : BaseController
    { 
        // GET: /LedgerAccountType/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET LedgerAccountType/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.LedgerAccountTypes.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.ParentId),
 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /LedgerAccountType/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /LedgerAccountType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedgerAccountType ObjLedgerAccountType = db.LedgerAccountTypes.Find(id);
            if (ObjLedgerAccountType == null)
            {
                return HttpNotFound();
            }
            return View(ObjLedgerAccountType);
        }
        // GET: /LedgerAccountType/Create
        public ActionResult Create()
        {
             ViewBag.ParentId = new SelectList(db.LedgerAccountTypes, "Id", "Title");

             return View();
        }

        // POST: /LedgerAccountType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(LedgerAccountType ObjLedgerAccountType )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.LedgerAccountTypes.Add(ObjLedgerAccountType);
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
        // GET: /LedgerAccountType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedgerAccountType ObjLedgerAccountType = db.LedgerAccountTypes.Find(id);
            if (ObjLedgerAccountType == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.LedgerAccountTypes, "Id", "Title", ObjLedgerAccountType.ParentId);

            return View(ObjLedgerAccountType);
        }

        // POST: /LedgerAccountType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(LedgerAccountType ObjLedgerAccountType )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjLedgerAccountType).State = EntityState.Modified;
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
        // GET: /LedgerAccountType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedgerAccountType ObjLedgerAccountType = db.LedgerAccountTypes.Find(id);
            if (ObjLedgerAccountType == null)
            {
                return HttpNotFound();
            }
            return View(ObjLedgerAccountType);
        }

        // POST: /LedgerAccountType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    LedgerAccountType ObjLedgerAccountType = db.LedgerAccountTypes.Find(id);
                    db.LedgerAccountTypes.Remove(ObjLedgerAccountType);
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
        // GET: /LedgerAccountType/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            LedgerAccountType ObjLedgerAccountType = db.LedgerAccountTypes.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.ParentId = new SelectList(db.LedgerAccountTypes, "Id", "Title", ObjLedgerAccountType.ParentId);

            }
            
            return View(ObjLedgerAccountType);
        }

        // POST: /LedgerAccountType/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(LedgerAccountType ObjLedgerAccountType )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjLedgerAccountType).State = EntityState.Modified;
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
            var tak = db.Transactions.ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Title),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.CreditAmount),
                Convert.ToString(c.TransactionDate),
                Convert.ToString(c.DebitAmount),
                Convert.ToString(c.DebitAccount),
               // Convert.ToString(c.CreditAccount),
                Convert.ToString(c.CompanyOffice_OfficeId.Title), };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult TransactionGetGrid1(int id=0)
        {
            var tak = db.Transactions.ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Title),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.CreditAmount),
                Convert.ToString(c.TransactionDate),
                Convert.ToString(c.DebitAmount),
                Convert.ToString(c.DebitAccount),
              //  Convert.ToString(c.CreditAccount),
                Convert.ToString(c.CompanyOffice_OfficeId.Title), };
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


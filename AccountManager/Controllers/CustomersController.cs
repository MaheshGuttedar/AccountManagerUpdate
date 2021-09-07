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
    public class CustomersController : BaseController
    {
        // GET: /Customers/
        public ActionResult Index()
        {
            return View();
        }

        // GET Customers/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.AccountHolders.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(),
            Convert.ToString(c.Id),               
           // Convert.ToString(1),//c.CompanyId
           //  Convert.ToString(c.AccountId),//c.CompanyId
            Convert.ToString(c.Name),
            Convert.ToString(c.Name),
           // Convert.ToString(c.IsActive),
            Convert.ToString(c.Email),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Customers/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountHolders ObjAccountHolders = db.AccountHolders.Find(id);
            if (ObjAccountHolders == null)
            {
                return HttpNotFound();
            }
            return View(ObjAccountHolders);
        }
        // GET: /Customers/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.LedgerAccountTypes, "Id", "Title");

            return View();
        }

        // POST: /Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(AccountHolders ObjAccountHolders)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.AccountHolders.Add(ObjAccountHolders);
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
        // GET: /Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountHolders ObjAccountHolders = db.AccountHolders.Find(id);
            if (ObjAccountHolders == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.LedgerAccountTypes, "Id", "Title", ObjAccountHolders.Id);

            return View(ObjAccountHolders);
        }

        // POST: /Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(AccountHolders ObjAccountHolders)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjAccountHolders).State = EntityState.Modified;
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
        // GET: /Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountHolders ObjAccountHolders = db.AccountHolders.Find(id);
            if (ObjAccountHolders == null)
            {
                return HttpNotFound();
            }
            return View(ObjAccountHolders);
        }

        // POST: /Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                AccountHolders ObjAccountHolders = db.AccountHolders.Find(id);
                db.AccountHolders.Remove(ObjAccountHolders);
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
        // GET: /Customers/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            AccountHolders ObjAccountHolders = db.AccountHolders.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.AccountId = new SelectList(db.LedgerAccountTypes, "Id", "Title", ObjAccountHolders.Id);

            }

            return View(ObjAccountHolders);
        }

        // POST: /Customers/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(AccountHolders ObjAccountHolders)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjAccountHolders).State = EntityState.Modified;
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


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
    public class CompanyAccountController : BaseController
    { 
        // GET: /CompanyAccount/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET CompanyAccount/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.CompanyAccounts.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Type), 
            Convert.ToString(c.URL), 
            Convert.ToString(c.Usename), 
            Convert.ToString(c.Password), 
            Convert.ToString(c.Company_CompanyId.Name), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /CompanyAccount/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /CompanyAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyAccount ObjCompanyAccount = db.CompanyAccounts.Find(id);
            if (ObjCompanyAccount == null)
            {
                return HttpNotFound();
            }
            return View(ObjCompanyAccount);
        }
        // GET: /CompanyAccount/Create
        public ActionResult Create()
        {
             ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name");

             return View();
        }

        // POST: /CompanyAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CompanyAccount ObjCompanyAccount )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.CompanyAccounts.Add(ObjCompanyAccount);
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
        // GET: /CompanyAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyAccount ObjCompanyAccount = db.CompanyAccounts.Find(id);
            if (ObjCompanyAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name", ObjCompanyAccount.CompanyId);

            return View(ObjCompanyAccount);
        }

        // POST: /CompanyAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(CompanyAccount ObjCompanyAccount )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjCompanyAccount).State = EntityState.Modified;
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
        // GET: /CompanyAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyAccount ObjCompanyAccount = db.CompanyAccounts.Find(id);
            if (ObjCompanyAccount == null)
            {
                return HttpNotFound();
            }
            return View(ObjCompanyAccount);
        }

        // POST: /CompanyAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    CompanyAccount ObjCompanyAccount = db.CompanyAccounts.Find(id);
                    db.CompanyAccounts.Remove(ObjCompanyAccount);
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
        // GET: /CompanyAccount/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            CompanyAccount ObjCompanyAccount = db.CompanyAccounts.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name", ObjCompanyAccount.CompanyId);

            }
            
            return View(ObjCompanyAccount);
        }

        // POST: /CompanyAccount/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(CompanyAccount ObjCompanyAccount )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjCompanyAccount).State = EntityState.Modified;
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


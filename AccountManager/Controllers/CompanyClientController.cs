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
    public class CompanyClientController : BaseController
    { 
        // GET: /CompanyClient/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET CompanyClient/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.CompanyClients.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Company_CompanyId.Name), 
            Convert.ToString(c.FirstName), 
            Convert.ToString(c.LastName), 
            Convert.ToString(c.IsActive), 
            Convert.ToString(c.Email), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /CompanyClient/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /CompanyClient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyClient ObjCompanyClient = db.CompanyClients.Find(id);
            if (ObjCompanyClient == null)
            {
                return HttpNotFound();
            }
            return View(ObjCompanyClient);
        }
        // GET: /CompanyClient/Create
        public ActionResult Create()
        {
             ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name");

             return View();
        }

        // POST: /CompanyClient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CompanyClient ObjCompanyClient )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.CompanyClients.Add(ObjCompanyClient);
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
        // GET: /CompanyClient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyClient ObjCompanyClient = db.CompanyClients.Find(id);
            if (ObjCompanyClient == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name", ObjCompanyClient.CompanyId);

            return View(ObjCompanyClient);
        }

        // POST: /CompanyClient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(CompanyClient ObjCompanyClient )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjCompanyClient).State = EntityState.Modified;
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
        // GET: /CompanyClient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyClient ObjCompanyClient = db.CompanyClients.Find(id);
            if (ObjCompanyClient == null)
            {
                return HttpNotFound();
            }
            return View(ObjCompanyClient);
        }

        // POST: /CompanyClient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    CompanyClient ObjCompanyClient = db.CompanyClients.Find(id);
                    db.CompanyClients.Remove(ObjCompanyClient);
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
        // GET: /CompanyClient/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            CompanyClient ObjCompanyClient = db.CompanyClients.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.CompanyId = new SelectList(db.Companys, "Id", "Name", ObjCompanyClient.CompanyId);

            }
            
            return View(ObjCompanyClient);
        }

        // POST: /CompanyClient/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(CompanyClient ObjCompanyClient )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjCompanyClient).State = EntityState.Modified;
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


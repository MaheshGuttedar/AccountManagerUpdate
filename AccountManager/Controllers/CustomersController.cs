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
            int slrno = 1;
            var tak = db.AccountHolders.ToArray();
            var result = from c in tak  select new string[] {
            Convert.ToString(c.Id),
            Convert.ToString(slrno++),             
            Convert.ToString(c.Name),
            Convert.ToString(c.AccountNoFromRegister),
            Convert.ToString(c.InstallmentAmount + " * "+Convert.ToString(c.TotalInstallments - Convert.ToInt16(db.Transactions.Count(m=>m.AccountHolderId==c.Id)))),
            Convert.ToString(c.InstallmentAmount*Convert.ToInt64(c.TotalInstallments - Convert.ToInt16(db.Transactions.Count(m=>m.AccountHolderId==c.Id)))),
           
            Convert.ToString(Convert.ToInt16(db.Transactions.Count(m=>m.AccountHolderId==c.Id))),//completed inst
            Convert.ToString(c.TotalInstallments - Convert.ToInt16(db.Transactions.Count(m=>m.AccountHolderId==c.Id))),//pending inst
             Convert.ToString(c.Make),
             Convert.ToString(c.TotalInstallments),
            Convert.ToString(c.Mobile),
           
            Convert.ToString(db.FinancialYears.Find(c.YearId).StartDate),
             Convert.ToString(c.Id)

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
            ViewBag.AccountId = 1;
            ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate");
            

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
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files["ImageData"];
                    ObjAccountHolders.CustomerPhoto = ConvertToBytes(file);
                }
                if (ModelState.IsValid)
                {
                    ObjAccountHolders.IsActive = true;
                    db.AccountHolders.Add(ObjAccountHolders);
                    int i=db.SaveChanges();
                    if (i == 1)
                    {
                        return RedirectToAction("Index");
                    }
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
            ViewBag.AccountId = 1;
            ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate", ObjAccountHolders.Id);
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
            byte[] cover = GetImageFromDataBase(id.GetValueOrDefault());
            if (cover != null)
            {
                ObjAccountHolders.CustomerPhoto = cover;
            }
            else
            {
                ObjAccountHolders.CustomerPhoto = null;
            }       
            
            ViewBag.IsWorking = 1;
            ViewBag.AccountId = 1;
            ObjAccountHolders.CreatedDate = DateTime.Now.ToString();
            ViewBag.YearId = new SelectList(db.FinancialYears, "Id", "StartDate", ObjAccountHolders.YearId);
            return View(ObjAccountHolders);
        }

        // POST: /Customers/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
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
                    HttpPostedFileBase file = Request.Files["ImageData"];                     
                    ObjAccountHolders.CustomerPhoto = ConvertToBytes(file); 
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

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

       
        // GET Customers/getallAccountholders
        public ActionResult getallAccountholders()
        {
            return Json(db.AccountHolders.Select(x => new
            {
                Text = x.Id,
                Value = x.Name
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        private SIContext db = new SIContext();
        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in db.AccountHolders where temp.Id == Id select temp.CustomerPhoto;
            byte[] cover = q.First();
            return cover;
        }
        // GET Customers/RetrieveImage
        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
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


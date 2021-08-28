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
    public class ProductController : BaseController
    { 
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET Product/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Products.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Name), 
            Convert.ToString(c.PurchaseCost), 
            Convert.ToString(c.SalePrice), 
            Convert.ToString(c.CompanyOffice_OfficeId.Title), 
            Convert.ToString(c.IsActive), 
            Convert.ToString(c.ProductImage), 
            Convert.ToString(c.BareCode), 
            Convert.ToString(c.Description), 
            Convert.ToString(c.ReOrderValue), 
            Convert.ToString(c.Stock), 
            Convert.ToString(c.MinStockValue), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Product/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product ObjProduct = db.Products.Find(id);
            if (ObjProduct == null)
            {
                return HttpNotFound();
            }
            return View(ObjProduct);
        }
        // GET: /Product/Create
        public ActionResult Create()
        {
             ViewBag.OfficeId = new SelectList(db.CompanyOffices, "Id", "Title");

             return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Product ObjProduct ,HttpPostedFileBase ProductImage,string HideImage1)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (ProductImage != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(ProductImage, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjProduct.ProductImage = fileName; 
                    } 
                    else 
                    { 
                        ObjProduct.ProductImage = HideImage1;  
                    }


                    db.Products.Add(ObjProduct);
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
        // GET: /Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product ObjProduct = db.Products.Find(id);
            if (ObjProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(db.CompanyOffices, "Id", "Title", ObjProduct.OfficeId);

            return View(ObjProduct);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Product ObjProduct ,HttpPostedFileBase ProductImage,string HideImage1)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (ProductImage != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(ProductImage, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjProduct.ProductImage = fileName; 
                    } 
                    else 
                    { 
                        ObjProduct.ProductImage = HideImage1;  
                    }


                    db.Entry(ObjProduct).State = EntityState.Modified;
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
        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product ObjProduct = db.Products.Find(id);
            if (ObjProduct == null)
            {
                return HttpNotFound();
            }
            return View(ObjProduct);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    Product ObjProduct = db.Products.Find(id);
                    db.Products.Remove(ObjProduct);
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
        // GET: /Product/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Product ObjProduct = db.Products.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.OfficeId = new SelectList(db.CompanyOffices, "Id", "Title", ObjProduct.OfficeId);

            }
            
            return View(ObjProduct);
        }

        // POST: /Product/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Product ObjProduct ,HttpPostedFileBase ProductImage,string HideImage1)
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (ProductImage != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(ProductImage, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjProduct.ProductImage = fileName; 
                    } 
                    else 
                    { 
                        ObjProduct.ProductImage = HideImage1;  
                    }


                    db.Entry(ObjProduct).State = EntityState.Modified;
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


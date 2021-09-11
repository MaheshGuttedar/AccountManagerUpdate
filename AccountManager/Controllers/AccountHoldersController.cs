using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountManager.Models;

namespace AccountManager.Controllers
{
    public class AccountHoldersController : Controller
    {
        private SIContext db = new SIContext();

        // GET: AccountHolders
        public ActionResult Index()
        {
            return View(db.AccountHolders.ToList());
        }

        // GET: AccountHolders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountHolders accountHolders = db.AccountHolders.Find(id);
            if (accountHolders == null)
            {
                return HttpNotFound();
            }
            return View(accountHolders);
        }

        // GET: AccountHolders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountHolders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Mobile,GuarantorName,GuarantorAddress,GuarantorMobile,Cell,RegNo,Model,Make,ChassisNo,EngineNo,InsuranceUpto,DueDate,Email,IsActive,CompanyId,AccountId,YearId,TotalInstallments,LoanAdvance,InstallmentAmount,Status,AccountNoFromRegister,CustomerPhoto,CustomerPhoto")] AccountHolders accountHolders)
        {
            if (ModelState.IsValid)
            {
                db.AccountHolders.Add(accountHolders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountHolders);
        }

        // GET: AccountHolders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountHolders accountHolders = db.AccountHolders.Find(id);
            if (accountHolders == null)
            {
                return HttpNotFound();
            }
            return View(accountHolders);
        }

        // POST: AccountHolders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,IsActive,CompanyId")] AccountHolders accountHolders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountHolders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountHolders);
        }

        // GET: AccountHolders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountHolders accountHolders = db.AccountHolders.Find(id);
            if (accountHolders == null)
            {
                return HttpNotFound();
            }
            return View(accountHolders);
        }

        // POST: AccountHolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountHolders accountHolders = db.AccountHolders.Find(id);
            db.AccountHolders.Remove(accountHolders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: AccountHolders/GetAccountHolderNames/2010
        public ActionResult GetAccountHolderNames(int YearId)
        {
            
            var accountHolders = db.AccountHolders.Where(x => x.YearId == YearId).Select(n => n.Name).ToList();
          

          
            if (accountHolders == null)
            {
                return HttpNotFound();
            }
            return View(accountHolders);
        }
        // GET AccountHolders/getallAccountholders
        public ActionResult getallAccountholderstest()
        {
            var tak = db.AccountHolders.ToArray();
            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Name)

             };
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        // GET AccountHolders/getallAccountholders
        public JsonResult getallAccountholders()
        {
            var result = (from obj in db.AccountHolders
                                     select new SelectListItem()
                                     {
                                         Text = obj.Id.ToString(),
                                         Value = obj.Name.ToString(),
                                     }).ToList();

            return Json(new { result }, JsonRequestBehavior.AllowGet);
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

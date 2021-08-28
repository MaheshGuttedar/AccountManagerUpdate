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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,IsActive,CompanyId")] AccountHolders accountHolders)
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

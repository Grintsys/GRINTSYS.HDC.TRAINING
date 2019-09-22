using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountEntriesController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: AccountEntries
        public ActionResult Index()
        {
            var accountEntries = db.AccountEntries.Include(a => a.Account);
            return View(accountEntries.ToList());
        }

        // GET: AccountEntries/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountEntry accountEntry = db.AccountEntries.Find(id);
            if (accountEntry == null)
            {
                return HttpNotFound();
            }
            return View(accountEntry);
        }

        // GET: AccountEntries/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "AccNumber");
            return View();
        }

        // POST: AccountEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountId,Description,Debit,Credit,CreatedDate,ModifiedDate,ModifiedBy,IsEnable,IsDelete")] AccountEntry accountEntry)
        {
            if (ModelState.IsValid)
            {
                db.AccountEntries.Add(accountEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "AccNumber", accountEntry.AccountId);
            return View(accountEntry);
        }

        // GET: AccountEntries/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountEntry accountEntry = db.AccountEntries.Find(id);
            if (accountEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "AccNumber", accountEntry.AccountId);
            return View(accountEntry);
        }

        // POST: AccountEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountId,Description,Debit,Credit,CreatedDate,ModifiedDate,ModifiedBy,IsEnable,IsDelete")] AccountEntry accountEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "AccNumber", accountEntry.AccountId);
            return View(accountEntry);
        }

        // GET: AccountEntries/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountEntry accountEntry = db.AccountEntries.Find(id);
            if (accountEntry == null)
            {
                return HttpNotFound();
            }
            return View(accountEntry);
        }

        // POST: AccountEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AccountEntry accountEntry = db.AccountEntries.Find(id);
            db.AccountEntries.Remove(accountEntry);
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

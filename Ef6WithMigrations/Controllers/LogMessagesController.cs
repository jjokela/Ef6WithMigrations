using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ef6WithMigrations.Models;

namespace Ef6WithMigrations.Controllers
{
    public class LogMessagesController : Controller
    {
        private LogMessgeContext db = new LogMessgeContext();

        // GET: LogMessages
        public ActionResult Index()
        {
            return View(db.LogMessages.ToList());
        }

        // GET: LogMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogMessage logMessage = db.LogMessages.Find(id);
            if (logMessage == null)
            {
                return HttpNotFound();
            }
            return View(logMessage);
        }

        // GET: LogMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message,Created")] LogMessage logMessage)
        {
            if (ModelState.IsValid)
            {
                db.LogMessages.Add(logMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logMessage);
        }

        // GET: LogMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogMessage logMessage = db.LogMessages.Find(id);
            if (logMessage == null)
            {
                return HttpNotFound();
            }
            return View(logMessage);
        }

        // POST: LogMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message,Created")] LogMessage logMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logMessage);
        }

        // GET: LogMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogMessage logMessage = db.LogMessages.Find(id);
            if (logMessage == null)
            {
                return HttpNotFound();
            }
            return View(logMessage);
        }

        // POST: LogMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogMessage logMessage = db.LogMessages.Find(id);
            db.LogMessages.Remove(logMessage);
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

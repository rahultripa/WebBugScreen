using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using screenshare3.Models;

namespace screenshare3.Controllers
{
    public class JDADebugInfoesMvcController : Controller
    {
        private screenshare3Context db = new screenshare3Context();

        // GET: JDADebugInfoesMvc
        public ActionResult Index()
        {
            return View(db.JDADebugInfoes.ToList());
        }

        // GET: JDADebugInfoesMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
       
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JDADebugInfo jDADebugInfo = db.JDADebugInfoes.Find(id);
            if (jDADebugInfo == null)
            {
                return HttpNotFound();
            }
      return Redirect("~/JdaBugViiew/Index?bugId=" + id);
     // return View(jDADebugInfo);
        }

        // GET: JDADebugInfoesMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JDADebugInfoesMvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BugName,ClientName,CreatedBy,AnalyticsInfo,CurrentDate")] JDADebugInfo jDADebugInfo)
        {
            if (ModelState.IsValid)
            {
                db.JDADebugInfoes.Add(jDADebugInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jDADebugInfo);
        }

        // GET: JDADebugInfoesMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JDADebugInfo jDADebugInfo = db.JDADebugInfoes.Find(id);
            if (jDADebugInfo == null)
            {
                return HttpNotFound();
            }
            return View(jDADebugInfo);
        }

        // POST: JDADebugInfoesMvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BugName,ClientName,CreatedBy,AnalyticsInfo,CurrentDate")] JDADebugInfo jDADebugInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jDADebugInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jDADebugInfo);
        }

        // GET: JDADebugInfoesMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JDADebugInfo jDADebugInfo = db.JDADebugInfoes.Find(id);
            if (jDADebugInfo == null)
            {
                return HttpNotFound();
            }
            return View(jDADebugInfo);
        }

        // POST: JDADebugInfoesMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JDADebugInfo jDADebugInfo = db.JDADebugInfoes.Find(id);
            db.JDADebugInfoes.Remove(jDADebugInfo);
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

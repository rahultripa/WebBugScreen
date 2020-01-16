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
    public class JDADebugActivityInfoesMvcController : Controller
    {
        private screenshare3Context db = new screenshare3Context();

        // GET: JDADebugActivityInfoesMvc
        public ActionResult Index()
        {
            return View(db.JDADebugActivityInfoes.ToList());
        }

        // GET: JDADebugActivityInfoesMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JDADebugActivityInfo jDADebugActivityInfo = db.JDADebugActivityInfoes.Find(id);
            if (jDADebugActivityInfo == null)
            {
                return HttpNotFound();
            }
            return View(jDADebugActivityInfo);
        }

        // GET: JDADebugActivityInfoesMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JDADebugActivityInfoesMvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ScreenShot,ActivityData,BuildData,AnalyticsInfo,NetworkData,DeviceOrientation,BugId,CurrentDate,CPUUses,MemoryUses,DataFreme,VirtualMemory,SpaceUses")] JDADebugActivityInfo jDADebugActivityInfo)
        {
            if (ModelState.IsValid)
            {
                db.JDADebugActivityInfoes.Add(jDADebugActivityInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jDADebugActivityInfo);
        }

        // GET: JDADebugActivityInfoesMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JDADebugActivityInfo jDADebugActivityInfo = db.JDADebugActivityInfoes.Find(id);
            if (jDADebugActivityInfo == null)
            {
                return HttpNotFound();
            }
            return View(jDADebugActivityInfo);
        }

        // POST: JDADebugActivityInfoesMvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ScreenShot,ActivityData,BuildData,AnalyticsInfo,NetworkData,DeviceOrientation,BugId,CurrentDate,CPUUses,MemoryUses,DataFreme,VirtualMemory,SpaceUses")] JDADebugActivityInfo jDADebugActivityInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jDADebugActivityInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jDADebugActivityInfo);
        }

        // GET: JDADebugActivityInfoesMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JDADebugActivityInfo jDADebugActivityInfo = db.JDADebugActivityInfoes.Find(id);
            if (jDADebugActivityInfo == null)
            {
                return HttpNotFound();
            }
            return View(jDADebugActivityInfo);
        }

        // POST: JDADebugActivityInfoesMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JDADebugActivityInfo jDADebugActivityInfo = db.JDADebugActivityInfoes.Find(id);
            db.JDADebugActivityInfoes.Remove(jDADebugActivityInfo);
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

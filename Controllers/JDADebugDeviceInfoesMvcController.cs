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
    public class JDADebugDeviceInfoesMvcController : Controller
    {
        private screenshare3Context db = new screenshare3Context();

        // GET: JDADebugDeviceInfoesMvc
        public ActionResult Index()
        {
            return View(db.JDADebugDeviceInfoes.ToList());
        }

        // GET: JDADebugDeviceInfoesMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JDADebugDeviceInfo jDADebugDeviceInfo = db.JDADebugDeviceInfoes.Find(id);
            if (jDADebugDeviceInfo == null)
            {
                return HttpNotFound();
            }
            return View(jDADebugDeviceInfo);
        }

        // GET: JDADebugDeviceInfoesMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JDADebugDeviceInfoesMvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DeviceName,DeviceType,Model,Manufacturer,DevicePlatform,DeviceVersion,BugId,CurrentDate,vession,build,ScreenResolution,batterylevel,DeviceLang,CurrentNetwork,CurrentProfile,MaxCPU,MaxMemory,MaxDataFreme,MaxVirtualMemory,MaxSpace")] JDADebugDeviceInfo jDADebugDeviceInfo)
        {
            if (ModelState.IsValid)
            {
                db.JDADebugDeviceInfoes.Add(jDADebugDeviceInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jDADebugDeviceInfo);
        }

        // GET: JDADebugDeviceInfoesMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JDADebugDeviceInfo jDADebugDeviceInfo = db.JDADebugDeviceInfoes.Find(id);
            if (jDADebugDeviceInfo == null)
            {
                return HttpNotFound();
            }
            return View(jDADebugDeviceInfo);
        }

        // POST: JDADebugDeviceInfoesMvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DeviceName,DeviceType,Model,Manufacturer,DevicePlatform,DeviceVersion,BugId,CurrentDate,vession,build,ScreenResolution,batterylevel,DeviceLang,CurrentNetwork,CurrentProfile,MaxCPU,MaxMemory,MaxDataFreme,MaxVirtualMemory,MaxSpace")] JDADebugDeviceInfo jDADebugDeviceInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jDADebugDeviceInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jDADebugDeviceInfo);
        }

        // GET: JDADebugDeviceInfoesMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JDADebugDeviceInfo jDADebugDeviceInfo = db.JDADebugDeviceInfoes.Find(id);
            if (jDADebugDeviceInfo == null)
            {
                return HttpNotFound();
            }
            return View(jDADebugDeviceInfo);
        }

        // POST: JDADebugDeviceInfoesMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JDADebugDeviceInfo jDADebugDeviceInfo = db.JDADebugDeviceInfoes.Find(id);
            db.JDADebugDeviceInfoes.Remove(jDADebugDeviceInfo);
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

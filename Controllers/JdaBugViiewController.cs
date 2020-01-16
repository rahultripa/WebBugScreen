using screenshare3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace screenshare3.Controllers
{
    public class JdaBugViiewController : Controller
    {
        // GET: JdaBugViiew
        public ActionResult Index()
        {
            return View();
        }
    private screenshare3Context db = new screenshare3Context();

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
  }
}

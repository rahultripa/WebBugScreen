using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace screenshare3.Controllers
{
    public class BugViewController : Controller
    {
    // GET: BugView
    public ActionResult Index()
    {
      return View("Details", RouteConfig.screenImageInfo);
      //  return View();
    }
  }
}

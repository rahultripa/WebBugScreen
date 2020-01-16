using screenshare3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace screenshare3
{
    public class RouteConfig
    {
    public static ScreenImage screenImage = new ScreenImage();
    public static ScreenImageInfo screenImageInfo = new ScreenImageInfo();
    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
     
    }
    }
}

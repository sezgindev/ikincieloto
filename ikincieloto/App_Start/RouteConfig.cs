using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ikincieloto.Controllers;

namespace ikincieloto
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var namespaces=new[]{typeof(LoginController).Namespace};
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute("Login", "login", new { controller = "Login", action = "login" },namespaces);

            routes.MapRoute("Logout", "logout", new { controller = "Login", action = "logout" }, namespaces);
          



        }
    }
}

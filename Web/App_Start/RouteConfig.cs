using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Payment",
               url: "thanh-toan",
               defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Payment Sussess",
               url: "hoan-thanh",
               defaults: new { controller = "Cart", action = "Susscess", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "ProductCategory",
                url: "san-pham/{metatitle}-{id}",
                defaults: new { controller = "ProductCategory", action = "ProductCategory", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Product", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

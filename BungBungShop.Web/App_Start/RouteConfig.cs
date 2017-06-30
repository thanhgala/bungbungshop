using System.Web.Mvc;
using System.Web.Routing;

namespace BungBungShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
               name: "Contact",
                 url: "lien-he",
                 defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "BungBungShop.Web.Controllers" }
             );

            routes.MapRoute(
               name: "Search",
                 url: "tim-kiem",
                 defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                 namespaces: new string[] { "BungBungShop.Web.Controllers" }
             );
            routes.MapRoute(
                name: "Login",
                  url: "dang-nhap",
                  defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                  namespaces: new string[] { "BungBungShop.Web.Controllers" }
              );
            routes.MapRoute(
                name: "Register",
                  url: "dang-ky",
                  defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                  namespaces: new string[] { "BungBungShop.Web.Controllers" }
              );
            routes.MapRoute(
               name: "Cart",
                 url: "gio-hang",
                 defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "BungBungShop.Web.Controllers" }
             );
            routes.MapRoute(
               name: "Checkout",
                 url: "thanh-toan",
                 defaults: new { controller = "ShoppingCart", action = "CheckOut", id = UrlParameter.Optional },
                 namespaces: new string[] { "BungBungShop.Web.Controllers" }
             );
            routes.MapRoute(
               name: "Page",
               url: "trang/{alias}",
               defaults: new { controller = "Page", action = "Index", alias = UrlParameter.Optional },
               namespaces: new string[] { "BungBungShop.Web.Controllers" }
           );
            routes.MapRoute(
             name: "ProductCategory",
             url: "{category}.pc-{id}",
             defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
               namespaces: new string[] { "BungBungShop.Web.Controllers" }
         );

            routes.MapRoute(
             name: "Product",
             url: "{product}.p-{id}",
             defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
               namespaces: new string[] { "BungBungShop.Web.Controllers" }
         );

            routes.MapRoute(
             name: "TagList",
             url: "tag/{tagid}",
             defaults: new { controller = "Product", action = "ListByTag", tagid = UrlParameter.Optional },
               namespaces: new string[] { "BungBungShop.Web.Controllers" }
         );
            //tạo trang 404
            //routes.MapRoute(
            //    name: "App",
            //    url: "{*url}",
            //    defaults: new
            //    {
            //        controller = "Home",
            //        action = "Index"
            //    }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                  namespaces: new string[] { "BungBungShop.Web.Controllers" }
            );
        }
    }
}
using System.Web.Mvc;
using System.Web.Routing;

namespace WPFPresentation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: null,
                 url: "Page {page}",
                 defaults: new { Controller = "Product", action = "Index", category = (string)null, type = (string)null, brand = (string)null }
             );

            routes.MapRoute(
                 name: null,
                 url: "c-{category}/t-{type}/b-{brand}/Page {page}",
                 defaults: new { Controller = "Product", action = "Index" }
             );

            routes.MapRoute(
                 name: null,
                 url: "c-{category}/t-{type}/b-{brand}",
                 defaults: new { Controller = "Product", action = "Index", page = 1 }
             );

            routes.MapRoute(
                name: null,
                url: "c-{category}/t-{type}/Page {page}",
                defaults: new { Controller = "Product", action = "Index", brand = (string)null }
                );

            routes.MapRoute(
                name: null,
                url: "c-{category}/t-{type}",
                defaults: new { Controller = "Product", action = "Index", brand = (string)null, page = 1 }
                );

            routes.MapRoute(
                 name: null,
                 url: "c-{category}/b-{brand}/Page {page}",
                 defaults: new { Controller = "Product", action = "Index", type = (string)null }
             );

            routes.MapRoute(
                 name: null,
                 url: "c-{category}/b-{brand}",
                 defaults: new { Controller = "Product", action = "Index", type = (string)null, page = 1 }
             );

            routes.MapRoute(
                 name: null,
                 url: "t-{type}/b-{brand}/Page {page}",
                 defaults: new { Controller = "Product", action = "Index", category = (string)null }
             );

            routes.MapRoute(
                 name: null,
                 url: "t-{type}/b-{brand}",
                 defaults: new { Controller = "Product", action = "Index", category = (string)null, page = 1 }
             );

            routes.MapRoute(
                 name: null,
                 url: "c-{category}/Page {page}",
                 defaults: new { Controller = "Product", action = "Index", type = (string)null, brand = (string)null }
             );

            routes.MapRoute(
                 name: null,
                 url: "c-{category}",
                 defaults: new { Controller = "Product", action = "Index", type = (string)null, brand = (string)null, page = 1 }
             );

            routes.MapRoute(
                 name: null,
                 url: "t-{type}/Page {page}",
                 defaults: new { Controller = "Product", action = "Index", category = (string)null, brand = (string)null }
             );

            routes.MapRoute(
                 name: null,
                 url: "t-{type}",
                 defaults: new { Controller = "Product", action = "Index", category = (string)null, brand = (string)null, page = 1 }
             );

            routes.MapRoute(
                 name: null,
                 url: "b-{brand}/Page {page}",
                 defaults: new { Controller = "Product", action = "Index", category = (string)null, type = (string)null }
             );

            routes.MapRoute(
                 name: null,
                 url: "b-{brand}",
                 defaults: new { Controller = "Product", action = "Index", category = (string)null, type = (string)null, page = 1 }
             );

            routes.MapRoute(
                name: null,
                url: "search-{searchString}/Page {page}",
                defaults: new { Controller = "Product", action = "Search" }
            );

            routes.MapRoute(
                name: null,
                url: "search-{searchString}",
                defaults: new { Controller = "Product", action = "Search", page = 1 }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Events",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Events", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

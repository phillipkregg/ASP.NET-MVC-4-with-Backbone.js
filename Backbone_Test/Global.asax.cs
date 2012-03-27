using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Backbone_Test
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var url = "api/Todos";

            routes.MapRoute(
                "Todo_GET",
                url,
                new { controller = "Todo", action = "Get", area = "" },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            routes.MapRoute(
                "Todo_GET_ONE",
                url + "/{id}",
                new { controller = "Todo", action = "GetOne" },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );

            routes.MapRoute(
                "Todo_POST",
                url,
                new { controller = "Todo", action = "Post" },
                new { httpMethod = new HttpMethodConstraint("POST") }

            );

            routes.MapRoute(
                "Todos_PUT",
                url + "/{id}",
                new { controller = "Todo", action = "PUT" },
                new { httpMethod = new HttpMethodConstraint("PUT") }
            );


            routes.MapRoute(
                "Todo_DELETE",
                url + "/{id}",
                new { controller = "Todo", action = "Delete" },
                new { httpMethod = new HttpMethodConstraint("DELETE") }
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Todos", action = "Index", id = UrlParameter.Optional }// parameter defaults

            );






        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.RegisterTemplateBundles();
        }
    }
}
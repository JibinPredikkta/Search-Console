using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SearchConsoleAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "WithAction",
                routeTemplate: "api/{controller}/{action}"
            );

            config.Routes.MapHttpRoute(
                name: "WithDateRange",
                routeTemplate: "api/{controller}/{action}/{startDate}/{endDate}"
            );

            config.Routes.MapHttpRoute(
              name: "Login",
              routeTemplate: "api/{controller}/{action}/{userName}/{password}"
          );
            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        }
    }
}

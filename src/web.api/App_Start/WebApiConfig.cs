using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace web.api
{
    public static class WebApiConfig
    {

        /// <summary>
        /// For registering in global asax
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        /// <summary>
        /// For registering in start up class.Its your preference.
        /// </summary>
        /// <returns></returns>
        public static HttpConfiguration Register()
        {
            // Web API configuration and services
            HttpConfiguration config = new HttpConfiguration();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            return config;
        }
    }
}

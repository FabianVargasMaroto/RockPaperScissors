using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RockPaperScissors
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();



            config.Routes.MapHttpRoute(
                name: "result",
                routeTemplate: "api/championship/result",
                defaults: new { controller = "Championship", action = "PostResultWinner" }
            );

            config.Routes.MapHttpRoute(
                name: "top",
                routeTemplate: "api/championship/top",
                defaults: new { controller = "Championship", action = "GetTopWinners" }
            );


            config.Routes.MapHttpRoute(
                name: "new",
                routeTemplate: "api/championship/new",
                defaults: new { controller = "Championship", action = "PostNewWinner" }
            );


            config.Routes.MapHttpRoute(
                name: "delete",
                routeTemplate: "api/championship/delete",
                defaults: new { controller = "Championship", action = "DeleteWinners" }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );





        }
    }
}

#region License
//-----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
#endregion

namespace Sigma.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignore Routes...
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("api/{*pathInfo}");  // Important: for ServiceStack API
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" }); //Prevent exceptions for favicon

            routes.MapRoute(
                name: "Login", // Route name
                url: "Login", // URL with parameters
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }  // Parameter defaults
            );

            routes.MapRoute(
                name: "Logout", // Route name
                url: "Logout", // URL with parameters
                defaults: new { controller = "Account", action = "Logout", id = UrlParameter.Optional }  // Parameter defaults
            );

            routes.MapRoute(
                name: "Default", // Route name
                url: "{culture}/{controller}/{action}/{id}", // URL with parameters
                defaults: new
                {
                    culture = "en-US",
                    controller = "Menu",
                    action = "Out",
                    id = UrlParameter.Optional,
                },
                namespaces: new[] { "Sigma.Web.Controllers" }
            );
        }


    }
}
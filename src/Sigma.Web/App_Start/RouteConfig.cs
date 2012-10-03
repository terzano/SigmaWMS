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
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("api/{*pathInfo}");  // Important: for ServiceStack API
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" }); //Prevent exceptions for favicon

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
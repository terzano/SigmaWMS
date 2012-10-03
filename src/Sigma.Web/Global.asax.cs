#region License
//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using ModelMetadataExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
#endregion

namespace Sigma.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ModelMetadataProviders.Current = new ConventionalModelMetadataProvider(
            //    requireConventionAttribute: false,
            //    defaultResourceType: typeof(MyResources.Resource)
            //);
        }
    }
}
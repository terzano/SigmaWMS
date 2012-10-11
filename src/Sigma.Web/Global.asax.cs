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
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
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

            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("MobileHtml3")
            {
                ContextCondition = (context => GetDeviceType(context.GetOverriddenUserAgent()) == "html3")
            });

            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("MobileHtml4")
            {
                ContextCondition = (context => GetDeviceType(context.GetOverriddenUserAgent()) == "html4")
            });

            //ModelMetadataProviders.Current = new ConventionalModelMetadataProvider(
            //    requireConventionAttribute: false,
            //    defaultResourceType: typeof(MyResources.Resource)
            //);
        }

        public string GetDeviceType(string ua)
        {
            string ret = "";

            // Check if user agent is a TV Based Gaming Console
            if (Regex.IsMatch(ua, "iPhone|Android", RegexOptions.IgnoreCase))
            {
                ret = "html3";
            }
            else
            {
                ret = "mobile";
            }
            return ret;
        }

    }
}
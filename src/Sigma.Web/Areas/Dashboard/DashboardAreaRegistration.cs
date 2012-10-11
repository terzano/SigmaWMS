#region License
//-----------------------------------------------------------------------
// <copyright file="DashboardAreaRegistration.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System.Web.Mvc;
#endregion

namespace Sigma.Web.Areas.Dashboard
{
    public class DashboardAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Dashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "Dashboard_default",
               url: "Dashboard/{culture}/{controller}/{action}/{id}",
               defaults: new
               {
                   culture = "en-US",
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional
               },
               namespaces: new[] { "Sigma.Web.Areas.Dashboard.Controllers" }
            );

        }
    }
}

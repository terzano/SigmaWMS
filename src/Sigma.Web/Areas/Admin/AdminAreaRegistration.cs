#region License
//-----------------------------------------------------------------------
// <copyright file="AdminAreaRegistration.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System.Web.Mvc;
#endregion

namespace Sigma.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "Admin_default",
               url: "Admin/{culture}/{controller}/{action}/{id}",
               defaults: new
               {
                   culture = "en-US",
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional
               },
               namespaces: new[] { "Sigma.Web.Areas.Admin.Controllers" }
            );

        }
    }
}

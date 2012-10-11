#region License
//-----------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using System.Web;
using System.Web.Optimization;
#endregion

namespace Sigma.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Public/js/lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Public/js/ui/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Public/js/lib/jquery.unobtrusive*",
                        "~/Public/js/lib/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Public/js/polyfills/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Public/css/site.css"));

        }
    }
}
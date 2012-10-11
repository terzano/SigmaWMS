#region License
//-----------------------------------------------------------------------
// <copyright file="LocalizationExtensions.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
#endregion

namespace Sigma.Web.Extensions
{
    public static class LocalizationExtensions
    {
        public static string Localize(this HtmlHelper htmlhelper, string expression, params object[] args)
        {
            string virtualPath = GetVirtualPath(htmlhelper);

            return GetResourceString(htmlhelper.ViewContext.HttpContext, expression, virtualPath, args);
        }

        public static string Localize(this Controller controller, string expression, params object[] args)
        {
            return GetResourceString(controller.HttpContext, expression, "~/", args);
        }

        private static string GetResourceString(HttpContextBase httpContext, string expression, string virtualPath, object[] args)
        {
            ExpressionBuilderContext context = new ExpressionBuilderContext(virtualPath);
            ResourceExpressionBuilder builder = new ResourceExpressionBuilder();
            ResourceExpressionFields fields = (ResourceExpressionFields)builder.ParseExpression(expression, typeof(string), context);

            if (!string.IsNullOrEmpty(fields.ClassKey))
                return string.Format((string)httpContext.GetGlobalResourceObject(
                    fields.ClassKey,
                    fields.ResourceKey,
                    CultureInfo.CurrentUICulture),
                    args);

            return string.Format((string)httpContext.GetLocalResourceObject(
                virtualPath,
                fields.ResourceKey,
                CultureInfo.CurrentUICulture),
                args);
        }

        private static string GetVirtualPath(HtmlHelper htmlhelper)
        {
            string virtualPath = null;
            Controller controller = htmlhelper.ViewContext.Controller as Controller;

            if (controller != null)
            {
                RazorView razorView = htmlhelper.ViewContext.View as RazorView;

                if (razorView != null)
                {
                    virtualPath = razorView.ViewPath;
                }
            }

            return virtualPath;
        }
    }
}

#region License
//-----------------------------------------------------------------------
// <copyright file="GrowlExtensions.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
#endregion

namespace Sigma.Web.Extensions
{
    public static class GrowlExtensions
    {
        public static void GrowlNotification(this Controller controller,
            string message, GrowlType growlType, string title = null,
            bool sticky = false, bool closeable = true, int duration = 5000)
        {
            if (title != null) controller.TempData["GrowlTitle"] = title;
            controller.TempData["GrowlType"] = growlType.ToString().ToLower();
            controller.TempData["GrowlMessage"] = message;
            controller.TempData["GrowlCloseable"] = closeable;
            controller.TempData["GrowlSticky"] = sticky;
            controller.TempData["GrowlDuration"] = duration;
        }

        public static IHtmlString Growl(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            string message = "";
            string title = "";
            string growlType = "";
            bool sticky = false;
            bool closeable = true;
            int duration = 5000;

            if (helper.ViewContext.TempData["GrowlTitle"] != null)
            {
                title = helper.ViewContext.TempData["GrowlTitle"].ToString();
            }
            if (helper.ViewContext.TempData["GrowlMessage"] != null)
            {
                message = helper.ViewContext.TempData["GrowlMessage"].ToString();
            }
            if (helper.ViewContext.TempData["GrowlType"] != null)
            {
                growlType = helper.ViewContext.TempData["GrowlType"].ToString();
            }
            if (helper.ViewContext.TempData["GrowlSticky"] != null)
            {
                sticky = (bool)helper.ViewContext.TempData["GrowlSticky"];
            }
            if (helper.ViewContext.TempData["GrowlCloseable"] != null)
            {
                closeable = (bool)helper.ViewContext.TempData["GrowlCloseable"];
            }
            if (helper.ViewContext.TempData["GrowlDuration"] != null)
            {
                duration = (int)helper.ViewContext.TempData["GrowlDuration"];
            }

            if (!String.IsNullOrEmpty(message))
            {
                sb.AppendLine("<script>");
                sb.AppendLine("$(document).ready(function () {");
                sb.AppendLine("toastr.options = {");
                sb.AppendFormat(" tapToDismiss: {0},", (closeable) ? "true" : "false");
                sb.AppendFormat(" timeOut: {0}", (sticky) ? 0 : duration);
                sb.AppendLine("};");
                sb.AppendFormat("toastr.{0}(\"{1}\",\"{2}\");", growlType, message, title);
                sb.AppendLine("});");
                sb.AppendLine("</script>");
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        public enum GrowlType
        {
            Success,
            Info,
            Warning,
            Error
        }
    }
}

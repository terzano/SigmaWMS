#region License
//-----------------------------------------------------------------------
// <copyright file="HtmlExtensions.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;
#endregion

namespace Sigma.Web.Extensions
{
    public static class HtmlExtensions
    {
        const string pubDir = "/Public";
        const string cssDir = "css";
        const string imageDir = "img";
        const string scriptDir = "js";

        public static bool IsDebug(this HtmlHelper htmlHelper)
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        public static MvcHtmlString Script(this HtmlHelper helper, string fileName)
        {
            if (!fileName.EndsWith(".js"))
                fileName += ".js";
            var jsPath = string.Format("<script type='text/javascript' src='{0}/{1}/{2}' ></script>\n", VirtualPathUtility.ToAbsolute(pubDir), scriptDir, helper.AttributeEncode(fileName));
            return MvcHtmlString.Create(jsPath);
        }
        public static MvcHtmlString CSS(this HtmlHelper helper, string fileName)
        {
            return CSS(helper, fileName, "screen");
        }
        public static MvcHtmlString CSS(this HtmlHelper helper, string fileName, string media)
        {
            if (!fileName.EndsWith(".css"))
                fileName += ".css";
            var jsPath = string.Format("<link rel='stylesheet' type='text/css' href='{0}/{1}/{2}'  media='" + media + "'/>\n", VirtualPathUtility.ToAbsolute(pubDir), cssDir, helper.AttributeEncode(fileName));
            return MvcHtmlString.Create(jsPath);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string imgName, string alternateText)
        {
            return Image(helper, null, imgName, alternateText, null, null);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string id, string imgName, string alternateText, string styleClass)
        {
            return Image(helper, id, imgName, alternateText, styleClass, null);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string id, string imgName, string alternateText, string styleClass, object htmlAttributes)
        {
            // Create tag builder
            var builder = new TagBuilder("img");

            // Create valid id
            builder.GenerateId(id);

            // Add attributes
            builder.MergeAttribute("src", string.Format("{0}/{1}/{2}", VirtualPathUtility.ToAbsolute(pubDir), imageDir, imgName));
            builder.MergeAttribute("alt", alternateText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            if (!String.IsNullOrWhiteSpace(styleClass))
            {
                builder.MergeAttribute("class", styleClass);
            }

            // Render tag
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString RadioButtonList(this HtmlHelper helper, string id, IEnumerable<SelectListItem> items)
        {
            return RadioButtonList(helper, id, items, null);
        }

        public static MvcHtmlString RadioButtonList(this HtmlHelper helper, string id, IEnumerable<SelectListItem> items, object htmlAttributes)
        {
            var ulBuilder = new TagBuilder("ul");
            ulBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            ulBuilder.AddCssClass("radio-listing");
            ulBuilder.GenerateId(id);

            foreach (var item in items)
            {
                var liBuilder = new TagBuilder("li");
                var val = item.Value ?? item.Text;
                var itemId = id + "_" + val;
                liBuilder.InnerHtml = string.Format("<input id=\"{0}\" type=\"radio\" name=\"{1}\" value=\"{2}\" {3}>{4}",
                    itemId, id, val, (item.Selected) ? "checked=\"checked\"" : "", item.Text);
                ulBuilder.InnerHtml += liBuilder.ToString();
            }

            return MvcHtmlString.Create(ulBuilder.ToString());
        }

        public static MvcHtmlString MyActionLink(
          this HtmlHelper htmlHelper,
          string linkText,
          string action,
          string controller,
          string area = "",
          string culture = "",
          object htmlAttributes = null)
        {
            var routeValues = new { area = area, culture = culture };

            return htmlHelper.ActionLink(linkText, action, controller, routeValues, htmlAttributes);
        }


    }
}

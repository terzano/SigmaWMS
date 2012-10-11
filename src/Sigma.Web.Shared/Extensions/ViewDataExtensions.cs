#region License
//-----------------------------------------------------------------------
// <copyright file="ViewDataExtensions.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System.Collections.Generic;
using System.Web.Mvc;
#endregion

namespace Sigma.Web.Extensions
{
    public static class ViewDataExtensions
    {
        public static IEnumerable<T> ViewData<T>(this HtmlHelper helper, string name)
        {
            if (helper.ViewData[name] != null)
            {
                return (IEnumerable<T>)helper.ViewData[name];
            }
            return new List<T>();
        }

        public static T ViewDataSingle<T>(this HtmlHelper helper, string name)
        {
            if (helper.ViewData[name] != null)
            {
                return (T)helper.ViewData[name];
            }
            return default(T);
        }
    }
}

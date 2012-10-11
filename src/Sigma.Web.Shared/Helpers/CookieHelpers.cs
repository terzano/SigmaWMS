#region License
//-----------------------------------------------------------------------
// <copyright file="CookieHelpers.cs" company="Pi2 LLC">
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
#endregion 

namespace Sigma.Web.Helpers
{
    public class CookieHelpers
    {
        public static string GetCookieValue(string cookieName)
        {
            string cookieVal = String.Empty;
            cookieVal = HttpContext.Current.Request.Cookies[cookieName].Value;
            return cookieVal;
        }

        public static string GetCookieValue(string cookieName, string subKeyName)
        {
            string cookieVal = String.Empty;
            cookieVal = HttpContext.Current.Request.Cookies[cookieName][subKeyName];
            return cookieVal;
        }

        public static void CreateCookie(string cookieName, string value, int? expirationDays)
        {
            HttpCookie Cookie = new HttpCookie(cookieName, value);
            if (expirationDays.HasValue)
                Cookie.Expires = DateTime.Now.AddDays(expirationDays.Value);
            HttpContext.Current.Response.Cookies.Add(Cookie);
        }

        public static void CreateCookie(string cookieName, Dictionary<string, string> dict, int? expirationDays)
        {
            HttpCookie Cookie = new HttpCookie(cookieName);
            if (expirationDays.HasValue)
                Cookie.Expires = DateTime.Now.AddDays(expirationDays.Value);

            foreach (var dictItem in dict)
            {
                Cookie.Values.Add(dictItem.Key, dictItem.Value);
            }

            HttpContext.Current.Response.Cookies.Add(Cookie);
        }

        public static void DeleteCookie(string cookieName)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (Cookie != null)
            {
                Cookie.Expires = DateTime.Now.AddDays(-2);
                HttpContext.Current.Response.Cookies.Add(Cookie);
            }
        }

        public static bool CookieExists(string cookieName)
        {
            bool exists = false;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
                exists = true;
            return exists;
        }

        public static Dictionary<string, string> GetAllCookies()
        {
            Dictionary<string, string> cookies = new Dictionary<string, string>();
            foreach (string key in HttpContext.Current.Request.Cookies.AllKeys)
            {
                cookies.Add(key, HttpContext.Current.Request.Cookies[key].Value);
            }
            return cookies;
        }

        public static void DeleteAllCookies()
        {
            var x = HttpContext.Current.Request.Cookies;
            foreach (HttpCookie cook in x)
            {
                DeleteCookie(cook.Name);
            }
        }

    }
}

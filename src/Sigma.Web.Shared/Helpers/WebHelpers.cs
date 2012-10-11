#region License
//-----------------------------------------------------------------------
// <copyright file="WebHelpers.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
#endregion

namespace Sigma.Web.Helpers
{
    public static class WebHelpers
    {
        public static string GetIP
        {
            get { return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; }
        }

        public static string MyAppPath
        {
            get { return HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"]; }
        }

        public static string GetUserAgent
        {
            get { return HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]; }
        }

    }
}

﻿#region License
//-----------------------------------------------------------------------
// <copyright file="ReportController.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
#endregion 

namespace Sigma.Web.Controllers
{
    public class ReportController : Controller
    {
        

        public ActionResult In()
        {
            return View();
        }

        public ActionResult Out()
        {
            return View();
        }

    }
}

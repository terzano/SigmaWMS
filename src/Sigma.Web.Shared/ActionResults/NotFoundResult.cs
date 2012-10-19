#region License
//-----------------------------------------------------------------------
// <copyright file="NotFoundResult.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System.Web.Mvc;
#endregion

namespace Sigma.Web.ActionResults
{
    public class NotFoundResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = 404;

            new ViewResult { ViewName = "NotFound" }
                .ExecuteResult(context);
        }

    }
}

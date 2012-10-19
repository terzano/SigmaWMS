#region License
//-----------------------------------------------------------------------
// <copyright file="AjaxOnlyAttribute.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using Sigma.Web.ActionResults;
using System.Web.Mvc;
#endregion

namespace Sigma.Web.Filters
{
    public class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new NotFoundResult();
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}

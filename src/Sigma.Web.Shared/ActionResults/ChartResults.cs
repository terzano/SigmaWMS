#region License
//-----------------------------------------------------------------------
// <copyright file="ChartResult.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using System.Web.Helpers;
using System.Web.Mvc;
#endregion 

namespace Sigma.Web.ActionResults
{
    /// <summary>
    /// Helper result to render an image based chart to view. 
    /// This is used for non javascript capable browsers.
    /// </summary>
    public class ChartResult : ActionResult
    {
        private readonly Chart _chart;
        private readonly string _imageType;

        public ChartResult(Chart chart) : this(chart, "jpeg") { }

        public ChartResult(Chart chart, string imageType)
        {
            this._chart = chart;
            this._imageType = imageType;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var result = new FileContentResult(
                  _chart.GetBytes(_imageType),
                  "image/" + _imageType);

            result.ExecuteResult(context);
        }
    }
}

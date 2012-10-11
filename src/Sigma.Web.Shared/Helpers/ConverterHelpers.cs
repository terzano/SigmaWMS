#region License
//-----------------------------------------------------------------------
// <copyright file="ConverterHelpers.cs" company="Pi2 LLC">
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
#endregion

namespace Sigma.Web.Helpers
{
    public class ConverterHelpers
    {
        public static string ConvertToJsObject(Dictionary<string, object> options)
        {
            var config = new StringBuilder();

            config.Append("{");
            foreach (var item in options)
            {
                config.AppendFormat(" {0}: {1}{2} ", item.Key, item.Value, options.Last().Equals(item) ? "" : ",");
            }
            config.Append("}");
            return config.ToString();
        }
    }
}

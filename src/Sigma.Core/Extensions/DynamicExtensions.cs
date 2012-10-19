#region License
//-----------------------------------------------------------------------
// <copyright file="DynamicExtensions.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using System.Collections.Generic;
using System.Dynamic;
#endregion

namespace Sigma.Core.Extensions
{
    public static class DynamicExtensions
    {
        public static ExpandoObject CreateExpando(this object item)
        {
            var dictionary = new ExpandoObject() as IDictionary<string, object>;
            foreach (var propertyInfo in item.GetType().GetProperties())
            {
                dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(item, null));
            }
            return (ExpandoObject)dictionary;
        }
    }
}

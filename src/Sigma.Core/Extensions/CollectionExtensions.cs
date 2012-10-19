#region License
//-----------------------------------------------------------------------
// <copyright file="CollectionExtensions.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System.Collections.Generic;
using System.ComponentModel;
#endregion

namespace Sigma.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static IDictionary<string, object> AddProperty(this object obj, string name, object value)
        {
            var dictionary = obj.ToDictionary();
            dictionary.Add(name, value);
            return dictionary;
        }

        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor property in properties)
            {
                result.Add(property.Name, property.GetValue(obj));
            }
            return result;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict,
           TKey key, TValue defaultIfNotFound = default(TValue))
        {
            TValue value;

            // value will be the result or the default for TValue
            if (!dict.TryGetValue(key, out value))
            {
                value = defaultIfNotFound;
            }

            return value;
        }
    }
}

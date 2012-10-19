#region License
//-----------------------------------------------------------------------
// <copyright file="TypeHelpers.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using System.ComponentModel;
#endregion

namespace Sigma.Core.Helpers
{
    public class TypeHelpers
    {
        public static bool TryParse<T>(string s, out T value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                value = (T)converter.ConvertFromString(s);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }
    }
}

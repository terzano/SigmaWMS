#region License
//-----------------------------------------------------------------------
// <copyright file="ConverterExtensions.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using Sigma.Core.Helpers;
#endregion

namespace Sigma.Core.Extensions
{
    public static class ConverterExtensions
    {
        public static T GetValueOrDefault<T>(this string value, T defaultValue = default(T)) where T : struct
        {
            T result;
            if (TypeHelpers.TryParse<T>(value, out result))
            {
                return result;
            }

            return defaultValue;
        }

    }
}

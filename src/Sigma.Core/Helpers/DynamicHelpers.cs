#region License
//-----------------------------------------------------------------------
// <copyright file="DynamicHelpers.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
#endregion

namespace Sigma.Core.Helpers
{
    public class DynamicHelpers
    {
        public static bool ExpandoContainsKey(dynamic expando, string keyName)
        {
            if (((IDictionary<String, Object>)expando).ContainsKey(keyName))
            {
                return true;
            }
            return false;
        }

    }
}

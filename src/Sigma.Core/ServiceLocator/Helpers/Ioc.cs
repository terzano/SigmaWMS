#region License
//-----------------------------------------------------------------------
// <copyright file="IoC.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using System;
using System.Collections.Generic;
using Sigma.Core.BootStrapper;
#endregion

namespace Sigma.Core.ServiceLocator
{
    public static class IoC
    {
        public static IEnumerable<TService> GetAllInstances<TService>()
        {
            return CommonBootStrapper.Locator.GetAllInstances<TService>();
        }

        public static TService GetInstance<TService>()
        {
            return CommonBootStrapper.Locator.GetInstance<TService>();
        }

        public static TService GetInstance<TService>(string key)
        {
            return CommonBootStrapper.Locator.GetInstance<TService>(key);
        }

        public static object GetInstance(Type serviceType)
        {
            return CommonBootStrapper.Locator.GetInstance(serviceType);
        }

        public static object GetInstance(Type serviceType, string key)
        {
            return CommonBootStrapper.Locator.GetInstance(serviceType, key);
        }
    }
}

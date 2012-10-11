#region License
//-----------------------------------------------------------------------
// <copyright file="Ioc.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
#endregion

namespace Sigma.Web.Helpers
{
    public class Ioc
    {
        private static IDependencyResolver _resolver = AutofacDependencyResolver.Current;

        public static T GetService<T>()
        {
            return _resolver.GetService<T>();
        }

        public static object GetService(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public static IEnumerable<T> GetServices<T>()
        {
            return _resolver.GetServices<T>();
        }

        public static IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }
    }
}

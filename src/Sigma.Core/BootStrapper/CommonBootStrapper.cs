#region License
//-----------------------------------------------------------------------
// <copyright file="CommonBootStrapper.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using Sigma.Core.ServiceLocator;
using System.Collections.Generic;
using System.Reflection;
#endregion

namespace Sigma.Core.BootStrapper
{
    public abstract class CommonBootStrapper
    {
        public static IServiceLocator Locator;
        protected Assembly _callingAssembly;

        protected CommonBootStrapper(Assembly callingAssembly, IEnumerable<string> bootTaskAssemblies)
        {
            _callingAssembly = callingAssembly;
            Locator = CreateServiceLocator(bootTaskAssemblies);
            Run();
        }

        /// <summary>
        /// Create Service Locator object, including create and configure Nhibernate object
        /// </summary>
        /// <returns>Service Locator instance</returns>
        protected abstract IServiceLocator CreateServiceLocator(IEnumerable<string> bootTaskAssemblies);

        /// <summary>
        /// Run all task in background
        /// </summary>
        protected abstract void Run();
    }
}

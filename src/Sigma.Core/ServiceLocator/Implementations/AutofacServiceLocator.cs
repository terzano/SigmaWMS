#region License
//-----------------------------------------------------------------------
// <copyright file="AutofacServiceLocator.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
#endregion

namespace Sigma.Core.ServiceLocator
{
    public class AutofacServiceLocator : ServiceLocatorBase
    {
        private IContainer _container;

        public AutofacServiceLocator(IContainer container)
        {
            this._container = container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (key == null)
            {
                return _container.Resolve(serviceType);
            }
            else
            {
                object result = null;
                _container.TryResolveKeyed(key, serviceType, out result);

                return result;
            }
        }

        protected override IEnumerable<TService> DoGetAllInstances<TService>()
        {
            return _container.Resolve<IEnumerable<TService>>();
        }
    }

}

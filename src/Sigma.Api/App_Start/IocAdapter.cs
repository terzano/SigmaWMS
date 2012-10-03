#region License
//-----------------------------------------------------------------------
// <copyright file="IocAdapter.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using ServiceStack.Configuration;
using Autofac;
#endregion

namespace Sigma.Api
{
    public class AutofacIocAdapter : IContainerAdapter
    {
        private readonly IContainer _container;

        public AutofacIocAdapter(IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T TryResolve<T>()
        {
            T result;

            if (_container.TryResolve<T>(out result))
            {
                return result;
            }

            return default(T);
        }
    }
}
#region License
//-----------------------------------------------------------------------
// <copyright file="ServiceLocatorProvider.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Sigma.Core.ServiceLocator
{
    /// <summary>
    /// This delegate type is used to provide a method that will
    /// return the current container. Used with the <see cref="ServiceLocator"/>
    /// static accessor class.
    /// </summary>
    /// <returns>An <see cref="IServiceLocator"/>.</returns>
    public delegate IServiceLocator ServiceLocatorProvider();
}

#region License
//-----------------------------------------------------------------------
// <copyright file="IPlugin.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
#endregion

namespace Sigma.Core.Extensibility
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        string Version { get; }
        string Author { get; }
        string Company { get; }
        DateTime CreatedDate { get; }
        DateTime UpdatedDate { get; }
    }
}

#region License
//-----------------------------------------------------------------------
// <copyright file="INamedEntity.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Sigma.Domain.Identity
{
    public interface INamedEntity : IEntity
    {
        string Name { get; set; }
    }
}

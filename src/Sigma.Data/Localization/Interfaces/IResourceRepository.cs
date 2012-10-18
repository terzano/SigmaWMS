#region License
//-----------------------------------------------------------------------
// <copyright file="IResourceRepository.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Sigma.Data.Localization
{
    public interface IResourceRepository
    {
        string GetResourceByCultureAndKey(string cultureCode, string resourceKey);
    }
}

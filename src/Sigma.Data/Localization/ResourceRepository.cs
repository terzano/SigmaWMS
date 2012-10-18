#region License
//-----------------------------------------------------------------------
// <copyright file="ResourceRepository.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using Sigma.Core;
using Simple.Data;
using System;
#endregion 

namespace Sigma.Data.Localization
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly ISettings _settings;

        public ResourceRepository(ISettings settings)
        {
            this._settings = settings;
        }

        public string GetResourceByCultureAndKey(string cultureCode, string resourceKey)
        {
            throw new NotImplementedException();
        }
    }
}

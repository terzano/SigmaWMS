#region License
//-----------------------------------------------------------------------
// <copyright file="ISettings.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Sigma.Core
{
    public interface ISettings
    {
        string GetConnectionString(string connName);
        string GetPropertyValue(string propertyName);
    }
}

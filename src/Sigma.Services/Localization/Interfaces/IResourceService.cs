#region License
//-----------------------------------------------------------------------
// <copyright file="IResourceService.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System.Collections.Specialized;
using System.Globalization;
#endregion

namespace Sigma.Services.Localization
{
    public interface IResourceService
    {
        string ResourceType { get; set; }
        ListDictionary GetResourcesByCulture(CultureInfo culture);
        string GetResourceByCultureAndKey(CultureInfo culture, string resourceKey);
    }
}

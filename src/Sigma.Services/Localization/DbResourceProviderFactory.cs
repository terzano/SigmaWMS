#region License
//-----------------------------------------------------------------------
// <copyright file="DBResourceProviderFactory.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System.Web.Compilation;
#endregion

namespace Sigma.Services.Localization
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/aa905797.aspx
    /// </summary>
    public class DbResourceProviderFactory : ResourceProviderFactory
    {

        public override IResourceProvider CreateGlobalResourceProvider(string classKey)
        {
            return new DbResourceProvider(classKey);
        }

        public override IResourceProvider CreateLocalResourceProvider(string virtualPath)
        {
            // We should always get a path from the runtime
            string classKey = virtualPath;

            if (!string.IsNullOrEmpty(virtualPath))
            {
                classKey = virtualPath.Remove(0, virtualPath.IndexOf('/') + 1);
            }

            return new DbResourceProvider(classKey);
        }
    }
}

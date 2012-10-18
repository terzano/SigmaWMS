#region License
//-----------------------------------------------------------------------
// <copyright file="DbResourceProvider.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using Sigma.Core.ServiceLocator;
using Sigma.Core.Types;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Resources;
using System.Web.Compilation;
#endregion 

namespace Sigma.Services.Localization
{
    /// <summary>
    /// Resource provider accessing resources from the database.
    /// This type is thread safe.
    /// </summary>
    public class DbResourceProvider : DisposableBaseType, IResourceProvider
    {
        public string ClassKey { get; private set; }
        public IResourceService ResourceService { get; private set; }

        // Resource cache
        private Dictionary<string, Dictionary<string, string>> _resourceCache = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// Constructs this instance of the provider 
        /// supplying a resource type for the instance. 
        /// </summary>
        /// <param name="resourceType">The resource type.</param>
        public DbResourceProvider(string classKey)
            : this(IoC.GetInstance<IResourceService>())
        {
            ClassKey = classKey;
            ResourceService.ResourceType = ClassKey;
        }

        public DbResourceProvider(IResourceService resourceService)
        {
            ResourceService = resourceService;
        }

        #region IResourceProvider Members

        /// <summary>
        /// Retrieves a resource entry based on the specified culture and 
        /// resource key. The resource type is based on this instance of the
        /// DBResourceProvider as passed to the constructor.
        /// To optimize performance, this function caches values in a dictionary
        /// per culture.
        /// </summary>
        /// <param name="resourceKey">The resource key to find.</param>
        /// <param name="culture">The culture to search with.</param>
        /// <returns>If found, the resource string is returned. 
        /// Otherwise an empty string is returned.</returns>
        public object GetObject(string resourceKey, CultureInfo culture)
        {
            if (Disposed)
            {
                throw new ObjectDisposedException("DBResourceProvider object is already disposed.");
            }

            if (string.IsNullOrEmpty(resourceKey))
            {
                throw new ArgumentNullException("resourceKey");
            }

            if (culture == null || culture.Name == string.Empty)
            {
                culture = CultureInfo.CurrentUICulture;
            }

            string resourceValue = null;
            Dictionary<string, string> resCacheByCulture = null;

            // Check the cache first
            // find the dictionary for this culture
            // check for the inner dictionary entry for this key
            if (_resourceCache.ContainsKey(culture.Name))
            {
                resCacheByCulture = _resourceCache[culture.Name];
                if (resCacheByCulture.ContainsKey(resourceKey))
                {
                    resourceValue = resCacheByCulture[resourceKey];
                }
            }

            // if not in the cache, go to the database
            if (resourceValue == null)
            {
                resourceValue = ResourceService.GetResourceByCultureAndKey(culture, resourceKey);

                // add this result to the cache
                // find the dictionary for this culture
                // add this key/value pair to the inner dictionary
                lock (this)
                {
                    if (resCacheByCulture == null)
                    {
                        resCacheByCulture = new Dictionary<string, string>();
                        _resourceCache.Add(culture.Name, resCacheByCulture);
                    }
                    resCacheByCulture.Add(resourceKey, resourceValue);
                }
            }
            return resourceValue;
        }

        /// <summary>
        /// Returns a resource reader.
        /// </summary>
        public IResourceReader ResourceReader
        {
            get
            {
                if (Disposed)
                {
                    throw new ObjectDisposedException("DBResourceProvider object is already disposed.");
                }

                // This is required for implicit resources 
                // this is also used for the expression editor sheet 
                ListDictionary resourceDictionary = ResourceService.GetResourcesByCulture(CultureInfo.InvariantCulture);

                return new DbResourceReader(resourceDictionary);
            }

        }

        #endregion

        protected override void Cleanup()
        {
            try
            {
                if (ResourceService != null)
                    GC.SuppressFinalize(ResourceService);
                this._resourceCache.Clear();
            }
            finally
            {
                base.Cleanup();
            }
        }
    }
}

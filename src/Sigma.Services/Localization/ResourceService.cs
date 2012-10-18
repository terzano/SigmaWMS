using Sigma.Data.Localization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Services.Localization
{
    public class ResourceService : IResourceService
    {
        public string ResourceType { get; set; }
        private readonly IResourceRepository _resourceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ResourceService"/> class.
        /// </summary>
        public ResourceService(IResourceRepository resourceRepository)
        {
            this._resourceRepository = resourceRepository;
        }

        public ListDictionary GetResourcesByCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public string GetResourceByCultureAndKey(CultureInfo culture, string resourceKey)
        {
            return _resourceRepository.GetResourceByCultureAndKey(culture.Name, resourceKey);
        }
    }
}

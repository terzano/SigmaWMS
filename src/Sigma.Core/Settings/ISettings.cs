using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigma.Core
{
    public interface ISettings
    {
        string GetConnectionString(string connName);
        string GetPropertyValue(string propertyName);
    }
}

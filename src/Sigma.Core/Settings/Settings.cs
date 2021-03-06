﻿#region License
//-----------------------------------------------------------------------
// <copyright file="Settings.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System.Configuration;
#endregion

namespace Sigma.Core
{ 
    public class Settings : ISettings
    {
        /// <summary>
        /// Gets the connection string from config file.
        /// </summary>
        /// <param name="connName">Name of the conn.</param>
        /// <returns></returns>
        public string GetConnectionString(string connName)
        {
            if (ConfigurationManager.ConnectionStrings[connName] != null)
            {
                return ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Gets the property value from config file.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public string GetPropertyValue(string propertyName)
        {
            if (ConfigurationManager.AppSettings[propertyName] != null)
            {
                return ConfigurationManager.AppSettings[propertyName].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}

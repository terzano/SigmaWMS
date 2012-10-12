#region License
//-----------------------------------------------------------------------
// <copyright file="BootStrapperManager.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Sigma.Core.BootStrapper
{
    public class BootStrapperManager
    {
        private static CommonBootStrapper _bootStrapper;

        public static void Initialize(CommonBootStrapper bootStrapper)
        {
            _bootStrapper = bootStrapper;
        }
        public static CommonBootStrapper BootStrapper
        {
            get { return _bootStrapper; }
        }
    }
}

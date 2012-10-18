#region License
//-----------------------------------------------------------------------
// <copyright file="DisposableBaseType.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using System;
#endregion 

namespace Sigma.Core.Types
{
    public class DisposableBaseType : IDisposable
    {
        private bool _disposed;
        protected bool Disposed
        {
            get
            {
                lock (this)
                {
                    return _disposed;
                }
            }
        }

        public void Dispose()
        {
            lock (this)
            {
                if (_disposed == false)
                {
                    Cleanup();
                    _disposed = true;

                    GC.SuppressFinalize(this);
                }
            }
        }

        protected virtual void Cleanup()
        {
            // override to provide cleanup
        }

        ~DisposableBaseType()
        {
            Cleanup();
        }

    }
}

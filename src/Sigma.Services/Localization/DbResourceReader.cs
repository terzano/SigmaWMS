using Sigma.Core.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Resources;

namespace Sigma.Services.Localization
{
    /// <summary>
    /// Implementation of IResourceReader required to retrieve a dictionary
    /// of resource values for implicit localization. 
    /// </summary>
    public class DbResourceReader : DisposableBaseType, IResourceReader, IEnumerable<KeyValuePair<string, object>>
    {
        private ListDictionary _resourceDictionary;

        public DbResourceReader(ListDictionary resourceDictionary)
        {
            this._resourceDictionary = resourceDictionary;
        }

        protected override void Cleanup()
        {
            try
            {
                this._resourceDictionary = null;
            }
            finally
            {
                base.Cleanup();
            }
        }

        #region IResourceReader Members

        public void Close()
        {
            this.Dispose();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            // NOTE: this is the only enumerator called by the runtime for 
            // implicit expressions

            if (Disposed)
            {
                throw new ObjectDisposedException("DBResourceReader object is already disposed.");
            }

            return this._resourceDictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException("DBResourceReader object is already disposed.");
            }

            return this._resourceDictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable<KeyValuePair<string,object>> Members

        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException("DBResourceReader object is already disposed.");
            }

            return this._resourceDictionary.GetEnumerator() as IEnumerator<KeyValuePair<string, object>>;
        }

        #endregion
    }
}

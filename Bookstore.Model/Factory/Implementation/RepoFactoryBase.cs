using Bookstore.Model.Factory.Interface;
using Bookstore.Model.Repo.Implementation;
using Bookstore.Model.Repo.Interface;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Model.Factory.Implementation
{
    public abstract class RepoFactoryBase : IRepoFactoryBase, IDisposable
    {
        public RepoFactoryBase( FbConnection connection )
        {
            Connection = connection;
        }
        public virtual IRepoBase<T> GetRepoInstance<T>() where T : EntityBase, new()
        {
            return new RepoBase<T>( Connection );
        }

        public virtual bool IsConnected
        {
            get
            {
                return Connection.State == System.Data.ConnectionState.Open;
            }
        }

        public abstract IEnumerable<string> GetSupportedEntities();

        protected FbConnection Connection { get; set; }

        #region Dispose
        private bool disposedValue;
        

        protected virtual void Dispose( bool disposing )
        {
            if ( !disposedValue )
            {
                if ( disposing )
                {
                    // TODO: dispose managed state (managed objects)                    
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                Connection.Dispose();
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~RepoFactoryBase()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose( disposing: false );
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose( disposing: true );
            GC.SuppressFinalize( this );
        }        
        #endregion

    }
}

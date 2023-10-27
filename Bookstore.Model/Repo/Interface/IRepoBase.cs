using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.Repo.Interface
{
    public interface IRepoBase<T> where T : EntityBase
    {
        IDbConnection Connection { get; }
        T Get( long id, IDbTransaction transaction = null );
        IEnumerable<T> GetAll( IDbTransaction transaction = null );
        Task<IEnumerable<T>> GetAllAsync( IDbTransaction transaction = null );
        IEnumerable<T> GetAllOrderBy( string columnName = null, IDbTransaction transaction = null );
        Task<IEnumerable<T>> GetAllOrderByAsync( string columnName = null, IDbTransaction transaction = null );
        IEnumerable<T> GetPage( int first = 10, int skip = 0, IDbTransaction transaction = null );
        T GetDefaultEntity( IDbTransaction transaction = null );
        IEnumerable<string> GetEntitiesLike( string fieldName, string searchText, bool groupBy, IDbTransaction transaction = null );
        long Add( T entity, IDbTransaction transaction = null );
        long AddRange( IEnumerable<T> entities, IDbTransaction transaction = null );
        bool Delete( long id, IDbTransaction transaction = null );
        bool DeleteAll( IDbTransaction transaction = null );
        bool Update( T entity, IDbTransaction transaction = null );
        long Count( IDbTransaction transaction = null );
        long? GetMaxId( IDbTransaction transaction = null );
        long? GetMinId( IDbTransaction transaction = null );
        bool Exists( long id, IDbTransaction transaction = null );
        void ExecuteQuery( string sql, object param = null, IDbTransaction transaction = null );
    }
}

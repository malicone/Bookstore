using Bookstore.Model.Factory.Interface;
using Bookstore.Model.Models;
using Bookstore.Model.Repo.Implementation;
using Bookstore.Model.Repo.Interface;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstore.Model.Factory.Implementation
{
    public class RepoFactory : RepoFactoryBase, IRepoFactory
    {
        public RepoFactory( FbConnection connection ) : base( connection )
        {
            
        }

        public IRepoBOOK GetRepoBOOK()
        {
            return new RepoBOOK( Connection );
        }

        public override IEnumerable<string> GetSupportedEntities()
        {
            // TODO: can be optimized with reflection
            List<EntityBase> entities = new List<EntityBase>();
            return entities.Select( e => e.GetTableName() );
        }
    }
}

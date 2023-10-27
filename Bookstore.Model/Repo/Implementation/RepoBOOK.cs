using Bookstore.Model.Models;
using Bookstore.Model.Models.Extended;
using Bookstore.Model.Repo.Interface;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.Repo.Implementation
{
    public class RepoBOOK : RepoBase<BOOK>, IRepoBOOK
    {
        public RepoBOOK( FbConnection connection ) : base( connection ) { }

        public IEnumerable<BookEx> GetAllBooks(IDbTransaction transaction = null)
        {
            if (OpenConnection())
            {
                string sql = $@"
SELECT 
b.*, 
p.Name AS PublisherName, 
g.Name AS GroupName, 
l.Name AS LanguageName,
s.Name AS ShopName, 
c.Name AS CityName 
FROM t_books b, t_publishers p, t_groups g, t_languages l, t_shops s, t_cities c
WHERE 
(b.publisher_id = p.id) 
AND (b.group_id = g.id) 
AND (b.language_id = l.id) 
AND (b.shop_id = s.id) 
AND (b.city_id = c.id)
ORDER BY b.id";
                var foundEntities = Connection.Query<BookEx>(sql, null, transaction);
                return foundEntities ?? GetEmptyEnumerable<BookEx>();
            }
            return GetEmptyEnumerable<BookEx>();
        }
        public async Task<IEnumerable<BookEx>> GetAllBooksAsync(IDbTransaction transaction = null)
        {
            if (OpenConnection())
            {
                string sql = $@"
SELECT 
b.*, 
p.Name AS PublisherName, 
g.Name AS GroupName,
l.Name AS LanguageName,
s.Name AS ShopName,
c.Name AS CityName 
FROM t_books b, t_publishers p, t_groups g, t_languages l, t_shops s, t_cities c
WHERE 
(b.publisher_id = p.id) 
AND (b.group_id = g.id) 
AND (b.language_id = l.id) 
AND (b.shop_id = s.id) 
AND (b.city_id = c.id)
ORDER BY b.id";
                var foundEntities = await Connection.QueryAsync<BookEx>(sql, null, transaction);
                return foundEntities ?? GetEmptyEnumerable<BookEx>();
            }
            return GetEmptyEnumerable<BookEx>();
        }
    }
}
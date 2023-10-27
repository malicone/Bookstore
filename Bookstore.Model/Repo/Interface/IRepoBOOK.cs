using Bookstore.Model.Models;
using Bookstore.Model.Models.Extended;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.Repo.Interface
{
    public interface IRepoBOOK : IRepoBase<BOOK>
    {
        IEnumerable<BookEx> GetAllBooks(IDbTransaction transaction = null);
        Task<IEnumerable<BookEx>> GetAllBooksAsync(IDbTransaction transaction = null);
    }
}

using Bookstore.Model.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Model.Factory.Interface
{
    public interface IRepoFactoryBase
    {
        bool IsConnected { get; }
        IRepoBase<T> GetRepoInstance<T>() where T : EntityBase, new();
        public IEnumerable<string> GetSupportedEntities();
    }
}

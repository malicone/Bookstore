using Bookstore.Model.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Bookstore.Model.Factory.Interface
{
    public interface IRepoFactory : IRepoFactoryBase
    {
        IRepoBOOK GetRepoBOOK();
    }
}

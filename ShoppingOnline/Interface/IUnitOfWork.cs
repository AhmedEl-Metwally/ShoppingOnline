using IdeaBlade.EntityModel;
using iRely.Common;
using ShoppingOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<T> Repository<T>() where T : class;
        Task<int> Complete();
    }
}

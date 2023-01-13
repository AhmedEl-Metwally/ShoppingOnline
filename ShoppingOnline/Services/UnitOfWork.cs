using IdeaBlade.EntityModel;
using Shopping_online.Models;
using ShoppingOnline.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Services.Store;

namespace ShoppingOnline.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContextDBContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreContextDBContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public GenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null) _repositories = new Hashtable();
            var type = typeof(IEntity).Name;

            if(!_repositories.ContainsKey(type))
            {
                var repositoriesTybe = typeof(GenericRepository<>);
                var repositoriesInstance = Activator.CreateInstance(repositoriesTybe.MakeGenericType(typeof(IEntity)), _context);

                _repositories.Add(type, repositoriesInstance);

            }

            return (GenericRepository<T>) _repositories[type];
        }
    }
}

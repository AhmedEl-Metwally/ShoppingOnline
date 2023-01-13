using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Interface
{
    public interface IGenericRepository<T>where T:class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpes(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int>CountAsync (ISpecification<T> spec);

        void Add (T entity);
        void Update (T entity);
        void Deleete (T entity);

    }
}

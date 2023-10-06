using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace storemanager.Infrastructure.SeedWorks
{
    public interface IRepository<T> where T : class   
    {   
        void Add(T entity);   
        void Delete(T entity);   
        void Update(T entity);
        Task<T> GetAsyncName(string name);
        Task<T> GetAsyncId(Guid id);
        Task<List<T>> GetAsync();
    }
}
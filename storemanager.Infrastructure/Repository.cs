using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using storemanager.Entity.SeedWorks;
using storemanager.Infrastructure.SeedWorks;

namespace storemanager.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Shop2023Context _dbContext;
        private DbSet<T> _dbSet;

        private DbSet<T> DbSet => _dbSet ??= _dbContext.Set<T>();

        public Repository(Shop2023Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        //public async Task<T> GetAsync(int id)
        //{
        //    return await DbSet.FirstOrDefaultAsync(_ => (_ as EntityBase).Id == id);
        //}

        public async Task<T> GetAsyncId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task<List<T>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetAsyncName(string name)
        {
            return await DbSet.FindAsync(name);
        }
    }
}
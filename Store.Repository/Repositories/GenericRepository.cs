using Microsoft.EntityFrameworkCore;
using Store.Date.Context;
using Store.Date.Entities;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext context;
        public GenericRepository(StoreDbContext context) 
        {
            this.context = context;
        }
        public async Task AddAsync(TEntity entity)
        => await context.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
        => context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync()
        => await context.Set<TEntity>().AsNoTracking().ToListAsync();
        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        => await context.Set<TEntity>().ToListAsync();

        //public async Task<TEntity> GetByIdAsNoTrackingAsync(TKey? id)
        //=> await context.Set<TEntity>().AsNoTracking().FirstOrDefault(x=>x.Id==id);

        public async Task<TEntity> GetByIdAsync(TKey? id)
        => await context.Set<TEntity>().FindAsync(id);

        public void Update(TEntity entity)
        =>  context.Set<TEntity>().Update(entity);
    }
}


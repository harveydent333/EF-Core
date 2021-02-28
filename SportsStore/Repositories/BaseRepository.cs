using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsStore.Entities;
using SportsStore.Repositories.Interfaces;
using SportsStore.Repositories.Models;

namespace SportsStore.Repositories
{
    public abstract class BaseRepository<TEntity, TKey, TContext, TModel> : IBaseRepository<TEntity, TKey, TContext, TModel>
        where TContext : DbContext
        where TModel : IBaseModel<TKey, TEntity, TContext>, new()
        where TEntity : BaseEntity<TKey>, new()
    {
        protected BaseRepository(TContext context)
        {
            Context = context ?? throw new NullReferenceException();
            EntityOriginal = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Entity => EntityOriginal;

        protected TContext Context { get; }

        protected DbSet<TEntity> EntityOriginal { get; }

        public async virtual Task<List<TEntity>> GetAsync(TModel model)
        {
            var query = model.GetQuarable(Context);
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async virtual Task<TEntity> GetFirstOrDefaultAsync(TModel model)
        {
            var query = model.GetQuarable(Context);
            return await query.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async virtual Task<TKey> CreateAsync(TEntity entity)
        {
            await EntityOriginal.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async virtual Task<IEnumerable<TKey>> CreateAsync(IEnumerable<TEntity> entity)
        {
            await EntityOriginal.AddRangeAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Select(e => e.Id).ToList();
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            EntityOriginal.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IEnumerable<TEntity> entity)
        {
            EntityOriginal.UpdateRange(entity);
            await Context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            EntityOriginal.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entity)
        {
            EntityOriginal.RemoveRange(entity);
            await Context.SaveChangesAsync();
        }
    }
}

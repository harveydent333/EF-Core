using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsStore.Entities;
using SportsStore.Repositories;
using SportsStore.Repositories.Models;

namespace SportsStore.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity, TKey, TContext, TModel>
        where TEntity : IBaseEntity<TKey>, new()
        where TContext : DbContext
        where TModel : IBaseModel<TKey, TEntity, TContext>, new()
    {
        IQueryable<TEntity> Entity { get; }

        Task<List<TEntity>> GetAsync(TModel model);

        Task<TKey> CreateAsync(TEntity entity);

        Task<IEnumerable<TKey>> CreateAsync(IEnumerable<TEntity> entity);

        Task UpdateAsync(TEntity entity);

        Task UpdateAsync(IEnumerable<TEntity> entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(IEnumerable<TEntity> entity);

        Task<TEntity> GetFirstOrDefaultAsync(TModel model);
    }
}
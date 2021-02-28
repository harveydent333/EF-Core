using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsStore.Entities;

namespace SportsStore.Repositories.Models
{
    public abstract class BaseModel<TKey, TEntity, TContext> : IBaseModel<TKey, TEntity, TContext>
        where TEntity : BaseEntity<TKey>, new()
        where TContext : DbContext
    {
        /// <summary>
        /// Список идентификаторов сущностей
        /// </summary>
        public IEnumerable<TKey> Ids { get; set; }

        public virtual IQueryable<TEntity> GetQuarable(TContext context)
        {
            var query = (IQueryable<TEntity>)context.Set<TEntity>();

            if (Ids?.Count() > 0)
            {
                if (Ids.Count() == 1)
                {
                    var id = Ids.FirstOrDefault();
                    query = query.Where(m => Equals(m.Id, id));
                }
                else
                {
                    query = query.Where(m => Ids.Contains(m.Id));
                }
            }

            return query;
        }
    }
}

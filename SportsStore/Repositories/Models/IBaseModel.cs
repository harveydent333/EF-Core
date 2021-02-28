using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsStore.Entities;

namespace SportsStore.Repositories.Models
{
    public interface IBaseModel<TKey, TEntity, TContext>
        where TEntity : IBaseEntity<TKey>, new()
        where TContext : DbContext
    {
        /// <summary>
        /// Список идентификаторов сущностей
        /// </summary>
        IEnumerable<TKey> Ids { get; set; }

        IQueryable<TEntity> GetQuarable(TContext context);
    }
}

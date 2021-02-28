using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsStore.Entities;

namespace SportsStore.Repositories.Models
{
    public class OrderModel : BaseModel<int, Order, DataContext>
    {
        /// <summary>
        /// Нужно ли возвращать список заказанных товаров <see cref="Order.Lines"/>
        /// </summary>
        public bool IncludeLines { get; set; }

        public override IQueryable<Order> GetQuarable(DataContext context)
        {
            var query = base.GetQuarable(context);

            query = AddLines(query, IncludeLines);

            return query;
        }

        protected IQueryable<Order> AddLines(IQueryable<Order> query, bool includeUser)
        {
            if (includeUser)
            {
                query = query.Include(l => l.Lines).ThenInclude(l => l.Product);
            }

            return query;
        }
    }
}

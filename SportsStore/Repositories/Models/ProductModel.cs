using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsStore.Entities;
using SportsStore.Repositories;

namespace SportsStore.Repositories.Models
{
    public class ProductModel : BaseModel<int, Product, DataContext>
    {
        /// <summary>
        /// Нужно ли возвращать котегорию товара <see cref="Product.Category"/>
        /// </summary>
        public bool IncludeCategory { get; set; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int? CategoryId { get; set; }

        public override IQueryable<Product> GetQuarable(DataContext context)
        {
            var query = base.GetQuarable(context);

            if (CategoryId != null)
            {
                query = query.Where(q => q.CategoryId == CategoryId);
            }

            query = AddCategory(query, IncludeCategory);

            return query;
        }

        protected IQueryable<Product> AddCategory(IQueryable<Product> query, bool includeUser)
        {
            if (includeUser)
            {
                query = query.Include(l => l.Category);
            }

            return query;
        }
    }
}
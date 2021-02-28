using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Entities;
using SportsStore.Repositories.Interfaces;
using SportsStore.Repositories.Models;

namespace SportsStore.Repositories
{
    public class ProductRepository : BaseRepository<Product, int, DataContext, ProductModel>, IProductRepository
    {
        public ProductRepository(DataContext context)
            : base(context)
        {
        }
    }
}

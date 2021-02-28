using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Entities;
using SportsStore.Repositories;
using SportsStore.Repositories.Models;

namespace SportsStore.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product, int, DataContext, ProductModel>
    {
    }
}

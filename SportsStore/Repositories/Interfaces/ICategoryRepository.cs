using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Entities;
using SportsStore.Repositories.Models;

namespace SportsStore.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category, int, DataContext, CategoryModel>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Entities;
using SportsStore.Repositories.Interfaces;
using SportsStore.Repositories.Models;

namespace SportsStore.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int, DataContext, CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(DataContext context)
            : base(context)
        {
        }
    }
}

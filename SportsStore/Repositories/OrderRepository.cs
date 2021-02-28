using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Entities;
using SportsStore.Repositories.Interfaces;
using SportsStore.Repositories.Models;

namespace SportsStore.Repositories
{
    public class OrderRepository : BaseRepository<Order, int, DataContext, OrderModel>, IOrderRepository
    {
        public OrderRepository(DataContext context)
            : base(context)
        {
        }
    }
}

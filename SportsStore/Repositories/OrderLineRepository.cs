using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Entities;
using SportsStore.Repositories.Interfaces;
using SportsStore.Repositories.Models;

namespace SportsStore.Repositories
{
    public class OrderLineRepository : BaseRepository<OrderLine, int, DataContext, OrderLineModel>, IOrderLineRepository
    {
        public OrderLineRepository(DataContext context)
            : base(context)
        {
        }
    }
}

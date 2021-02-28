using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

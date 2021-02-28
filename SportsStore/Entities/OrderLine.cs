using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Entities
{
    public class OrderLine : BaseEntity<int>
    {
        public int? ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; set; }
    }
}
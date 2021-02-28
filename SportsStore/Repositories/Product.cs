namespace SportsStore.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal RetailPrice { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}

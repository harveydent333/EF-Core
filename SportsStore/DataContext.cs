using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SportsStore.Configurations;
using SportsStore.Entities;

namespace SportsStore
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ProductConfiguration)));

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //foreach (var fk in cascadeFKs)
            //{
            //    fk.DeleteBehavior = DeleteBehavior.NoAction;
            //}

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Aquatics",
                    Description = "Make a splash"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Soccer",
                    Description = "The world's favorite game"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Running",
                    Description = "Run like the wind"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Kayak",
                    CategoryId = 1,
                    PurchasePrice = 200,
                    RetailPrice = 275,
                },
                new Product()
                {
                    Id = 2,
                    Name = "Lifejacket",
                    CategoryId = 2,
                    PurchasePrice = 30,
                    RetailPrice = 48.95M,
                },
                new Product()
                {
                    Id = 3,
                    Name = "Soccer Ball",
                    CategoryId = 3,
                    PurchasePrice = 17,
                    RetailPrice = 19.5M,
                });

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerName = "Bob",
                    Address = "Moscow 1",
                    ZipCode = "ZIP123",
                    State = "Done",
                    Shipped = true
                });

            modelBuilder.Entity<OrderLine>().HasData(
                new OrderLine
                {
                    Id = 1,
                    ProductId = 1,
                    OrderId = 1,
                    Quantity = 10
                });
        }
    }
}

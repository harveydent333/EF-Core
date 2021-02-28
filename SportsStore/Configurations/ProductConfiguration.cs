using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsStore.Entities;

namespace SportsStore.Configurations
{
    public class ProductConfiguration : BaseConfiguration<Product, int>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder
            .HasOne(k => k.Category)
            .WithMany()
            .HasForeignKey(f => f.CategoryId);
        }
    }
}

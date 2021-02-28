using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsStore.Entities;

namespace SportsStore.Configurations
{
    public class CategoryConfiguration : BaseConfiguration<Category, int>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
        }
    }
}

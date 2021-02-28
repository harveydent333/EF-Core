using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsStore.Entities;

namespace SportsStore.Configurations
{
    public abstract class BaseConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TKey>
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);

            ConfigureCustom(builder);
        }

        protected abstract void ConfigureCustom(EntityTypeBuilder<TEntity> builder);
    }
}

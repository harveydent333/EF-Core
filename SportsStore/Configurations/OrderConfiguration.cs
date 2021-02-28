using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsStore.Entities;

namespace SportsStore.Configurations
{
    public class OrderConfiguration : BaseConfiguration<Order, int>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder
                .HasMany(b => b.Lines)
                .WithOne();
        }
    }
}
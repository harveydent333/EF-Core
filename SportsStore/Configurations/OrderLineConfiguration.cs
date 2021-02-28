using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsStore.Entities;

namespace SportsStore.Configurations
{
    public class OrderLineConfiguration : BaseConfiguration<OrderLine, int>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable("orderLines");

            builder
                .HasOne(k => k.Order)
                .WithMany(o => o.Lines)
                .HasForeignKey(f => f.OrderId);

            builder
                .HasOne(k => k.Product)
                .WithMany()
                .HasForeignKey(f => f.ProductId);
        }
    }
}
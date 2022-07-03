using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.Position });

            builder.Property(x => x.OrderId)
                .HasColumnName("ORDER_ID");

            builder.Property(x => x.Position)
                .HasColumnName("POSITION");

            builder.Property(x => x.Name)
                .HasColumnName("NAME");

            builder.Property(x => x.NetValue)
                .HasColumnName("NET_VALUE");

            builder.ToTable("ORDER_ITEMS");
        }
    }
}
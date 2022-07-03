using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Number);
            builder.Property(x => x.Number)
                .HasColumnName("ORDER_NUMBER");

            builder.Property(x => x.PaymentMethodId)
                .HasColumnName("PAYMENT_METHOD");

            builder.Property(x => x.DeliveryMethodId)
                .HasColumnName("DELIVERY_METHOD");

            builder.Property(x => x.FreeDelivery)
                .HasColumnName("FREE_DELIVERY");

            builder.Property(x => x.GrossValue)
                .HasColumnName("GROSS_VALUE");

            builder.Property(x => x.NetValue)
                .HasColumnName("NET_VALUE");

            builder.Property(x => x.TaxValue)
                .HasColumnName("TAX_VALUE");

            builder.Property(x => x.Tax)
                .HasColumnName("TAX");

            builder.Property(x => x.CreationDate)
                .HasColumnName("CREATION_DATE");

            builder.Property(x => x.FulfillmentDate)
                .HasColumnName("FULLFILLMENT_DATE");

            builder.HasOne(x => x.PaymentMethod)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.PaymentMethodId);

            builder.HasOne(x => x.DeliveryMethod)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.DeliveryMethodId);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            builder.ToTable("ORDERS");
        }
    }
}
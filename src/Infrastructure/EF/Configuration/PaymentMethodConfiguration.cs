using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(x => x.Value);
            builder.Property(x => x.Value)
                .HasColumnName("ID");

            builder.Property(x => x.DisplayName)
                .HasColumnName("DESCRIPTION");

            builder.ToTable("PAYMENT_METHODS");
        }
    }
}
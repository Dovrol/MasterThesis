using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.HasKey(x => x.Value);
            builder.Property(x => x.Value)
                .HasColumnName("ID");

            builder.Property(x => x.DisplayName)
                .HasColumnName("DESCRIPTION");

            builder.ToTable("DELIVERY_METHODS");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID");

            builder.Property(x => x.FirstName)
                .HasColumnName("FIRST_NAME");
            
            builder.Property(x => x.LastName)
                .HasColumnName("LAST_NAME");

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL");

            builder.Property(x => x.Gender)
                .HasColumnName("GENDER");

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            builder.ToTable("CUSTOMERS");
        }
    }
}
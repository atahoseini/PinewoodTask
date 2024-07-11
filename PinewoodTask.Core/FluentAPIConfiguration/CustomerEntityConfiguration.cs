using PinewoodTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Core.FluentAPIConfiguration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(p => p.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(p => p.LastName)
                .IsRequired();
            builder.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}

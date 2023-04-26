using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCorePlayground.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCorePlayground.Data.Mappings {
    public class CustomerMap: IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
           builder.ToTable("Customers");
           builder.Property(p => p.FirstName)
               .HasMaxLength(100)
               .IsRequired() ;
           //modelBuilder.Entity<Customer>().HasKey(p => p.CustomerId);
        }
    }
}

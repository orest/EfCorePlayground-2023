using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCorePlayground.Data.Mappings;
using EfCorePlayground.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCorePlayground.Data {
    public class CustomerContext : DbContext {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =  "Data Source=.\\SQLEXPRESS;Initial Catalog=SalesDb-2023Spring;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.LogTo(Console.Write, LogLevel.Information);
            //optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(string) && p.GetColumnType() == null)) {

                property.SetIsUnicode(false);
                property.SetMaxLength(200);
            }


            //modelBuilder.Entity<Customer>().ToTable("Customers");
            //modelBuilder.Entity<Customer>().HasKey(p => p.CustomerId);
            modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

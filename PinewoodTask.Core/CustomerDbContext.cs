using Microsoft.EntityFrameworkCore;
using PinewoodTask.Core.Entities;
using PinewoodTask.Core.FluentAPIConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Core
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        }

        public DbSet<Customer> Customers => Set<Customer>();
    }
}

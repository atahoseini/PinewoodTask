using Dapper;
using LiteDB;
using Microsoft.EntityFrameworkCore;
using PinewoodTask.Core;
using PinewoodTask.Core.Entities;
using PinewoodTask.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Infrastructure.Repository
{
    public class CustomerSQLRepository : ICustomerSQLRepository
    {
        private readonly CustomerDbContext context;

        public CustomerSQLRepository(CustomerDbContext context)
        {
            this.context = context;
        }

        public async Task<Customer> GetAsync(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid customer ID.", nameof(id));
            }

            var query = "SELECT * FROM Customers WHERE Id = @Id";
            var result = await context.Customers.FromSqlRaw(query, new { Id = id }).SingleOrDefaultAsync();

            if (result == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return result;
        }

        public async Task<Customer> GetAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
            }

            var query = "SELECT * FROM Customers WHERE 1=1";

            if (!string.IsNullOrEmpty(customer.FirstName))
            {
                query += $" AND FirstName LIKE '%{customer.FirstName}%'";
            }

            if (!string.IsNullOrEmpty(customer.LastName))
            {
                query += $" AND LastName LIKE '%{customer.LastName}%'";
            }

            if (!string.IsNullOrEmpty(customer.Phone))
            {
                query += $" AND Phone LIKE '%{customer.Phone}%'";
            }

            if (!string.IsNullOrEmpty(customer.City))
            {
                query += $" AND City LIKE '%{customer.City}%'";
            }

            var result = await context.Customers.FromSqlRaw(query).SingleOrDefaultAsync();

            if (result == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }
            return result;
        }

        public async Task<List<Customer>> GetAllAsync(int page, int size)
        {
            var query = "SELECT * FROM Customers ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";
            var customers = await context.Customers.FromSqlRaw(query, new { Offset = (page - 1) * size, Size = size }).ToListAsync();
            return customers;
        }

        public async Task<List<Customer>> GetAllForLoadingAsync()
        {
            var query = "SELECT * FROM Customers";
            var customers = await context.Customers.FromSqlRaw(query).ToListAsync();
            return customers;
        }

        public async Task<long> InsertAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
            }

            customer.RegisterDate = DateTime.UtcNow;
            customer.LastLoginDate = null;

            var query = @"
            INSERT INTO Customers (FirstName, LastName, Phone, AddressLine1, AddressLine2, AddressLine3, PostCode, City, Conty, Country, RegisterDate, LastLoginDate)
            VALUES (@FirstName, @LastName, @Phone, @AddressLine1, @AddressLine2, @AddressLine3, @PostCode, @City, @Conty, @Country, @RegisterDate, @LastLoginDate);
            SELECT CAST(SCOPEIDENTITY() as bigint)";

            await context.Database.ExecuteSqlRawAsync(query, customer);
            var id = customer.Id; 
            return id;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
            }

            var existingCustomer = await context.Customers.FindAsync(customer.Id);

            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customer.Id} not found.");
            }

            var query = @"
            UPDATE Customers
            SET FirstName = @FirstName,
                LastName = @LastName,
                Phone = @Phone,
                AddressLine1 = @AddressLine1,
                AddressLine2 = @AddressLine2,
                AddressLine3 = @AddressLine3,
                PostCode = @PostCode,
                City = @City,
                Conty = @Conty,
                Country = @Country,
                RegisterDate = @RegisterDate,
                LastLoginDate = @LastLoginDate
            WHERE Id = @Id";

            await context.Database.ExecuteSqlRawAsync(query, customer);
            return customer;
        }

        public async Task<long> RemoveAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
            }

            var query = "DELETE FROM Customers WHERE Id = @Id";
            await context.Database.ExecuteSqlRawAsync(query, new { Id = customer.Id });

            return customer.Id;
        }

        public async Task<int> CountAsync()
        {
            var query = "SELECT COUNT(*) FROM Customers";
            var count = await context.Customers.FromSqlRaw(query).CountAsync();
            return count;
        }

        public async Task<Customer> GetAsync(string customerName)
        {
            var query = "SELECT * FROM Customers WHERE FirstName LIKE @CustomerName OR LastName LIKE @CustomerName";
            var result = await context.Customers.FromSqlRaw(query, new { CustomerName = $"%{customerName}%" }).SingleOrDefaultAsync();

            if (result == null)
            {
                throw new KeyNotFoundException($"Customer with name {customerName} not found.");
            }

            return result;
        }

    }
}

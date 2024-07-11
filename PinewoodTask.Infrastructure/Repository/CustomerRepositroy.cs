using Microsoft.EntityFrameworkCore;
using PinewoodTask.Core;
using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;
using PinewoodTask.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PinewoodTask.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext customerDbContext;

        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }

        public async Task<Customer> GetAsync(long id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid customer ID.", nameof(id));
                }

                var result = await customerDbContext.Customers.FindAsync(id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Customer with ID {id} not found.");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the customer.", ex);
            }
        }

        public async Task<Customer?> GetAsync(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException(nameof(customer), "The customer object cannot be null.");
                }

                Expression<Func<Customer, bool>> filter = u =>
                    (customer.Id == 0 || u.Id == customer.Id) &&
                    (string.IsNullOrEmpty(customer.City) || u.City != null && u.City.Contains(customer.City)) &&
                    (string.IsNullOrEmpty(customer.FirstName) || u.FirstName != null && u.FirstName.Contains(customer.FirstName)) &&
                    (string.IsNullOrEmpty(customer.LastName) || u.LastName != null && u.LastName.Contains(customer.LastName));

                return await customerDbContext.Customers.FirstOrDefaultAsync(filter);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the customer.", ex);
            }
        }

        public async Task<List<Customer>> GetAllAsync(int page, int size)
        {
            try
            {
                var customers = await customerDbContext.Customers
                    .Skip((page - 1) * size).Take(size)
                    .AsNoTracking()
                    .ToListAsync();
                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all customers.", ex);
            }
        }

        public async Task<List<Customer>> GetAllForLoadingAsync()
        {
            try
            {
                var customers = await customerDbContext.Customers.AsNoTracking().ToListAsync();
                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all customers for loading.", ex);
            }
        }

        public async Task<long> InsertAsync(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
                }

                customer.RegisterDate = DateTime.UtcNow;
                customer.LastLoginDate = null;

                await customerDbContext.Customers.AddAsync(customer);
                await customerDbContext.SaveChangesAsync();

                return customer.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the customer.", ex);
            }
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
                }

                var existingCustomer = await customerDbContext.Customers.FindAsync(customer.Id);

                if (existingCustomer == null)
                {
                    throw new KeyNotFoundException($"Customer with ID {customer.Id} not found.");
                }

                // Update the properties of the existing customer with the values from the incoming customer
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.AddressLine1 = customer.AddressLine1;
                existingCustomer.AddressLine2 = customer.AddressLine2;
                existingCustomer.AddressLine3 = customer.AddressLine3;
                existingCustomer.PostCode = customer.PostCode;
                existingCustomer.City = customer.City;
                existingCustomer.Conty = customer.Conty;
                existingCustomer.Country = customer.Country;
                existingCustomer.RegisterDate = customer.RegisterDate;
                existingCustomer.LastLoginDate = customer.LastLoginDate;

                await customerDbContext.SaveChangesAsync();
                return existingCustomer;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the customer.", ex);
            }
        }


        public async Task<long> RemoveAsync(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
                }

                if (!customerDbContext.Customers.Local.Contains(customer))
                {
                    customerDbContext.Customers.Attach(customer);
                }
                customerDbContext.Customers.Remove(customer);
                await customerDbContext.SaveChangesAsync();

                return customer.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while removing the customer.", ex);
            }
        }

        public async Task<int> CountAsync()
        {
            try
            {
                var count = await customerDbContext.Customers.CountAsync();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while counting the customers.", ex);
            }
        }

    }
}

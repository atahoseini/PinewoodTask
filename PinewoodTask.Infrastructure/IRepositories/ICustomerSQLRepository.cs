using PinewoodTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Infrastructure.IRepositories
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(long id);
        Task<List<T>> GetAllAsync(int page, int size);
        Task<List<T>> GetAllForLoadingAsync();
        Task<long> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<long> RemoveAsync(T entity);
        Task<int> CountAsync();
    }

    public interface ICustomerSQLRepository : IRepository<Customer>
    {
        Task<Customer> GetAsync(Customer customerName);
    }

}

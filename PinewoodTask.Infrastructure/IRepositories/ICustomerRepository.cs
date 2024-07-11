using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;

namespace PinewoodTask.Infrastructure.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(long id);
        Task<Customer?> GetAsync(Customer customer);
        Task<List<Customer>> GetAllAsync(int page, int size);
        Task<List<Customer>> GetAllForLoadingAsync();

        Task<long> InsertAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<long> RemoveAsync(Customer customer);
        Task<int> CountAsync();
    }
}

using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;
using PinewoodTask.Infrastructure.Model;

namespace PinewoodTask.Application.Interfaces
{
    public interface ICustomerSQLServices
    {
        Task<CustomerDto> Get(long id);
        Task<Customer?> Get(Customer customer);
        Task<TaskActionResult<List<CustomerDto>>> GetAll(int page, int size);
        Task<List<CustomerDto>> GetAllForLoading();
        Task<long> Add(Customer model);
        Task<CustomerDto> Update(CustomerDto model);
        Task<long> Delete(long id);
        Task<int> Count();
    }

}

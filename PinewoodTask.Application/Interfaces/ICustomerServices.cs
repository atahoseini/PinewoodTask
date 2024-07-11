using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;
using PinewoodTask.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Application.Interfaces
{
    public interface ICustomerServices
    {
        Task<CustomerDto> Get(long id);
        Task<Customer?> Get(Customer customer);
        Task<TaskActionResult<List<CustomerDto>>> GetAll(int page, int size);
        Task<List<CustomerDto>> GetAllForLoading();
        Task<Int64> Add(Customer model);
        Task<CustomerDto> Update(CustomerDto model);
        Task<long> Delete(Int64 id);
        Task<int> Count();
    }

}

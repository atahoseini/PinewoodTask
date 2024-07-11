using AutoMapper;
using Microsoft.Extensions.Logging;
using PinewoodTask.Application.Interfaces;
using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;
using PinewoodTask.Infrastructure.IRepositories;
using PinewoodTask.Infrastructure.Model;
using PinewoodTask.Infrastructure.Utility;

namespace PinewoodTask.Application.Services
{
    public class CustomerSQLServices : ICustomerSQLServices
    {
        private readonly ICustomerSQLRepository customerRepository;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerSQLServices> logger;

        public CustomerSQLServices(ICustomerSQLRepository customerRepository, IMapper mapper, ILogger<CustomerSQLServices> logger)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CustomerDto> Get(long id)
        {
            logger.LogInformation("Call Get from CustomerSQLServices");
            try
            {
                var customer = await customerRepository.GetAsync(id);
                var result = mapper.Map<CustomerDto>(customer);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while getting a customer.", ex);
            }
        }

        public async Task<Customer?> Get(Customer customer)
        {
            logger.LogInformation("Call Get from CustomerSQLServices");
            try
            {
                return await customerRepository.GetAsync(customer);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while getting a customer.", ex);
            }
        }

        public async Task<TaskActionResult<List<CustomerDto>>> GetAll(int page, int size)
        {
            logger.LogInformation("Call GetAll from CustomerSQLServices");
            var result = new TaskActionResult<List<CustomerDto>>();
            try
            {
                var foundCustomers = await customerRepository.GetAllAsync(page, size);
                var customers = mapper.Map<List<CustomerDto>>(foundCustomers);
                var totalRecordCount = await customerRepository.CountAsync();
                result.IsSuccess = true;
                result.Data = customers;
                result.Page = page;
                result.Size = size;
                result.Total = totalRecordCount;
                logger.LogInformation("GetAll from CustomerSQLServices success call");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<List<CustomerDto>> GetAllForLoading()
        {
            logger.LogInformation("Call GetAllForLoading from CustomerSQLServices");
            try
            {
                var foundCustomers = await customerRepository.GetAllForLoadingAsync();
                var result = mapper.Map<List<CustomerDto>>(foundCustomers);
                logger.LogInformation("GetAllForLoading from CustomerSQLServices success call");
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while getting customers for loading.", ex);
            }
        }

        public async Task<long> Add(Customer model)
        {
            logger.LogInformation("Call Add from CustomerSQLServices");
            try
            {
                var id = await customerRepository.InsertAsync(model);
                return id;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while adding a customer.", ex);
            }
        }

        public async Task<CustomerDto> Update(CustomerDto model)
        {
            logger.LogInformation("Call Update from CustomerSQLServices");
            try
            {
                var customer = mapper.Map<Customer>(model);
                var updatedCustomer = await customerRepository.UpdateAsync(customer);
                var result = mapper.Map<CustomerDto>(updatedCustomer);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while updating a customer.", ex);
            }
        }

        public async Task<long> Delete(long id)
        {
            logger.LogInformation("Call Delete from CustomerSQLServices");
            try
            {
                var customer = await customerRepository.GetAsync(id);
                if (customer != null)
                {
                    await customerRepository.RemoveAsync(customer);
                    return customer.Id;
                }
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while deleting a customer.", ex);
            }
        }

        public async Task<int> Count()
        {
            logger.LogInformation("Call Count from CustomerSQLServices");
            try
            {
                return await customerRepository.CountAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while counting customers.", ex);
            }
        }
    }
}





using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PinewoodTask.Application.Interfaces;
using PinewoodTask.Core;
using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;
using PinewoodTask.Infrastructure.Interfaces;
using PinewoodTask.Infrastructure.IRepositories;
using PinewoodTask.Infrastructure.Model;
using PinewoodTask.Infrastructure.Repository;
using PinewoodTask.Infrastructure.UnitOfWorks;
using PinewoodTask.Infrastructure.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Application.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly CustomerDbContext customerDbContext;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerServices> logger;
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerServices(CustomerDbContext customerDbContext, IMapper mapper, ILogger<CustomerServices> logger, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerDbContext=customerDbContext;
            this.mapper = mapper;
            this.logger=logger;
            this.customerRepository=customerRepository;
            this.unitOfWork=unitOfWork;
        }

        public async Task<CustomerDto> Get(long id)
        {
            logger.LogInformation("Call Get from CustomerServices");
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


        public async Task<long> Add(Customer model)
        {
            logger.LogInformation("Call Add from CustomerServices");
            try
            {
                var id = await customerRepository.InsertAsync(model);
                await unitOfWork.SaveChangesAsync();
                return id;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while adding a customer.", ex);
            }
        }

        public async Task<int> Count()
        {
            logger.LogInformation("Call Count from CustomerServices");
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

        public async Task<long> Delete(long id)
        {
            logger.LogInformation("Call Delete from CustomerServices");
            try
            {
                var customer = await customerRepository.GetAsync(id);
                if (customer != null)
                {
                    await customerRepository.RemoveAsync(customer);
                    await unitOfWork.SaveChangesAsync();
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



        public async Task<Customer?> Get(Customer customer)
        {
            logger.LogInformation("Call Get from CustomerServices");
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
            logger.LogInformation("Call GetAll from CustomerServices");
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
                logger.LogInformation("GetAll from CustomerServices success call");
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
            logger.LogInformation("Call GetAllForLoading from CustomerServices");
            try
            {
                var foundCustomers = await customerRepository.GetAllForLoadingAsync();
                var result = mapper.Map<List<CustomerDto>>(foundCustomers);
                logger.LogInformation("GetAllForLoading from CustomerServices success call");
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while getting customers for loading.", ex);
            }
        }


        public async Task<CustomerDto> Update(CustomerDto model)
        {
            logger.LogInformation("Call Update from CustomerServices");
            try
            {
                var customer = mapper.Map<Customer>(model);
                var updatedCustomer = await customerRepository.UpdateAsync(customer);
                await unitOfWork.SaveChangesAsync();
                var result = mapper.Map<CustomerDto>(updatedCustomer);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw new MyException("An error occurred while updating a customer.", ex);
            }
        }

    }
}





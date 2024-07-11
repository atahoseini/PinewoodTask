using Microsoft.AspNetCore.Mvc;
using PinewoodTask.Application.Interfaces;
using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;

namespace PinewoodTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CustomerSqlController : ControllerBase
    {
        private readonly ICustomerSQLServices _customerSQLServices;

        public CustomerSqlController(ICustomerSQLServices customerSQLServices)
        {
            _customerSQLServices = customerSQLServices;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid customer ID");
            }
            var result = await _customerSQLServices.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int size = 5)
        {
            if (page <= 0 || size <= 0)
            {
                return BadRequest("Invalid page or size values");
            }
            var result = await _customerSQLServices.GetAll(page, size);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("loadCustomers")]
        public async Task<IActionResult> GetAllForLoading()
        {
            var result = await _customerSQLServices.GetAllForLoading();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _customerSQLServices.Add(model);
            return Ok(result);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(CustomerDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _customerSQLServices.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid customer ID");
            }
            var result = await _customerSQLServices.Delete(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }

}



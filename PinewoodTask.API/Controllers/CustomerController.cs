using Microsoft.AspNetCore.Mvc;
using PinewoodTask.Application.Interfaces;
using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;

namespace PinewoodTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            this.customerServices = customerServices;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid customer ID");
            }
            var result = await customerServices.Get(id);
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
            var result = await customerServices.GetAll(page, size);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("loadCustomers")]
        public async Task<IActionResult> GetAllForLoading()
        {
            var result = await customerServices.GetAllForLoading();
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
            var result = await customerServices.Add(model);
            return Ok(result);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(CustomerDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await customerServices.Update(model);
            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid customer ID");
            }
            var result = await customerServices.Delete(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }

}



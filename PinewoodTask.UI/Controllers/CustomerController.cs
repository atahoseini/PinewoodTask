using Microsoft.AspNetCore.Mvc;
using PinewoodTask.Application.Interfaces;
using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;

namespace PinewoodTask.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServices customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            this.customerServices = customerServices;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await customerServices.GetAllForLoading();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await customerServices.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var customer = await customerServices.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerDto customer)
        {
            if (ModelState.IsValid)
            {
                await customerServices.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await customerServices.Delete(id);
            return Ok(new { success = true });
        }
    }
}

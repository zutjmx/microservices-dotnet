using Customers.API.Models;
using Customers.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _customerService.FindAllAsync();
            return Ok(result);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            var result = await _customerService.InsertAsync(customer);
            return Ok(result);
        }

        // PUT: api/customers 
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Customer customer)
        {
            var result = await _customerService.UpdateAsync(customer);
            return Ok(result);
        }

        // DELETE api/tasks?id=5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _customerService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
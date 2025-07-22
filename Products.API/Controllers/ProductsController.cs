using Products.API.Models;
using Products.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _productService.FindAllAsync();
            return Ok(result);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.FindOneAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var result = await _productService.InsertAsync(product);
            return Ok(result);
        }

        // PUT: api/products 
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            var result = await _productService.UpdateAsync(product);
            return Ok(result);
        }

        // DELETE api/products?id=5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _productService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
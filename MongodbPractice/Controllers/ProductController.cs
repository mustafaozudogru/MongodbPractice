using Microsoft.AspNetCore.Mvc;
using MongodbPractice.Models;
using MongodbPractice.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongodbPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productService;

        public ProductController(IProductServices productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Products>> Get()
        {
            var products = await this.productService.GetAllAsync().ConfigureAwait(false);

            return products;
        }

        // GET api/<ProductController>/.
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await this.productService.GetAsync(id).ConfigureAwait(false);

            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Products request)
        {
            var result = await this.productService.CreateAsync(request).ConfigureAwait(false);

            return Ok(result);
        }

        // PUT api/<ProductController>/.
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Products request)
        {
            var result = await this.productService.UpdateAsync(request).ConfigureAwait(false);

            return Ok(result);
        }

        // DELETE api/<ProductController>/.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.productService.DeleteAsync(id).ConfigureAwait(false);

            return Ok();
        }
    }
}

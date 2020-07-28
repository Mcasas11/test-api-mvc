using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoApiNetCoreMVC.Contexts;
using demoApiNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoApiNetCoreMVC.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiDbContext context;
        public ProductsController(ApiDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Product.ToList();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = context.Product.FirstOrDefault(d => d.productCode == id);
            return product;
        }

        /// <summary>
        /// Create new Product
        /// </summary>
        /// <remarks>
        /// {
        ///  "productName": 1,
        ///  "productDescription": desc,
        ///  "productPrice": price
        ///  }
        /// </remarks>
        /// <param name="product"></param>
        /// <returns>A newly product was created</returns>
        /// <response code ="201">Newly product created</response>
        /// <response code ="400">Failed</response>
        [HttpPost]
        public ActionResult Post(Product product)
        {
            try
            {
                context.Product.Add(product);
                context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Product product)
        {
            if (product.productCode == id)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete a specific item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = context.Product.FirstOrDefault(d => d.productCode == id);
            if (product != null)
            {
                context.Product.Remove(product);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

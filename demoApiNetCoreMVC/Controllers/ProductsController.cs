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
    [Route("api/[controller]")]
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

        // POST api/<ProductsController>
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

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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

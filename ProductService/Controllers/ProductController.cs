using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.DBContexts;
using Microsoft.EntityFrameworkCore;
using ProductService.Models;
using ProductService.Repository;
using System.Transactions;
using Microsoft.AspNetCore.Cors;

namespace ProductService.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;
        private readonly ProductContext productContext;

        public ProductController(ProductRepository productRepository,ProductContext productContext)
        {
            this.productRepository = productRepository;
            this.productContext = productContext;
        }

        // GET: api/Product
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetProducts();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        [Route("api/[controller]")]
        public Product Get(int id)
        {
            return productRepository.GetProductByID(id);
        }

        // POST: api/Product
        [HttpPost]
        [Route("api/product")]
        public IActionResult Post([FromBody] Product product)
        {
            productRepository.InsertProduct(product);
            return CreatedAtAction("Get", new { id = product.ID }, product);

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    productRepository.UpdateProduct(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}"),Route("api/product/{id?}")]
        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);
            return new OkResult();
        }

        [Route("sarwan/{id?}")]
        public IActionResult TestAction(int id)
        {
            Product product = productContext.Products.Where(x => x.ID == id).First();
            return CreatedAtAction("Get", new { id = product.ID }, product);
        }
    }
}

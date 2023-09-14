using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ProductReviewWebAPi.Data;
using ProductReviewWebAPi.DTOs;
using ProductReviewWebAPi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductReviewWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProductsController> // Get All
        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();
            return StatusCode(200, products);
        }


        // GET: api/<ProductsController> // Get All under 20$
        [HttpGet ("MaxPrice")]
        public IActionResult GetMaxPrice([FromQuery]double?maxPrice=20) 
        {
            
            var products= _context.Products.ToList();   


            if(maxPrice != null)
            {
                products= products.Where(c=> c.Price < maxPrice ).ToList();
            }
          
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]  
        public IActionResult Post([FromBody] ProductDTO product)
        {
            {
                var products = new Product()
                {   Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                };

                _context.Products.Add(products);
                _context.SaveChanges();

                return CreatedAtAction("Get", new { id = product.Id }, product);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDTO product)
        {

            var existingProduct = _context.Products.Where(p => p.Id == id).FirstOrDefault();

            if (existingProduct!= null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
               
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return StatusCode(200, product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

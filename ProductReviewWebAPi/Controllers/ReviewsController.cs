using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductReviewWebAPi.Data;
using ProductReviewWebAPi.DTOs;
using ProductReviewWebAPi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductReviewWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ReviewsController>
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews.ToList();
            return StatusCode(200, reviews);
        }

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        // GET api/<ReviewsController>/5
        [HttpGet("ProductId")]
        public IActionResult GetByProductId([FromQuery] int? ProductId)
        {
            var reviews = _context.Reviews.ToList();
           if(ProductId != null)
            {
                reviews = reviews.Where(r => r.ProductId == ProductId).ToList();
            }
            return Ok(reviews);
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {

            {

                var reviews = new Review()
                {
                    Text = review.Text,
                    Rating = review.Rating,
                    ProductId = review.ProductId,
                };
                
                _context.Reviews.Add(reviews);
                _context.SaveChanges();

                return StatusCode(201, reviews);
            }
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review review)
        {

            var existingReview = _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
            if (existingReview!= null)
            {
                existingReview.Text = review.Text;
                existingReview.Rating = review.Rating;
                existingReview.ProductId = review.ProductId;
                _context.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            return StatusCode(200, review);
        }

        // DELETE api/<ReviewsController>/5
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProductReviewWebAPi.Models;

namespace ProductReviewWebAPi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }
    }
    
    
}

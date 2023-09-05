using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductReviewWebAPi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
         
        //Navigation property
         public ICollection<Review> Reviews { get; set; }
        
       
       
    }
}


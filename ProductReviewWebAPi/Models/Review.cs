using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductReviewWebAPi.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }



        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}

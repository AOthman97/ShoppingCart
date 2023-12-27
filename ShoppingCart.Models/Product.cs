using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Discription { get; set; }
        public double Price { get; set; }
        public required string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
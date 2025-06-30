using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal Price { get; set; }
    }
}

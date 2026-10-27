using System.ComponentModel.DataAnnotations;

namespace bai3.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null;
    }
}

using System.ComponentModel.DataAnnotations;

namespace bai3.Models
{
    public class Category
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; }
    }
}

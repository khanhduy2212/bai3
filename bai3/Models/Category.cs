using System.ComponentModel.DataAnnotations;

namespace bai3.Models
{
    public class Category
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is require")]
        [StringLength(100,MinimumLength =2,ErrorMessage ="Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;

namespace bai3.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

        // Id danh mục được chọn
        public int CategoryId { get; set; }

        // Tên danh mục để hiển thị lên bảng Index (Laptop, Phone...)
        public string CategoryName { get; set; } = string.Empty;

        // Danh sách để đổ vào ô Dropdown cho người dùng CHỌN
        public SelectList? CategoryList { get; set; }
    }
}

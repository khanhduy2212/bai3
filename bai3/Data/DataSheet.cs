using bai3.Models;

namespace bai3.Data
{
    public static class DataSheet
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category() { Id = 1, Name = "Laptop" },
            new Category() { Id = 2, Name = "Phone" },
            new Category() { Id = 3, Name = "Tablet" },
        };

        public static List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Name = "MacBook Pro M3", Price = 35000000, Description = "Laptop cao cấp Apple", CategoryId = 1 },
            new Product() { Id = 2, Name = "iPhone 15 Pro", Price = 28000000, Description = "Điện thoại Apple", CategoryId = 2 },
            new Product() { Id = 3, Name = "iPad Pro M2", Price = 20000000, Description = "Máy tính bảng Apple", CategoryId = 3 },
            new Product() { Id = 4, Name = "Dell XPS 13", Price = 42000000, Description = "Laptop mỏng nhẹ", CategoryId = 1 },
            new Product() { Id = 5, Name = "ThinkPad X1 Carbon", Price = 48000000, Description = "Laptop dành cho công việc", CategoryId = 1 },
            new Product() { Id = 6, Name = "Samsung Galaxy S24", Price = 23000000, Description = "Điện thoại Samsung", CategoryId = 2 },
            new Product() { Id = 7, Name = "Google Pixel 9", Price = 21000000, Description = "Điện thoại Google", CategoryId = 2 },
            new Product() { Id = 8, Name = "iPad Air M2", Price = 18000000, Description = "Máy tính bảng Apple", CategoryId = 3 },
            new Product() { Id = 9, Name = "Galaxy Tab S9", Price = 22000000, Description = "Máy tính bảng Samsung", CategoryId = 3 }
        };
    }
}


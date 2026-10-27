using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bai3.Models;

namespace bai3.Controllers
{
    public class ProductController : Controller
    {
        // Gia lap csdl Product
        public static List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Name = "MacBook Pro M3", Price = 35000000, Description = "Laptop cao cấp Apple", CategoryId = 1 },
            new Product() { Id = 2, Name = "iPhone 15 Pro", Price = 28000000, Description = "Điện thoại Apple", CategoryId = 2 },
            new Product() { Id = 3, Name = "iPad Pro M2", Price = 20000000, Description = "Máy tính bảng Apple", CategoryId = 3 },
        };

        // GET: ProductController
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var EditProduct = products.FirstOrDefault(p => p.Id == id);
            if (EditProduct == null)
            {
                return NotFound();
            }
            return View(EditProduct);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}

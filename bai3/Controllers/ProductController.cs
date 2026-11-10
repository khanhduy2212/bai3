using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using bai3.Models;
using bai3.Data;

namespace bai3.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        //public ActionResult Index()
        //{
        //    return View(DataSheet.products);
        //}

        //public ActionResult Index(string? searchString)
        //{
        //    var search = searchString?.Trim();
        //    ViewData["SearchString"] = search;
        //    var products = DataSheet.products.AsQueryable();
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        products = products.Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        //    }
        //    return View(products.Select(ToViewModel).ToList());
        //}

        //    public ActionResult Index(
        //string? searchString,
        //string? sortBy = "name",
        //bool descending = false)
        //    {
        //        var search = searchString?.Trim();
        //        var sort = sortBy?.Trim().ToLowerInvariant();

        //        ViewData["SearchString"] = search;

        //        IEnumerable<Product> products = DataSheet.products;

        //        if (!string.IsNullOrEmpty(search))
        //        {
        //            products = products.Where(p =>
        //                p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
        //        }

        //        switch (sort)
        //        {
        //            case "id":
        //                products = descending
        //                    ? products.OrderByDescending(p => p.Id)
        //                    : products.OrderBy(p => p.Id);
        //                break;

        //            case "price":
        //                products = descending
        //                    ? products.OrderByDescending(p => p.Price)
        //                    : products.OrderBy(p => p.Price);
        //                break;

        //            case "description":
        //                products = descending
        //                    ? products.OrderByDescending(p => p.Description)
        //                    : products.OrderBy(p => p.Description);
        //                break;

        //            case "categoryid":
        //                products = descending
        //                    ? products.OrderByDescending(p => p.CategoryId)
        //                    : products.OrderBy(p => p.CategoryId);
        //                break;

        //            default:
        //                sort = "name";
        //                products = descending
        //                    ? products.OrderByDescending(p => p.Name)
        //                    : products.OrderBy(p => p.Name);
        //                break;
        //        }

        //        ViewData["SortBy"] = sort;
        //        ViewData["Descending"] = descending;

        //        return View(products.Select(ToViewModel).ToList());
        //    }

        public ActionResult Index(
string? searchString,
string? sortBy = "name",
bool descending = false,
int page = 1)
        {
            const int pageSize = 2;

            var search = searchString?.Trim();
            var sort = sortBy?.Trim().ToLowerInvariant();

            ViewData["SearchString"] = search;

            IEnumerable<Product> products = DataSheet.products;

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p =>
                    p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            switch (sort)
            {
                case "id":
                    products = descending
                        ? products.OrderByDescending(p => p.Id)
                        : products.OrderBy(p => p.Id);
                    break;

                case "price":
                    products = descending
                        ? products.OrderByDescending(p => p.Price)
                        : products.OrderBy(p => p.Price);
                    break;

                case "description":
                    products = descending
                        ? products.OrderByDescending(p => p.Description)
                        : products.OrderBy(p => p.Description);
                    break;

                case "categoryid":
                    products = descending
                        ? products.OrderByDescending(p => p.CategoryId)
                        : products.OrderBy(p => p.CategoryId);
                    break;

                default:
                    sort = "name";
                    products = descending
                        ? products.OrderByDescending(p => p.Name)
                        : products.OrderBy(p => p.Name);
                    break;
            }

            var totalCount = products.Count();
            var totalPages = Math.Max(1, (int)Math.Ceiling(totalCount / (double)pageSize));
            page = Math.Clamp(page, 1, totalPages);

            ViewData["SortBy"] = sort;
            ViewData["Descending"] = descending;
            ViewData["Page"] = page;
            ViewData["TotalPages"] = totalPages;

            var pageProducts = products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(ToViewModel)
                .ToList();

            return View(pageProducts);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = DataSheet.products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(DataSheet.categories, "Id", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = DataSheet.products.Any() ? DataSheet.products.Max(p => p.Id) + 1 : 1;
                DataSheet.products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(DataSheet.categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var EditProduct = DataSheet.products.FirstOrDefault(p => p.Id == id);
            if (EditProduct == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(DataSheet.categories, "Id", "Name", EditProduct.CategoryId);
            return View(EditProduct);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var existingProduct = DataSheet.products.FirstOrDefault(p => p.Id == product.Id);
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
            var product = DataSheet.products.FirstOrDefault(p => p.Id == id);
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
            var product = DataSheet.products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            DataSheet.products.Remove(product);
            return RedirectToAction(nameof(Index));
        }

        private static ProductViewModel ToViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CategoryName = DataSheet.categories
        .FirstOrDefault(c => c.Id == product.CategoryId)?.Name ?? string.Empty
            };
        }
    }
}

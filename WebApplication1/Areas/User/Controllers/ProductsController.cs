using Ecommerce.Data;
using Ecommerce.Eunums;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.User.Controllers
{
    [Area("User")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index(int categoryId)
        {
            var category = context.Categories
                .FirstOrDefault(c =>
                    c.Id == categoryId &&
                    c.Status == Status.Active);

            if (category is null)
            {
                return NotFound();
            }

            var products = context.Products
                .Where(p =>
                    p.CategoryId == categoryId &&
                    p.Status == Status.Active)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    MainImage = p.MainImage,
                    CategoryName = category.Name
                })
                .ToList();

            ViewBag.CategoryName = category.Name;

            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = context.Products
                .Where(p =>
                    p.Id == id &&
                    p.Status == Status.Active &&
                    p.Category.Status == Status.Active)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Rate = p.Rate,
                    MainImage = p.MainImage,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name
                })
                .FirstOrDefault();

            if (product is null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
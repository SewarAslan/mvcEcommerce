using Ecommerce.Models;
using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.ViewModels;
using Mapster;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IWebHostEnvironment webHostEnvironment)
        {
            context = new ApplicationDbContext();
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var productsVM = context.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    MainImage = p.MainImage,
                    CategoryName = p.Category.Name,
                    Status = p.Status
                })
                .ToList();

            return View(productsVM);
        }


        public IActionResult Create()
        {
            ViewBag.Categories = context.Categories.ToList();

            return View(new CreateProductViewModel());
        }


        [HttpPost]
        public IActionResult Store(CreateProductViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = context.Categories.ToList();
                return View("Create", request);
            }

            var product = request.Adapt<Product>();


            // Generate image name
            var extension = Path.GetExtension(request.MainImage.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;


            // Correct wwwroot path
            var folderPath = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "images",
                "products"
            );


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            var filePath = Path.Combine(folderPath, fileName);


            using (var stream = System.IO.File.Create(filePath))
            {
                request.MainImage.CopyTo(stream);
            }


            product.MainImage = fileName;

            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }


            ViewBag.Categories = context.Categories.ToList();


            var model = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Rate = product.Rate,
                Status = product.Status,
                CategoryId = product.CategoryId,
                CurrentImage = product.MainImage
            };


            return View(model);
        }


        [HttpPost]
        public IActionResult Update(EditProductViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = context.Categories.ToList();

                return View("Edit", request);
            }


            var product = context.Products.Find(request.Id);

            if (product is null)
            {
                return NotFound();
            }


            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.Rate = request.Rate;
            product.Status = request.Status;
            product.CategoryId = request.CategoryId;


            // User selected a new image
            if (request.MainImage != null)
            {
                var folderPath = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "images",
                    "products"
                );


                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }


                // Delete old image
                if (!string.IsNullOrEmpty(product.MainImage))
                {
                    var oldImagePath = Path.Combine(
                        folderPath,
                        product.MainImage
                    );


                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }


                // Save new image
                var extension = Path.GetExtension(request.MainImage.FileName);
                var fileName = Guid.NewGuid().ToString() + extension;

                var filePath = Path.Combine(folderPath, fileName);


                using (var stream = System.IO.File.Create(filePath))
                {
                    request.MainImage.CopyTo(stream);
                }


                product.MainImage = fileName;
            }


            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);

            if (product is null)
            {
                return RedirectToAction(nameof(Index));
            }


            // Delete image from wwwroot
            if (!string.IsNullOrEmpty(product.MainImage))
            {
                var imagePath = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "images",
                    "products",
                    product.MainImage
                );


                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }


            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
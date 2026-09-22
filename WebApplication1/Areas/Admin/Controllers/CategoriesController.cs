using Ecommerce.Data;
using Ecommerce.Eunums;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categoriesVm = context.Categories.ToList().Adapt<List<CategoryViewModel>>(); 

            return View(categoriesVm);
        }
        public IActionResult Create()
        {
            return View(new CreateCategoryViewModel());
        }
        public IActionResult Store(CreateCategoryViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", request);
            }
            var Category = request.Adapt<Category>();
            context.Categories.Add(Category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if(category is null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

        }
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var model = category.Adapt<EditCategoryViewModel>();
                return View(model);
            } }
        public IActionResult Update(EditCategoryViewModel request)
        {
    
            var category = context.Categories.Find(request.Id);
            if(category is null)
            {
                return NotFound();
            }
            request.Adapt(category);
        
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

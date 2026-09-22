using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.User.Controllers
{
    [Area("User") ]
  
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.Categories.Where(c=>c.Status == Eunums.Status.Active).ToList();
            return View(categories);
        }
    }
}

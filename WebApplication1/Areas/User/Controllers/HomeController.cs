using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.User.Controllers
{
    [Area("User") ]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

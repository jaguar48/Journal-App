using Microsoft.AspNetCore.Mvc;

namespace Blog_App.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

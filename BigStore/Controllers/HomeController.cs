using Microsoft.AspNetCore.Mvc;

namespace BigStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

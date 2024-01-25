using Microsoft.AspNetCore.Mvc;

namespace DrugStore4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

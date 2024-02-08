using Microsoft.AspNetCore.Mvc;

namespace DrugStore4.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

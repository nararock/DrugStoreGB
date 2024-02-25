using DrugStore4.Classes;
using DrugStore4.DrugStoreDb;
using DrugStore4.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore4.Controllers
{
    public class HomeController : Controller
    {
        private DrugStoreDbContext _dbContext;
        public HomeController(DrugStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            CatalogHelper catalogHelper = new CatalogHelper();
            CommonCatalogModel commonModel = catalogHelper.getCommonCatalogModel(_dbContext, 1, "", "0", "");
            return View(commonModel);
        }
    }
}

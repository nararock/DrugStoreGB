using DrugStore4.Classes;
using DrugStore4.DrugStoreDb;
using DrugStore4.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore4.Controllers
{
    public class CatalogController : Controller
    {
        private DrugStoreDbContext _dbContext;
        public CatalogController(DrugStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            CatalogHelper catalogHelper = new CatalogHelper();
            List<CatalogModel> adModels = catalogHelper.getAds(_dbContext, 1);
            return View(adModels);
        }
    }
}

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

        public IActionResult Index(string page = "1", string type = "", string filter = "0")
        {
            int numPage = int.Parse(page);
            CatalogHelper catalogHelper = new CatalogHelper();
            CommonCatalogModel commonModel = catalogHelper.getCommonCatalogModel(_dbContext, numPage, type, filter);
            return View(commonModel);
        }
    }
}

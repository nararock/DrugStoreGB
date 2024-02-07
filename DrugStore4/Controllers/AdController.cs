using DrugStore4.Classes;
using DrugStore4.DrugStoreDb;
using DrugStore4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore4.Controllers
{
    public class AdController : Controller
    {
        private DrugStoreDbContext _dbContext;
        public AdController(DrugStoreDbContext drugStoreDb) {
            _dbContext = drugStoreDb;
        }

        [HttpGet]
        public IActionResult Create()
        {
            AdHelper adHelper = new AdHelper();
            CreateAdModel createAdModel = adHelper.getTypeCategoryDrug(_dbContext);
            return View(createAdModel);
        }

        [HttpPost]
        public void Create([FromBody] AdModel adModel)
        {
            Console.WriteLine();
        }
        
    }
}

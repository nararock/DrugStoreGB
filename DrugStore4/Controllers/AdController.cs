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
        [Authorize][HttpGet]
        public IActionResult Create()
        {
            AdHelper adHelper = new AdHelper();
            CreateAdModel createAdModel = adHelper.getTypeCategoryDrug(_dbContext);
            return View(createAdModel);
        }

        [Authorize][HttpPost]
        public async Task<JsonResult> Create([FromBody] AdModel adModel)
        {
            CommonResponse result = new CommonResponse();
            if (adModel.Title == null || adModel.Dose == null || adModel.Amount == null)
            {
                result.Code = 1;
                result.Message = "Поля с названием лекарства, дозой и оставшимся количеством должны быть заполнены.";
                return new JsonResult(result);
            }
            string nameUser = User.Identity.Name;
            AdHelper adHelper = new AdHelper();
            adHelper.createNewAd(_dbContext, adModel, nameUser);
            result.Code = 0;
            result.Message = "";
            return new JsonResult(result);
        }
        
    }
}

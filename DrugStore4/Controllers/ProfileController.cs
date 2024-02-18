using DrugStore4.Classes;
using DrugStore4.DrugStoreDb;
using DrugStore4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore4.Controllers
{
    public class ProfileController(DrugStoreDbContext drugStoreDb) : Controller
    {
        private DrugStoreDbContext _dbContext = drugStoreDb;

        [Authorize]
        public IActionResult Index()
        {
            ProfileHelper profileHelper = new ProfileHelper();
            ProfileModel model = profileHelper.getProfileData(_dbContext, User.Identity.Name);
            return View(model);
        }

        public CommonResponse DeleteAd(string id)
        {
            CommonResponse commonResponse = new CommonResponse();
            short parseId;
            bool ansParse = Int16.TryParse(id, out parseId);
            if (!ansParse) {
                commonResponse.Code = 1;
                return commonResponse;
            }
            ProfileHelper profileHelper = new ProfileHelper();
            bool answer = profileHelper.DeleteAd(drugStoreDb, User.Identity.Name, parseId);
            
            if (answer)
            {                
                commonResponse.Code = 0;
                return commonResponse;
            }
            commonResponse.Code = 1;
            return commonResponse;
        }
    }
}

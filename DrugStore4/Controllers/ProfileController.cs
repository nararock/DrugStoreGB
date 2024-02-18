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
    }
}

using DrugStore4.DrugStoreDb;
using DrugStore4.Models;

namespace DrugStore4.Classes
{
    public class AdHelper
    {
        public CreateAdModel getTypeCategoryDrug(DrugStoreDbContext dbContext)
        {
            List<SimpleCommonModel> typeName = dbContext.Type.Select(x => new SimpleCommonModel(x.Id, x.Name)).ToList();
            List<SimpleCommonModel> categoryName = dbContext.Category.Select(x => new SimpleCommonModel(x.Id, x.Name)).ToList();
            CreateAdModel createAdModel = new CreateAdModel(typeName, categoryName);
            return createAdModel;
        }

        public void createNewAd(DrugStoreDbContext dbContext, AdModel adModel, string nameUser)
        {
            string userId = dbContext.Users.FirstOrDefault(m => m.UserName == nameUser).Id;
            Ad ad = new()
            {
                Title = adModel.Title,
                Description = adModel.Description,
                Manufacturer = adModel.Manufacturer,
                Dose = adModel.Dose,
                Month = adModel.Month,
                Year = adModel.Year,
                Amount = adModel.Amount,
                CategoryId = adModel.Category,
                TypeId = adModel.Type,
                UserId = userId
            };

            dbContext.Ads.Add(ad);
            dbContext.SaveChanges();
        }

        public AdInfoModel getAd(DrugStoreDbContext dbContext, int id)
        {
            List<AdInfoModel> adInfo = dbContext.Ads.Where(i => i.Id == id).Select(u => new AdInfoModel
            {
                Title = u.Title,
                Description = u.Description,
                Manufacturer = u.Manufacturer,
                Dose = u.Dose,
                Month = u.Month,
                Year = u.Year,
                Amount = u.Amount,
                Type = u.DrugType.Name,
                Category = u.DrugCategory.Name,
                Nickname = u.User.Nickname,
                UserPhone = u.User.PhoneNumber,
                City = u.User.City,
                District = u.User.District
            }).ToList();
            return adInfo[0];
        }
    }
}

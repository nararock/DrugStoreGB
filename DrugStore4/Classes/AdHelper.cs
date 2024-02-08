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
                Category = adModel.Category,
                Type = adModel.Type,
                UserId = userId
            };

            dbContext.Ads.Add(ad);
            dbContext.SaveChanges();
        }
    }
}

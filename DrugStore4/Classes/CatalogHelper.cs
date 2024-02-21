using DrugStore4.DrugStoreDb;
using DrugStore4.Models;

namespace DrugStore4.Classes
{
    public class CatalogHelper
    {
        private int blockNumber = 9;
        public List<CatalogModel> getAds(DrugStoreDbContext dbContext, int page)
        {
            List<CatalogModel> adModels = dbContext.Ads.Skip((page - 1) * blockNumber).Take(blockNumber)
                                                   .Select(a => new CatalogModel {
                                                                              Id = a.Id,
                                                                              Title = a.Title,
                                                                              Type = a.DrugType.Name,
                                                                              Category = a.DrugCategory.Name,
                                                                              PictureURL = a.DrugCategory.PictureURL,
                                                                              Dose = a.Dose,
                                                                              Amount = a.Amount,
                                                                              Month = a.Month,
                                                                              Year = a.Year,
                                                                              Manufacturer = a.Manufacturer,
                                                                              Description = a.Description,
                                                                              })
                                                   .ToList();
            return adModels;
        }
        public int getAmountPage(DrugStoreDbContext dbContext)
        {
            int amount = (dbContext.Ads.Count() / blockNumber);
            return amount;
        }

        public CommonCatalogModel getCommonCatalogModel(DrugStoreDbContext dbContext, int page)
        {
            List<CatalogModel> catalogModels = getAds(dbContext, page);
            int amount = getAmountPage(dbContext);
            CommonCatalogModel commonModel = new CommonCatalogModel
            {
                NumberPage = page,
                catalogModels = catalogModels,
                AmountPage = amount
            };
            return commonModel;
        }
    }
}

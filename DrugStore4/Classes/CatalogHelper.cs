using DrugStore4.DrugStoreDb;
using DrugStore4.Models;

namespace DrugStore4.Classes
{
    public class CatalogHelper
    {
        private int blockNumber = 9;
        public List<CatalogModel> getAds(DrugStoreDbContext dbContext, int page, string type)
        {
            List<CatalogModel> adModels = [];
            bool typeBool = int.TryParse(type, out int numType);
            if (!typeBool)
            {
                adModels = dbContext.Ads.Skip((page - 1) * blockNumber).Take(blockNumber)
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
            }            
            else
            {
                adModels = dbContext.Ads.Skip((page - 1) * blockNumber).Take(blockNumber).Where(a => a.DrugType.Id == numType)
                                                                   .Select(a => new CatalogModel
                                                                   {
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
            }
            return adModels;
        }
        public int getAmountPage(DrugStoreDbContext dbContext, string type)
        {
            bool typeBool = int.TryParse(type, out int numType);
            int amount = 0;
            if (!typeBool)
            {
                amount = (dbContext.Ads.Count() / blockNumber);
            }
            else
            {
                amount = (dbContext.Ads.Where(a => a.DrugType.Id == numType).Count()/blockNumber);
            }
            return amount;
        }

        public List<DrugType> getListType(DrugStoreDbContext dbContext)
        {
            List<DrugType> types = dbContext.Type.Select(t =>  new DrugType { Id = t.Id, Name = t.Name}).ToList();
            return types;
        }

        public CommonCatalogModel getCommonCatalogModel(DrugStoreDbContext dbContext, int page, string type)
        {
            List<CatalogModel> catalogModels = getAds(dbContext, page, type);
            int amount = getAmountPage(dbContext, type);
            List<DrugType> types = getListType(dbContext);
            CommonCatalogModel commonModel = new CommonCatalogModel
            {
                NumberPage = page,
                CatalogModels = catalogModels,
                Types = types,
                SelectedTypeId = int.TryParse(type, out int numType)?numType : 0,
                AmountPage = amount
            };
            return commonModel;
        }
    }
}

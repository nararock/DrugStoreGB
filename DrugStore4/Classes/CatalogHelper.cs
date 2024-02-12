using DrugStore4.DrugStoreDb;
using DrugStore4.Models;

namespace DrugStore4.Classes
{
    public class CatalogHelper
    {
        public List<CatalogModel> getAds(DrugStoreDbContext dbContext, int page)
        {
            List<CatalogModel> adModels = dbContext.Ads.Where(i => i.Id >= ((page - 1) * 9 + 1) && i.Id <= 9 * page)
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
    }
}

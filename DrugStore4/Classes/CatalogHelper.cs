using DrugStore4.DrugStoreDb;
using DrugStore4.Models;

namespace DrugStore4.Classes
{
    public class CatalogHelper
    {
        private int blockNumber = 9;
        public IQueryable<Ad> getAds(DrugStoreDbContext dbContext, string type, int filter, string query)
        {
            List<CatalogModel> adModels = [];
            var catalog = dbContext.Ads as IQueryable<Ad>;
            //query поиск 
            if (query != "")
            {
                catalog = catalog.Where(c => c.Title == query);
            }
            //filter применение фильтра по дате
            if (filter == 0)
            {
                catalog = catalog.OrderBy(c => c.Id);
            }
            else
            {
                catalog = catalog.OrderByDescending(c => c.Id);
            }
            //type
            if (int.TryParse(type, out int numType))
            {
                catalog = catalog.Where(a => a.DrugType.Id == numType);
            }
           
            return catalog;
        }                

        public List<DrugType> getListType(DrugStoreDbContext dbContext)
        {
            List<DrugType> types = dbContext.Type.Select(t =>  new DrugType { Id = t.Id, Name = t.Name}).ToList();
            return types;
        }

        public List<CatalogModel> GetCatalogModelOnCurrentPage(IQueryable<Ad> ads, int page) {

            List<CatalogModel> catalogModelsPage = ads.Skip((page - 1) * blockNumber).Take(blockNumber).Select(a => new CatalogModel
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
            }).ToList();
            return catalogModelsPage;
        }

        public CommonCatalogModel getCommonCatalogModel(DrugStoreDbContext dbContext, int page, string type, string filter, string searchDrug)
        {
            int IdFilter = int.Parse(filter);
            IQueryable<Ad> catalogModels = getAds(dbContext, type, IdFilter, searchDrug);           
            int amount = catalogModels.Count() / blockNumber;
            List<CatalogModel> catalogModelsPage = GetCatalogModelOnCurrentPage(catalogModels, page);
            List<DrugType> types = getListType(dbContext);
            CommonCatalogModel commonModel = new CommonCatalogModel
            {
                NumberPage = page,
                CatalogModels = catalogModelsPage,
                Types = types,
                SelectedTypeId = int.TryParse(type, out int numType)?numType : 0,
                SelectedFilterId = IdFilter,
                SearchDrug = searchDrug,
                AmountPage = amount
            };
            return commonModel;
        }
    }
}

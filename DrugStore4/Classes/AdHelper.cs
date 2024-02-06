using DrugStore4.DrugStoreDb;
using DrugStore4.Models;

namespace DrugStore4.Classes
{
    public class AdHelper
    {
        public CreateAdModel getTypeCategoryDrug(DrugStoreDbContext dbContext )
        {
            List<SimpleCommonModel> typeName = dbContext.Type.Select(x => new SimpleCommonModel(x.Id, x.Name)).ToList();
            List<SimpleCommonModel> categoryName = dbContext.Category.Select(x => new SimpleCommonModel(x.Id, x.Name)).ToList();
            CreateAdModel createAdModel = new CreateAdModel(typeName, categoryName);
            return createAdModel;
        }
    }
}

using DrugStore4.DrugStoreDb;

namespace DrugStore4.Models
{
    public class CommonCatalogModel
    {
        public List<CatalogModel> CatalogModels;        
        public List<DrugType> Types;
        public int SelectedTypeId {  get; set; }
        public int AmountPage {  get; set; } 
        public int NumberPage { get; set; }
    }
}

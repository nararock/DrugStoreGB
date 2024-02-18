using DrugStore4.DrugStoreDb;

namespace DrugStore4.Models
{
    public class ProfileModel
    {
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Nickname { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public List<CatalogModel> ads {  get; set; }
    }
}

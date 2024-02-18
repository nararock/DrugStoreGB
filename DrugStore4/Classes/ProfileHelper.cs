using DrugStore4.DrugStoreDb;
using DrugStore4.Models;

namespace DrugStore4.Classes
{
    public class ProfileHelper
    {
        public ProfileModel getProfileData(DrugStoreDbContext drugStoreDb, string userName)
        {
           List<ProfileModel> profileModels =  drugStoreDb.Users.Where(u => u.UserName == userName).Select(a => new ProfileModel
            {
                Nickname = a.Nickname,
                Email = a.Email,
                City = a.City,
                District = a.District,
                Telephone = a.PhoneNumber,
                ads = a.Ads.Select(a => new CatalogModel {
                    Title = a.Title,
                    Type = a.DrugType.Name,
                    Category = a.DrugCategory.Name,
                    Amount = a.Amount,
                    Description = a.Description,
                    Dose = a.Dose,
                    Manufacturer = a.Manufacturer,
                    Month = a.Month,
                    Year = a.Year,
                }).ToList(),
             }).ToList();
            return profileModels[0];
        }
    }
}

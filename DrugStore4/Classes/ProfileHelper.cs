using DrugStore4.DrugStoreDb;
using DrugStore4.Models;
using Microsoft.EntityFrameworkCore;

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
                    Id = a.Id,
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

        public bool DeleteAd(DrugStoreDbContext drugStoreDb, string userName, int idAd)
        {
            var ad = drugStoreDb.Ads.Include(a=>a.User).SingleOrDefault(a=>a.Id == idAd);
            if (ad.User.UserName == userName)
            {
                drugStoreDb.Ads.Remove(ad);
                drugStoreDb.SaveChanges();
                return true;
            }
            return false;
        }
    }    
}

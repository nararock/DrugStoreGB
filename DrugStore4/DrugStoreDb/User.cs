using Microsoft.AspNetCore.Identity;

namespace DrugStore4.DrugStoreDb
{
    public class User: IdentityUser
    {
        public List<Ad> Ads { get; set; }
        public string Nickname { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}


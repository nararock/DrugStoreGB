using Microsoft.AspNetCore.Identity;

namespace DrugStore4.DrugStoreDb
{
    public class User: IdentityUser
    {
        public string? Name { get; set; }
    }
}

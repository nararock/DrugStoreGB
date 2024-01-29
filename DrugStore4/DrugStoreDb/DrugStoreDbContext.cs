using DrugStore4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrugStore4.DrugStoreDb
{
    public class DrugStoreDbContext: IdentityDbContext<User>
    {
        public DrugStoreDbContext(DbContextOptions<DrugStoreDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}

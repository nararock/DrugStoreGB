using DrugStore4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DrugStore4.DrugStoreDb
{
    public class DrugStoreDbContext: IdentityDbContext<User>
    {
        public DbSet<DrugCategory> Category { get; set; }
        public DbSet<DrugType> Type { get; set; }
        public DrugStoreDbContext(DbContextOptions<DrugStoreDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}

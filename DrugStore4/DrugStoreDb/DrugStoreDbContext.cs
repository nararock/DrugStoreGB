using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrugStore4.DrugStoreDb
{
    public class DrugStoreDbContext: IdentityDbContext<User>
    {
        public DbSet<DrugCategory> Category { get; set; }
        public DbSet<DrugType> Type { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DrugStoreDbContext(DbContextOptions<DrugStoreDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ad>().HasOne(ad => ad.User).WithMany(u => u.Ads).HasForeignKey(a => a.UserId);
            builder.Entity<Ad>().HasOne(ad => ad.DrugType).WithMany().HasForeignKey(ad => ad.TypeId);
            builder.Entity<Ad>().HasOne(ad => ad.DrugCategory).WithMany().HasForeignKey(ad => ad.CategoryId);

            base.OnModelCreating(builder);
        }
    }
}

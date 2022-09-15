using Microsoft.EntityFrameworkCore;
using RestFulAPI.Infrastructure.SeedData;
using RestFulAPI.Models.Entities.Concrete;

namespace RestFulAPI.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CategorySeedData());
        //    modelBuilder.ApplyConfiguration(new AppUserSeedData());

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}

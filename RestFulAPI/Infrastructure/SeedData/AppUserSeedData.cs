using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Models.Entities.Concrete;

namespace RestFulAPI.Infrastructure.SeedData
{
    public class AppUserSeedData : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser { UserName="beast",Password="123"},
                new AppUser { UserName="savage",Password="123"},
                new AppUser {UserName="raider",Password="123"});
        }
    }
}

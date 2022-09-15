using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Models.Entities.Concrete;

namespace RestFulAPI.Infrastructure.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Name = "Boxing Gloves", Description = "Best boxing gloves here..!", Slug = "boxing-gloves" },
                new Category {  Name = "Protective Equipment", Description = "Best boxing gloves here..!", Slug = "protective-equipment" },
                new Category {Name = "Hand Wraps", Description = "Best boxing gloves here..!", Slug = "hand-wraps" });
        }
    }
}

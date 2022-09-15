using RestFulAPI.Infrastructure.Context;
using RestFulAPI.Infrastructure.Repositories.Interface;
using RestFulAPI.Models.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace RestFulAPI.Infrastructure.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id) => _context.Categories.Any(x => x.Id == id);

        public bool CategoryExists(string categoryName) => _context.Categories.Any(x => x.Name.ToLower().Trim() == categoryName.ToLower().Trim());

        public bool CreateCategory(Category categoryObj)
        {
            _context.Categories.AddAsync(categoryObj);
            return Save();
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories() => _context.Categories.OrderBy(x => x.Id).ToList();

        public Category GetCategory(int id) => _context.Categories.FirstOrDefault(x => x.Id == id);

        public Category GetCategory(string slug) => _context.Categories.FirstOrDefault(x => x.Slug == slug);

        public bool Save() => _context.SaveChanges() >= 0 ? true : false;

        public bool UpdateCategory(int id, Category category)
        {
            var cat = _context.Categories.Find(id);
            if (cat != null)
            {
                cat.Slug = category.Slug;
                cat.Name = category.Name;
                cat.Description = category.Description;
            _context.Categories.Update(cat);
            }
            return Save();
        }
    }
}

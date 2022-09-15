using RestFulAPI.Models.Entities.Concrete;
using System.Collections.Generic;

namespace RestFulAPI.Infrastructure.Repositories.Interface
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int id);
        Category GetCategory(string slug);
        bool CategoryExists(int id);
        bool CategoryExists(string categoryName);
        bool CreateCategory(Category categoryObj);
        bool UpdateCategory(int id, Category category);
        bool DeleteCategory(int id);
        bool Save();

    }
}

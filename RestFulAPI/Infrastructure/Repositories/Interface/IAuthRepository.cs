using RestFulAPI.Models.Entities.Concrete;

namespace RestFulAPI.Infrastructure.Repositories.Interface
{
    public interface IAuthRepository
    {
        AppUser Authentication(string username, string password);
    }
}

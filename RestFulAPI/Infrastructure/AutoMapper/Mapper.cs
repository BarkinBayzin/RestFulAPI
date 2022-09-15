using AutoMapper;
using RestFulAPI.Models.DTOs;
using RestFulAPI.Models.Entities.Concrete;

namespace RestFulAPI.Infrastructure.AutoMapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();

            CreateMap<AppUser, AuthenticationDTO>().ReverseMap();
        }
    }
}

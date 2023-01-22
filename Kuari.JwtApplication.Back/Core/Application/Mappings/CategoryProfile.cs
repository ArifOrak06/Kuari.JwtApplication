using AutoMapper;
using Kuari.JwtApplication.Back.Core.Application.DTOs;
using Kuari.JwtApplication.Back.Core.Domain;

namespace Kuari.JwtApplication.Back.Core.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryListDto>().ReverseMap();
            CreateMap<Category,CategoryCreateDto>().ReverseMap();
        }
    }
}

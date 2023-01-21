using AutoMapper;
using Kuari.JwtApplication.Back.Core.Application.DTOs;
using Kuari.JwtApplication.Back.Core.Domain;

namespace Kuari.JwtApplication.Back.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductListDto,Product>().ReverseMap();
            CreateMap<ProductCreateDto,Product>().ReverseMap();
        }
    }
}

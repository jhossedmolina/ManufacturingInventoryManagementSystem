using AutoMapper;
using ManufacturingInventory.Application.DTOs;
using ManufacturingInventory.Application.Enums;
using ManufacturingInventory.Domain.Entities;

namespace ManufacturingInventory.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDtoResponse>().ReverseMap();

            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.ProductionType, opt => opt.MapFrom(src => Enum.Parse<ProductionType>(src.ProductionType.ToString())))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<ProductStatus>(src.Status.ToString())));

            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using WebApp_vSem2.DTO;
using WebApp_vSem2.Models;

namespace WebApp_vSem2.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupModel>().ReverseMap();
        }
    }
}

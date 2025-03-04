using AutoMapper;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;

namespace SPSS.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductRequest, Product>();
        }
    }
}

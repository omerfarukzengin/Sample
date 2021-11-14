using AutoMapper;
using Sample.Core.Features.Products.Commands;
using Sample.Domain.Entities;

namespace Sample.Core.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
        }
    }
}

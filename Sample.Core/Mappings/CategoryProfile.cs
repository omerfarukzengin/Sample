using AutoMapper;
using Sample.Core.Features.Categories.Commands;
using Sample.Domain.Entities;

namespace Sample.Core.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        }
    }
}

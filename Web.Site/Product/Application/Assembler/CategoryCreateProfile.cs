namespace Web.Site.Product.Application.Assembler
{
    using AutoMapper;
    using Web.Site.Product.Application.Dto;
    using Web.Site.Product.Domain.Entity;

    public class CategoryCreateProfile: Profile
    {
        public CategoryCreateProfile()
        {
            CreateMap<CategoryCreateDto, Category>().ReverseMap();

            CreateMap<CategoryOutputDto, Category>().ReverseMap();
        }     
    }
}

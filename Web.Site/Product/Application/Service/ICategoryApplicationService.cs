namespace Web.Site.Product.Application.Service
{
    using System.Collections.Generic;
    using Web.Site.Product.Application.Dto;

    public interface ICategoryApplicationService
    {
        CategoryOutputDto Get(int id);
        List<CategoryOutputDto> GetAll();
        void Create(CategoryCreateDto model);
    }
}

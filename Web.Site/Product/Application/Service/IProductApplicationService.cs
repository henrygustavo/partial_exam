namespace Web.Site.Product.Application.Service
{
    using System.Collections.Generic;
    using Dto;

    public interface IProductApplicationService
    {
        ProductOutputDto Get(int id);
        List<ProductOutputDto> GetAll();
        List<ProductOutputDto> GetExpensives();
        long Create(ProductCreateDto productCreateDto);

    }
}

namespace Web.Site.Product.Domain.Repository
{
    using Web.Site.Common.Domain.Repository;
    using Entity;
    using System.Collections.Generic;
    using Web.Site.Api.Common.Domain.Specification;

    public interface IProductRepository : IRepository<Product>
    {
        IReadOnlyList<Product> GetFilteredList(Specification<Product> specification);
    }
}

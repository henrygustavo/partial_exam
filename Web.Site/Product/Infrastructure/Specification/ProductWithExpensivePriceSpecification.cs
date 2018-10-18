namespace Web.Site.Product.Infrastructure.Specification
{
    using System;
    using System.Linq.Expressions;
    using Web.Site.Api.Common.Domain.Specification;
    using Web.Site.Product.Domain.Entity;
    public sealed class ProductWithExpensivePriceSpecification : Specification<Product>
    {
        private const int MinValueForExpensive = 900;

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.Balance.Amount >= MinValueForExpensive;
        }
    }
}

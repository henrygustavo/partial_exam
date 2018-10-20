namespace Web.Site.Product.Domain.Entity
{
    using Web.Site.Common.Domain.ValueObject;

    public class NullProduct: AbstractProduct
    {
        public NullProduct()
        {
            Balance = new Money();
            Category = new Category();
        }
    }
}

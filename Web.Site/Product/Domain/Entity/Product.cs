namespace Web.Site.Product.Domain.Entity
{
    using Web.Site.Common.Domain.ValueObject;

    public class Product
    {
        public virtual long Id { get; set; }

        public virtual string  Name { get; set; }
        public virtual string PictureUrl { get; set; }
        public virtual string  Description { get; set; }
        
        public virtual Money Balance { get; set; }

        public virtual Category Category { get; set; }
        public Product()
        {
        }
    }
}

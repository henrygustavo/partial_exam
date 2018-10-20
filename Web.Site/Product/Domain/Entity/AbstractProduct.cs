namespace Web.Site.Product.Domain.Entity
{
    using Web.Site.Common.Domain.ValueObject;

    public abstract class AbstractProduct
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string PictureUrl { get; set; }
        public virtual string Description { get; set; }

        public virtual Money Balance { get; set; }

        public virtual Category Category { get; set; }
    
    }
}

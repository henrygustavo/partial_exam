namespace Web.Site.Product.Api.Messaging
{
    public class ProductCompletedEvent
    {
        public long ProductId { get; set; }
        public ProductCompletedEvent(long productId)
        {
            ProductId = productId;
        }
    }
}

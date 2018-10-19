namespace Web.Site.Product.Application.Service
{
    public interface IAmqpApplicationService
    {
        void PublishMessage(object message);
    }
}

using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Site.Product.Api.Messaging
{
    public class ProductCompletedEventConsumer : IConsumer<ProductCompletedEvent>
    {

        public Task Consume(ConsumeContext<ProductCompletedEvent> context)
        {
            return Task.Run ( () => context.Message.ProductId);
        }
    }
}
